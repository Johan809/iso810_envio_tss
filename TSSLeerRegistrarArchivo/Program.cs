using Microsoft.Extensions.Configuration;
using System.Globalization;
using TSSLeerRegistrarArchivo.Model;

namespace TSSLeerRegistrarArchivo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Proceso Registro Archivos Autodeterminación TSS");
            Console.ResetColor();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            string? rutaArchivos = configuration.GetSection("AppKeys").GetSection("RutaArchivos").Value;

            if (string.IsNullOrEmpty(rutaArchivos) || !Directory.Exists(rutaArchivos))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La ruta de archivos no es válida o no existe.");
                Console.ResetColor();
                return;
            }

            // Leer y procesar los archivos
            var archivos = Directory.GetFiles(rutaArchivos, "*.txt");
            if (archivos.Length == 0)
            {
                Console.WriteLine("No hay archivos para procesar.");
                return;
            }

            foreach (string archivo in archivos)
            {
                Console.WriteLine($"Procesando Archivo: {Path.GetFileName(archivo)}");

                try
                {
                    ProcesarArchivo(archivo);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error procesando el archivo {Path.GetFileName(archivo)}: {ex.Message}");
                    Console.ResetColor();
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Proceso Autodeterminación TSS Terminado...");
            Console.ResetColor();
        }

        private static void ProcesarArchivo(string archivo)
        {
            var lineas = File.ReadAllLines(archivo);

            if (lineas.Length < 3)
            {
                throw new Exception("El archivo no contiene las líneas mínimas requeridas (encabezado, detalle, sumario).");
            }

            //procesar encabezado
            var encabezado = lineas.First().Split(',');
            string rncEmpresa = encabezado[1];
            DateTime fechaTransmision = GetParsedDate(encabezado[2]);
            string periodo = encabezado[3];

            //procesar detalles
            List<AutodeterminacionTSS> detalles = lineas.Skip(1).Take(lineas.Length - 2)
                .Select(linea =>
                {
                    var campos = linea.Split(",");
                    return new AutodeterminacionTSS()
                    {
                        RncEmpresa = rncEmpresa,
                        FechaTransmision = fechaTransmision,
                        PeriodoCotizable = periodo,
                        Nss = campos[1],
                        Cedula = campos[2],
                        Nombres = campos[3].Trim(),
                        Apellidos = campos[4].Trim(),
                        SueldoMensual = decimal.Parse(campos[5]),
                        MontoCotizable = decimal.Parse(campos[6]),
                        FechaIngreso = GetParsedDate(campos[7]),
                        TipoContrato = campos[8],
                        Estado = campos[9]
                    };
                })
                .ToList();

            InsertarDatos(detalles);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Archivo {Path.GetFileName(archivo)} procesado exitosamente con {detalles.Count} registros.");
            Console.ResetColor();

            //Borrar el archivo despues de procesado
            try
            {
                File.Delete(archivo);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Archivo {Path.GetFileName(archivo)} eliminado.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error al eliminar el archivo {Path.GetFileName(archivo)}: {ex.Message}");
                Console.ResetColor();
            }
        }

        private static void InsertarDatos(List<AutodeterminacionTSS> detalles)
        {
            using var context = new TSSDbContext();
            context.Autodeterminaciones.AddRange(detalles);
            context.SaveChanges();
        }

        private static DateTime GetParsedDate(string date)
        {
            DateTime parsedDate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return parsedDate;
        }
    }
}

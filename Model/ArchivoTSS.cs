using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iso810_asignacion2.Model
{
    public class ArchivoTSS
    {
        public Encabezado Encabezado { get; set; }
        public List<Empleado> Detalles { get; set; }
        public Sumario Sumario { get; set; }

        public ArchivoTSS()
        {
            Encabezado = new Encabezado();
            Detalles = new List<Empleado>();
            Sumario = new Sumario();
        }

        public string GenerarArchivo()
        {
            // Lógica para formatear y construir el archivo en texto plano.
            return string.Empty;
        }
    }
}

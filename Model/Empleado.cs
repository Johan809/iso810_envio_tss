namespace iso810_asignacion2.Model
{
    public class Empleado
    {
        public string TipoRegistro { get; set; } = "D";
        public string Nss { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public decimal SueldoMensual { get; set; }
        public decimal MontoCotizable { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string TipoContrato { get; set; }
        public string Estado { get; set; }

        public static Empleado[] GetEmpleados()
        {
            Empleado[] arrEmpleados =
            [
                new Empleado
                {
                    Nss = "001234567890",
                    Cedula = "123456789",
                    Nombres = "Juan",
                    Apellidos = "Pérez",
                    SueldoMensual = 50000.00m,
                    MontoCotizable = 48000.00m,
                    FechaIngreso = new DateTime(2020, 1, 15),
                    TipoContrato = "P",
                    Estado = "A"
                },
                new Empleado
                {
                    Nss = "001234567891",
                    Cedula = "987654321",
                    Nombres = "María",
                    Apellidos = "González",
                    SueldoMensual = 45000.00m,
                    MontoCotizable = 43000.00m,
                    FechaIngreso = new DateTime(2019, 5, 10),
                    TipoContrato = "T",
                    Estado = "A"
                },
                new Empleado
                {
                    Nss = "001234567892",
                    Cedula = "456789123",
                    Nombres = "Pedro",
                    Apellidos = "Martínez",
                    SueldoMensual = 35000.00m,
                    MontoCotizable = 34000.00m,
                    FechaIngreso = new DateTime(2021, 7, 20),
                    TipoContrato = "P",
                    Estado = "S"
                },
                new Empleado
                {
                    Nss = "001234567893",
                    Cedula = "789123456",
                    Nombres = "Ana",
                    Apellidos = "López",
                    SueldoMensual = 60000.00m,
                    MontoCotizable = 58000.00m,
                    FechaIngreso = new DateTime(2018, 3, 12),
                    TipoContrato = "P",
                    Estado = "A"
                },
                new Empleado
                {
                    Nss = "001234567894",
                    Cedula = "321654987",
                    Nombres = "Luis",
                    Apellidos = "Rodríguez",
                    SueldoMensual = 40000.00m,
                    MontoCotizable = 39000.00m,
                    FechaIngreso = new DateTime(2022, 11, 5),
                    TipoContrato = "T",
                    Estado = "A"
                },
                new Empleado
                {
                    Nss = "001234567895",
                    Cedula = "654987321",
                    Nombres = "Sofía",
                    Apellidos = "Fernández",
                    SueldoMensual = 55000.00m,
                    MontoCotizable = 53000.00m,
                    FechaIngreso = new DateTime(2020, 2, 22),
                    TipoContrato = "P",
                    Estado = "A"
                },
                new Empleado
                {
                    Nss = "001234567896",
                    Cedula = "321456987",
                    Nombres = "Carlos",
                    Apellidos = "Morales",
                    SueldoMensual = 47000.00m,
                    MontoCotizable = 45000.00m,
                    FechaIngreso = new DateTime(2021, 10, 1),
                    TipoContrato = "T",
                    Estado = "S"
                },
                new Empleado
                {
                    Nss = "001234567897",
                    Cedula = "147258369",
                    Nombres = "Elena",
                    Apellidos = "Santos",
                    SueldoMensual = 52000.00m,
                    MontoCotizable = 50000.00m,
                    FechaIngreso = new DateTime(2017, 6, 15),
                    TipoContrato = "P",
                    Estado = "A"
                },
                new Empleado
                {
                    Nss = "001234567898",
                    Cedula = "258369147",
                    Nombres = "Miguel",
                    Apellidos = "Jiménez",
                    SueldoMensual = 41000.00m,
                    MontoCotizable = 39000.00m,
                    FechaIngreso = new DateTime(2019, 8, 25),
                    TipoContrato = "T",
                    Estado = "A"
                },
                new Empleado
                {
                    Nss = "001234567899",
                    Cedula = "369147258",
                    Nombres = "Laura",
                    Apellidos = "Torres",
                    SueldoMensual = 48000.00m,
                    MontoCotizable = 46000.00m,
                    FechaIngreso = new DateTime(2020, 12, 10),
                    TipoContrato = "P",
                    Estado = "A"
                }
            ];

            return arrEmpleados;
        }
    }
}

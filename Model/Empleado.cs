namespace iso810_asignacion2.Model
{
    public class Empleado
    {
        public string TipoRegistro { get; set; } = "D"; // Valor fijo
        public string Nss { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public decimal SueldoMensual { get; set; }
        public decimal MontoCotizable { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string TipoContrato { get; set; }
        public string Estado { get; set; }
    }

}

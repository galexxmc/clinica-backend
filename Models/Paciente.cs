namespace ClinicaBackend.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public int Edad { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}
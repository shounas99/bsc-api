namespace bscApi.DTO
{
    public class RegisterDTO
    {
        public string? Nombre { get; set; }
        public string? APaterno { get; set; }
        public string? AMaterno { get; set; }
        public string? Domicilio { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FNacimiento { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
    }
}

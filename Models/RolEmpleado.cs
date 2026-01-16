namespace SCE_DB_NET.Models
{
    public class RolEmpleado
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; } = string.Empty;
        public required ICollection<Usuarios> Usuarios { get; set; }
    }

}

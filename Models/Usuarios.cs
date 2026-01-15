namespace SCE_DB_NET.Models
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public int IdEmpleado { get; set; }
        public string HashClaveUsuario { get; set; } = string.Empty;
        public string CorreoUsuario { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public RolEmpleado Rol { get; set; }
        public Empleados Empleado { get; set; }
    }
}

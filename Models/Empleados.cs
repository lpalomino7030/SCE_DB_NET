namespace SCE_DB_NET.Models
{
    public class Empleados
    {
        public int IdEmpleado { get; set; }
        public string NombresEmpleado { get; set; } = string.Empty;
        public string ApellidosEmpleado { get; set; } = string.Empty;
        public string IdentificacionEmpleado { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public bool IsActivo { get; set; } = true;
    }
    }

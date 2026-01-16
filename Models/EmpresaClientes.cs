namespace SCE_DB_NET.Models
{
    public class EmpresaClientes
    {
        public int IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; } = string.Empty;
        public string NroIdentificacion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int IsActivo { get; set; }
        public int IdTipoEmpresa { get; set; }
        public int IdRolEmpresa { get; set; }
        public int IdUsuarioCreador { get; set; }








    }
}

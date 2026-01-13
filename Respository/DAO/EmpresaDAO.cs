using Microsoft.Data.SqlClient;
using SCE_DB_NET.Models;
using SCE_DB_NET.Respository.Interfaces;

namespace SCE_DB_NET.Respository.DAO
{
    public class EmpresaDAO : IEmpresa
    {
        private readonly string cadena = string.Empty;

        public EmpresaDAO()
        {
            cadena = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                Build().GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Empresa> listar()
        {
            List<Empresa> tmp = new List<Empresa>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_listaEmpresa", cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tmp.Add(new Empresa()
                    {
                        IdEmpresa = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                    });
                }

                dr.Close();
            }
            return tmp;
        }
    }
}

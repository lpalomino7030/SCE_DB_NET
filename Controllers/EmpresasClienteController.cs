using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCE_DB_NET.Data;

namespace SCE_DB_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpresasClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        private EmpresasClienteController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_db.EmpresaClientes.ListarCliente());
        //requiere añadir la funcion para listar 
        // se debe crear la interfaz y repositorio
        
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SCE_DB_NET.Models;
using SCE_DB_NET.Respository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCE_DB_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresa iempresa;

        public EmpresaController(IEmpresa _iempresa)
        {
            iempresa = _iempresa;
        }



        // GET: api/<EmpresaSceController>
        [HttpGet]
        public IActionResult GetEmpresa()
        {
         var lista = iempresa.listar();
            return Ok(lista);
        }

       
    }
}

using Microsoft.AspNetCore.Mvc;
using SCE_DB_NET.Respository.Service;

namespace SCE_DB_NET.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest model)
        {
            string token = _auth.Login(model.Correo, model.Clave);

            if (token == null)
                return Unauthorized("Credenciales incorrectas");

            return Ok(new { token });
        }

    }
}




public class LoginRequest
{
    public string Correo { get; set; }
    public string Clave { get; set; }
}
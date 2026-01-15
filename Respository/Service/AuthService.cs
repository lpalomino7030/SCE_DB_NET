using Microsoft.IdentityModel.Tokens;
using SCE_DB_NET.Data;
using SCE_DB_NET.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SCE_DB_NET.Respository.Service
{
    public class AuthService
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _config;

        public AuthService(ApplicationDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }


        public string Login(string correo, string password)
        {
            var usuario = _db.Usuarios
                .Include(x => x.Empleado)
                .Include(x => x.Rol)
                .FirstOrDefault(x => x.CorreoUsuario == correo);

            if (usuario == null)
                return null;

            bool valid = BCrypt.Net.BCrypt.Verify(password, usuario.HashClaveUsuario);
            if (!valid)
                return null;

            return GenerarToken(usuario);
        }

        private string GenerarToken(Usuarios usuario)
        {
            var claims = new List<Claim>{
            new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
            new Claim(ClaimTypes.Email, usuario.CorreoUsuario),
            new Claim(ClaimTypes.Role, usuario.Rol.NombreRol)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




    }
}

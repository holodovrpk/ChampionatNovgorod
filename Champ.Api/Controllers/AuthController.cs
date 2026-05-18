using Champ.Data;
using Champ.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Champ.Api.Controllers
{

    public class PasswordRequest
    {
        public string Email { get; set; }
    }


    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        JobContext db;

        public AuthController(JobContext context)
        {
            db = context;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AllUsers()
        {
            var users = db.Users.ToList();

            return Ok(new
            {
                success = true,

                message = "Список юзеров получен",

                error_code = "",

                data = users
            });
        }

        [HttpPost("password")]
        public async Task<IActionResult> ForgoutPass(PasswordRequest request)
        {
            return Ok(new
            {
                success = true,

                message = "Запрос отправлен",

                error_code = ""

            });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(Data.Models.LoginRequest request)
        {
            // Ищем пользователя в БД
            var user = await db.Users
                .FirstOrDefaultAsync(x =>
                    x.Email == request.Email &&
                    x.Password == request.Password);

            // Если пользователь не найден
            if (user == null)
            {
                return Unauthorized(new
                {
                    success = false,
                    message = "Неверный логин или пароль"
                });
            }

            // Внутри токена будет только ID пользователя
            var claims = new[]
            {
                new Claim("id", user.UserId.ToString())
            };

            // Секретный ключ
            string jwtKey = "12345678901234567890123456789012";

            // Создаем JWT токен
            var token = new JwtSecurityToken(

                // Данные внутри токена
                claims: claims,

                // Подписываем токен секретным ключом
                signingCredentials: new SigningCredentials(

                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtKey)),

                    SecurityAlgorithms.HmacSha256)
            );


            // Превращаем токен в строку
            string jwt =
                new JwtSecurityTokenHandler()
                    .WriteToken(token);

            // Возвращаем токен и данные пользователя
            return Ok(new
            {
                success = true,

                message = jwt,

                error_code = "",

                data = user
            });
        }




    }
}

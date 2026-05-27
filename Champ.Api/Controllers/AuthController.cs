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

          

            // Возвращаем токен и данные пользователя
            return Ok(new
            {
                success = true,

                message = "Логин успешный",

                error_code = "",

                data = user
            });
        }




    }
}

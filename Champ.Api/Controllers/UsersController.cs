using Champ.Data;
using Champ.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Champ.Api.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        JobContext db;

        public UsersController(JobContext context)
        {
            db = context;
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetMeUser()
        {
            var userId = User.FindFirst("id").Value;
            var us = db.Users.FirstOrDefault(x => x.UserId == Convert.ToInt32(userId));

            Console.WriteLine("Логин прошел");

            return Ok(new
            {
                success = true,

                message = "Профиль получен успешно",

                error_code = "",

                data = new
                {
                    FullName = us.FullName,
                    Email = us.Email,
                    Phone = us.Phone,
                    Avatar = us.Avatar,
                    UserSkills = 8,
                    UserConfirmations = 11,
                    UserRecomendations = 4,
                    CompetentionIndex = 49,
                    TrustLevel = 78
                }
            });



        }


        [Authorize]
        [HttpGet("history")]
        public async Task<IActionResult> GetHistory(int days = 30)
        {
            int userId = Convert.ToInt32(User.FindFirst("id").Value);

            DateTime dateFrom = DateTime.Now.AddDays(-days);

            var history = await db.RatingHistories
                .Where(x => x.UserId == userId && x.DateEdit >= dateFrom)
                .OrderBy(x => x.DateEdit).ToListAsync();

            return Ok(new
            {
                success = true,
                message = "История рейтинга получена",
                error_code = "",
                data = history
            });
        }


        [Authorize]
        [HttpGet("recomendations")]
        public async Task<IActionResult> GetRecomendationsy()
        {
            int userId = Convert.ToInt32(User.FindFirst("id").Value);


            var recoms = await db.Recomendations
                .Where(x => x.UserId == userId).ToListAsync();

            return Ok(new
            {
                success = true,
                message = "История рейтинга получена",
                error_code = "",
                data = recoms
            });
        }


    }
}

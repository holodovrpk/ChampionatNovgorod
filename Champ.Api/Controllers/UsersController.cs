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


        [HttpGet("{id}/me")]
        public async Task<IActionResult> GetMeUser(int id)
        {
        
            var us = db.Users.FirstOrDefault(x => x.UserId == id);

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

        public class ConfirmWeb
        {
            public string FromUser { get; set; }
            public string ToUser { get; set; }
            public string Skill { get; set; }
            public int  Level { get; set; }
            public string Status { get; set; }
            public DateTime Date { get; set; }
            public bool Incoming { get; set; }
        }


   
        [HttpGet("{id}/confirmations")]
        public async Task<IActionResult> GetConformat(int id)
        {

            var list = db.Confirmations.Include(x => x.User).Include(x => x.UserSkill).Include(x => x.ConfirmationStatus)
            .Where(x => x.UserId == id || x.AppUserId == id).
            OrderByDescending(x => x.DateCreate).
            ToList();

            List<ConfirmWeb> cw_list = new List<ConfirmWeb>();

            foreach (var c in list)
            {
                cw_list.Add(new ConfirmWeb
                {
                    FromUser = c.User.FullName,
                    ToUser = db.Users.FirstOrDefault(x => c.AppUserId == x.UserId).FullName,
                    Skill = db.Skills.FirstOrDefault(x => c.UserSkill.SkillId == x.SkillId).Name,
                    Level = c.UserSkill.Level,
                    Status = c.ConfirmationStatus.Name,
                    Date = c.DateCreate,
                    Incoming = c.AppUserId == id //  я зашел по id, значит этот запрос мне (я должен подтверждать....)

                });
            }

           

            return Ok(new
            {
                success = true,
                message = "Список подтверждений",
                error_code = "",
                data = cw_list
            });

        }


    }
}

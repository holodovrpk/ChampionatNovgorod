using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class Vacancy
    {
        public int VacancyId {get;set;}

        public int CompanyId {get;set;}
        public Company? Company {get;set;}

        [MaxLength(100)]
        public string Title {get;set;}
        [MaxLength(300)]
        public string? Description {get;set;}
        [Range(1,100)]
        public double HasRating {get;set;}
        public DateTime DateCreate {get;set;}

        public int SkillId {get;set;}
        public Skill? Skill {get;set;}
    }
}
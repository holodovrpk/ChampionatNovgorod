using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class UserSkill
    {
        public int UserSkillId {get;set;}   

        public int Userid {get;set;}
        public User? User {get;set;}

        public int SkillId {get;set;}
        public Skill? Skill {get;set;}

        [Range(1,10)]
        public int Level {get;set;}
        [MaxLength(300)]
        public string? Description {get;set;}
        public DateTime DateUp {get;set;}
    }
}
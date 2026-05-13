using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class Rating
    {
        public int RatingId {get;set;}

        public int UserId {get;set;}
        public User? User {get;set; }

        [Range(0, 100)]
        public double ComponentIndex {get;set;}
        [Range(0, 100)]
        public double TrustLevel {get;set;}
        [Range(0, int.MaxValue)]
        public int CountAgree {get;set;}
        [Range(0, int.MaxValue)]
        public int SkillCount {get;set;}
        public DateTime DateCreate {get;set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class RatingHistory
    {
        public int RatingHistoryId {get;set;}

        public int UserId {get;set;}
        public User? User {get;set;}

        [Range(0, 100)]
        public double CompetenceIndex {get;set;}
        [Range(0,100)]
        public double TrustLevel {get;set;}
        [MaxLength(100)]
        public string Reason {get;set;}
        public DateTime DateEdit {get;set;}
    }
}
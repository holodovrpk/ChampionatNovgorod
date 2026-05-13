using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class Recomendation
    {
        public int RecomendationId {get;set;}

        public int UserId {get;set;}
        public User? User {get;set;}

        [MaxLength(250)]
        public string Text {get;set;}
        public DateTime DateCreate {get;set;}
        public int UserCreateId {get;set;}
    }
}
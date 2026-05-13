using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class Log
    {
        public int LogId {get;set;}

        public int UserId {get;set;}
        public User? User {get;set;}

        [MaxLength(200)]
        public string Action {get;set;}
        [MaxLength(100)]
        public string Status {get;set;}
        public DateTime DateCreated {get;set;}
        public int UserCreatId {get;set;}
    }
}
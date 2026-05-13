using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class Notifacation
    {
        public int NotifacationId {get;set;}

        public int UserId {get;set;}
        public User? User {get;set;}

        [MaxLength(100)]
        public string Type {get;set;}
        [MaxLength(200)]
        public string Title {get;set;}
        public DateTime DateCreate {get;set;}
        public bool IsRead {get;set;}
    }
}
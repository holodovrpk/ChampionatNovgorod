using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class ShortList
    {
        public int ShortListId {get;set;}

        public int CompanyId {get;set;}
        public Company? Company {get;set;}

        public int UserId {get;set;}
        public User? User {get;set;}

        [MaxLength(100)]
        public string Title {get;set;}
        [MaxLength(350)]
        public string? Description{get;set;}
        public DateTime DateCreate {get;set;}
    }
}
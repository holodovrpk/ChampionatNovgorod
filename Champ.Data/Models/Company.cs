using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class Company
    {
        public int CompanyId {get;set;}
        [MaxLength(100)]
        public string Name {get;set;}
        [MaxLength(350)]
        public string? Description {get;set;}
        public int DateCrete {get;set;}

        public ICollection<UserExpercence>? UserExpercences {get;set;}
    }
}
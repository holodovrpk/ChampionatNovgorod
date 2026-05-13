using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class UserExpercence
    {
        public int UserExpercenceId {get;set;}

        public int UserId {get;set;}
        public User? User {get;set;}

        public int CompanyId {get;set;}
        public Company? Company {get;set;}

        public int EmploymentTypeId {get;set;}
        public EmploymentType? EmploymentType {get;set;}

        [MaxLength(100)]
        public string Postion {get;set;}
        [MaxLength(300)]
        public string? Description {get;set;}
        public int YearStart {get;set;}
        public int? YearEnd {get;set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class UserEducation
    {
        public int UserEducationId {get;set;}

        public int UserId {get;set;}
        public User? User {get;set;}

        public int InstitutId {get;set;}
        public Institut? Institut {get;set;}

        public int EducTypeId {get;set;}
        public EducType? EducType {get;set;}

        [MaxLength(100)]
        public string Speciality {get;set;}
        [MaxLength(100)]
        public string Result {get;set;}
        public int DateStart {get;set;}
        public int DateEnd {get;set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class EducType
    {
        public int EducTypeId {get;set;}
        [MaxLength(100)]
        public string Name {get;set;}

        public ICollection<UserEducation>? UserEducations {get;set;}
    }
}
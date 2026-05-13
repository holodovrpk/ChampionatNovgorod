using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class Role
    {
        public int RoleId {get;set;}
        [MaxLength(100)]
        public string Name {get;set;}
        [JsonIgnore]
        public ICollection<User>? Users {get;set;}
    }
}
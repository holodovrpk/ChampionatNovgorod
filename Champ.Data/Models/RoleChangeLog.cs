using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class RoleChangeLog
    {
        public int RoleChangeLogId {get;set;}

        public int UserId {get;set;}
        public User? User {get;set;}

        public int RoleId {get;set;}
        public Role? Role {get;set;}

        public int NewRoleId {get;set;}
        public DateTime DateEdit {get;set;}
    }
}
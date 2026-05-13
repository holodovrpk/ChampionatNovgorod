using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class ShortListHR
    {
        public int ShortListHRId {get;set;}

        public int ShortListId {get;set;}
        public ShortList? ShortList {get;set;}

        public int UserId {get;set;}
        public User? User{get;set;}

        public DateTime DateAdd {get;set;}
    }
}
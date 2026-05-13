using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class Confirmation
    {
        public int ConfirmationId {get;set;}

        public int UserId {get;set;}
        public User? User {get;set;}

        public int AppUserId {get;set;}

        public int UserSkillId {get;set;}
        public UserSkill? UserSkill {get;set;}

        public int UserExpercenceId {get;set;}
        public UserExpercence? UserExpercence {get;set;}

        public int ConfirmationStatusId {get;set;}
        public ConfirmationStatus? ConfirmationStatus {get;set;}

        [MaxLength(350)]
        public string? Comment {get;set;}
        public DateTime DateCreate {get;set;}
        public DateTime? DateApp {get;set;}
    }
}
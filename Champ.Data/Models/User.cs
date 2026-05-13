using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Champ.Data.Models
{
    [Index(nameof(Code), IsUnique = true)]
    [Index(nameof(Phone), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]

    public class User
    {
        public int UserId {get;set;}
        [MaxLength(50)]
        public string Code {get;set;}
        [MaxLength(350)]
        public string FullName {get;set;}
        [MaxLength(150)]
        public string Email {get;set;}
        [MaxLength(50)]
        public string Phone {get;set;}
        [MaxLength(350)]
        public string Password {get;set;}

        public int RoleId {get;set;}
        public Role? Role {get;set;}

        [MaxLength(150)]
        public string? Avatar {get;set;}
        public bool IsActice {get;set;}
        public DateTime DateRegister {get;set;}
        [MaxLength(50)]
        public string PinCode {get;set;}

        public ICollection<Confirmation>? Confirmations {get;set;}
        public ICollection<Integration>? Integrations {get;set;}
        public ICollection<Log>? Logs {get;set;}
        public ICollection<Notifacation>? Notifacations {get;set;}
        public ICollection<Rating>? Ratings {get;set;}
        public ICollection<RatingHistory>? RatingHistories {get;set;}
        public ICollection<Recomendation>? Recomendations {get;set;}
        public ICollection<RoleChangeLog>? RoleChangeLogs {get;set;}
        public ICollection<ShortList>? ShortLists {get;set;}
        public ICollection<ShortListHR>? ShortListHRs {get;set;}
        public ICollection<UserEducation>? UserEducations {get;set;}
        public ICollection<UserExpercence>? UserExpercences {get;set;}
        public ICollection<UserSkill>? UserSkills {get;set;}
        
    }
}
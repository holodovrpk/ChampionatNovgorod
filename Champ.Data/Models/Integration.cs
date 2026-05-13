using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class Integration
    {
        public int IntegrationId {get;set;}
        
        public int UserId {get;set;}
        public User? User {get;set;}

        public int IntegrationProviderId {get;set;}
        public IntegrationProvider? IntegrationProvider {get;set;}

        [MaxLength(100)]
        public string Login {get;set;}
        public bool IsConfiguration {get;set;}
        public DateTime DateCreate {get;set;}
    }
}
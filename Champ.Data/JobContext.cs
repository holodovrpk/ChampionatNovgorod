using Champ.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champ.Data
{
    public class JobContext : DbContext
    {
        public JobContext() { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Confirmation> Confirmations { get; set; }
        public DbSet<ConfirmationStatus> ConfirmationStatuses { get; set; }
        public DbSet<EducType> EducTypes { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<Institut> Instituts { get; set; }
        public DbSet<Integration> Integrations { get; set; }
        public DbSet<IntegrationProvider> IntegrationProviders { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Notifacation> Notifacations { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<RatingHistory> RatingHistories { get; set; }
        public DbSet<Recomendation> Recomendations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleChangeLog> RoleChangeLogs { get; set; }
        public DbSet<ShortList> ShortLists { get; set; }
        public DbSet<ShortListHR> ShortListHRs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserEducation> UserEducations { get; set; }
        public DbSet<UserExpercence> UserExpercences { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }

        public JobContext(DbContextOptions<JobContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;
                  Database=JobDb;
                  Trusted_Connection=True;
                  TrustServerCertificate=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }


    }
}

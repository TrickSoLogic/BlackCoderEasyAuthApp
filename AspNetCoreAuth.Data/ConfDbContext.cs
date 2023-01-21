using AspNetCoreAuth.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreAuth.Data
{
    public class ConfDbContext:DbContext
    {
        public ConfDbContext(DbContextOptions<ConfDbContext> options):base(options)
        {

        }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Conference>().HasData(new Conference { Id=1,Name="Pluralshight Live1",Location="Salt Lake City",Start=new DateTime(2022,10,12)});
            modelBuilder.Entity<Conference>().HasData(new Conference { Id = 2, Name = "Pluralshight Live2", Location = "Dhaka", Start = new DateTime(2023, 10, 12) });
            modelBuilder.Entity<Proposal>().HasData(new Proposal
            {
                Id = 1,
                ConferenceId = 1,
                Speaker = "Vishal bhat",
                Title = "Authentication and Authorization in ASP.NET Core"
            });

            modelBuilder.Entity<Proposal>().HasData(new Proposal
            {
                Id = 2,
                ConferenceId = 2,
                Speaker = "Black Coder",
                Title = "Starting Your Developer Career"
            });
            modelBuilder.Entity<Proposal>().HasData(new Proposal
            {
                Id = 3,
                ConferenceId = 2,
                Speaker = "TrickSoLogic",
                Title = "ASP.NET Core TagHelpers"
            });
            modelBuilder.Entity<Attendee>().HasData(new Attendee { Id = 1, ConferenceId = 1, Name = "Lisa Overthere" });
            modelBuilder.Entity<Attendee>().HasData(new Attendee { Id = 2, ConferenceId = 1, Name = "Robin Eisenberg" });
            modelBuilder.Entity<Attendee>().HasData(new Attendee { Id = 3, ConferenceId = 2, Name = "Sue Mashmellow" });
        }

    }
}

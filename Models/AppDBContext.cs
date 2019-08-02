using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeCode.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : 
            base(options)
        {

        }

        public DbSet<Talent> Talents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Talent>().HasData(
                new Talent
                {
                    Id = 1,
                    Name = "Lebron James",
                    Email = "KingJames@gmail.com",
                    Skills = Skills.AngularJS
                },
                new Talent
                {
                    Id = 2,
                    Name = "Anthony Davis",
                    Email = "theBrow@gmail.com",
                    Skills = Skills.C
                });
        }
    }
}

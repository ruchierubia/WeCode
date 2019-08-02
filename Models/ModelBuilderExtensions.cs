using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeCode.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
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

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Scripture_Project.Models;
using System.Threading.Tasks;
using Scripture_Project.Data;

namespace Scripture_Project.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Scripture_ProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Scripture_ProjectContext>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "Nephi",
                        Verse = "1 Nephi 3:7",
                        Content = "I'll do what the Lord commanded",
                        EntryDate = DateTime.Parse("1989-2-12")
                        
                    },

                    new Scripture
                    {
                        Book = "Nephi",
                        Verse = "2 Nephi 4:31",
                        Content = "I will trust The Lord forever",
                        EntryDate = DateTime.Parse("2015-5-30")
                    },

                    new Scripture
                    {
                        Book = "Moroni",
                        Verse = "Moroni 10:3",
                        Content = "Ask God if these things are true",
                        EntryDate = DateTime.Parse("2020-8-10")
                    }

                   
                );
                context.SaveChanges();
            }
        }
    }
}
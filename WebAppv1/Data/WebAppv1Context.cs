using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecApp.Models;

namespace WebAppv1.Data
{
    public class WebAppv1Context : DbContext
    {
        public WebAppv1Context (DbContextOptions<WebAppv1Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fiction>().HasData(
                new Fiction { Author = "Seeded Author", Id = 1, Title = "Seeded Title" });
            modelBuilder.Entity<FictionDetails>().HasData(
                new FictionDetails { Id = 1, FictionId = 1, Description = "Seeded Description", FictionType = AvailableFictionTypes.Action });
        }


        public DbSet<RecApp.Models.Fiction> Fiction { get; set; }


        public DbSet<RecApp.Models.FictionDetails> FictionDetails { get; set; }
    }
}

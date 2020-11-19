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
                new Fiction { Author = "Seeded Author", Id = 1, Title = "Seeded Title", FictionType=AvailableFictionTypes.Action, Description="Seeded Title"});
        }


        public DbSet<RecApp.Models.Fiction> Fiction { get; set; }
    }
}

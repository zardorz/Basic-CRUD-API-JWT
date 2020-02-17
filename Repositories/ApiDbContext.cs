using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Repositories
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }


        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasKey(entity => entity.Id);

            modelBuilder.Entity<User>()
               .HasKey(entity => entity.Id); 

            modelBuilder.Entity<Session>()
               .HasKey(entity => entity.Id);

            modelBuilder.Entity<User>().ToTable("tbl_User");

            modelBuilder.Entity<Flight>().ToTable("tbl_Flight");

            modelBuilder.Entity<Session>().ToTable("tbl_Session");

           // modelBuilder.Entity<User>().HasData(
           //    new User
           //    {
           //        Id = -1,
           //        FirstName = "Usuario",
           //        Username = "user@domain.com",
           //        Password = "123456"
           //    }
           //);
        }

    }
}

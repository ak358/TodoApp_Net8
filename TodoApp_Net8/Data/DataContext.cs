using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using TodoApp_Net8.Models;

namespace TodoApp_Net8.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Todo> Todoes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
                           new Todo
                           {
                               Id = 1,
                               Summary = "Sample Todo 1",
                               Detail = "This is the detail of Sample Todo 1",
                               Limit = DateTime.Now.AddDays(3),
                               Done = false,
                               UserId = 1
                           },
                           new Todo
                           {
                               Id = 2,
                               Summary = "Sample Todo 2",
                               Detail = "This is the detail of Sample Todo 2",
                               Limit = DateTime.Now.AddDays(5),
                               Done = false,
                               UserId = 2
                           }
                       );

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   UserName = "admin",
                   Password = "password",
                   RoleId = 1
               },
               new User
               {
                   Id = 2,
                   UserName = "user",
                   Password = "password",
                   RoleId = 2
               }
           );

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    RoleName = "administrator"
                },
                new Role
                {
                    Id = 2,
                    RoleName = "user"
                }
            );
        }
    }
}

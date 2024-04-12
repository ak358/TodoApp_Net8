using Microsoft.EntityFrameworkCore;
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




    }
}

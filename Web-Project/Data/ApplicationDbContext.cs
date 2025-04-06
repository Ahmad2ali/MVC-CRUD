using Microsoft.EntityFrameworkCore;
using Web_Project.Models;

namespace Web_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ApplicationDbContext _context; 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base( options )  
        {
            
        }
         
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DesplayOrder  = 1 },
                 new Category { Id = 2, Name = "Scifi", DesplayOrder = 12 },
                  new Category { Id = 3, Name = "History", DesplayOrder = 3 }
                );
         }

    }
}

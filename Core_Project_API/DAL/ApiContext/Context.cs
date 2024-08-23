
using Core_Project_API.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Project_API.DAL.ApiContext
{
    public class Context :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-8JJLI3A;Database=CoreProjectDB_API;integrated security= true;");
            
        }

        public DbSet<Category> Categories { get; set; }

    }
}

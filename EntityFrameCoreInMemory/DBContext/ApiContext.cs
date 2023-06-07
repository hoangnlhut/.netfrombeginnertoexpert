using EntityFrameCoreInMemory.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameCoreInMemory.DBContext
{
    public class ApiContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("DbInMemory");
        }
    }
}

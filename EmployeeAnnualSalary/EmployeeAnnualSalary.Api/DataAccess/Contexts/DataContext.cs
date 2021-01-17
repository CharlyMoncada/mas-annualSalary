using EmployeeAnnualSalary.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAnnualSalary.Api.DataAccess.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>()
                .HasIndex(c => c.ContractType)
                .IsUnique(true);

            modelBuilder.Entity<Person>()
                .HasIndex(p => p.Identifier)
                .IsUnique(true);
        }
    }
}

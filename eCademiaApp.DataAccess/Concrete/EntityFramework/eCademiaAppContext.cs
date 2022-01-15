using Core.Entities.Concrete;
using eCademiaApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace eCademiaApp.DataAccess.Concrete.EntityFramework
{
    public class eCademiaAppContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseImage> CourseImages { get; set; }
        public DbSet<CourseType> CourseTypes { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=eCademiaAppDB;Trusted_Connection=true");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-3GMD0GL\SQLEXPRESS;Database=dbname;Trusted_Connection=true");
        }
    }
}

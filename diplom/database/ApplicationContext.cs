using books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    //internal
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        //public DbSet<Company> Companies { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host = localhost; Port = 5432; Database = mydb; Username = postgres; Password = qwe");
        }
    }
}

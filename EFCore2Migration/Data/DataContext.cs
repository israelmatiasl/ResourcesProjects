using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore2Migration.Data
{
    public class DataContext : DbContext
    {
        
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
            /*optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=dbColegio;Trusted_Connection=True;User ID=sa;Password=98714731iml7;MultipleActiveResultSets=True")
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(new LoggerFactory().AddConsole(
                    (category, level) => level == LogLevel.Information && category == DbLoggerCategory.Database.Command.Name, true));*/
            optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=dbTestColegio;Trusted_Connection=True;User ID=sa;Password=98714731iml7;MultipleActiveResultSets=True");
       }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Student>()
                .HasKey(p => p.id);
            modelBuilder.Entity<Student>()
                .Property(x => x.id)
                .HasColumnName("id");

            modelBuilder.Entity<Student>()
                .Property(x => x.name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Student>()
                .Property(x => x.age)
                .HasColumnName("age")
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(x => x.email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Student>()
                .HasIndex(x => x.email)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .Property(x => x.password)
                .IsRequired()
                .HasMaxLength(50);



            modelBuilder.Entity<Region>()
                .HasKey(x => x.id);
            modelBuilder.Entity<Student>()
                .Property(x => x.id)
                .HasColumnName("id");

            modelBuilder.Entity<Region>()
                .Property(x => x.name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Region>()
                .Property(x => x.studentId)
                .HasColumnName("studentId");
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
    }
}

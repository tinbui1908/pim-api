using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Extensions;

namespace PIMToolCodeBase.Database
{
    /// <summary>
    ///     DbContext of PIMTool.
    /// </summary>
    public class PimContext : DbContext
    {
        public PimContext() : base("PimDatabase")
        {
            Database.CreateIfNotExists();
            //Database.SetInitializer<PimContext>(new SchoolDBInitializer());
        }

        public PimContext(DbConnection dbConnection) : base(dbConnection, true)
        {
            
        }

        public DbSet<Project> Project { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Project_Employee> Project_Employee { get; set; }
        public DbSet<Group> Group { get; set; }

        public DbSet<Sample> Samples { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseEntity>().HasKey(x => x.ID)
                .Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Sample>().ToTablePerConcreteTable();
            modelBuilder.Entity<Project>().ToTablePerConcreteTable().ToTable("PROJECT");
            modelBuilder.Entity<Employee>().ToTablePerConcreteTable().ToTable("EMPLOYEE");
            modelBuilder.Entity<Group>().ToTablePerConcreteTable().ToTable("GROUP");

            modelBuilder.Entity<Project_Employee>().HasKey(pe => new { pe.PROJECT_ID, pe.EMPLOYEE_ID });

            modelBuilder.Entity<Project_Employee>()
                .HasRequired<Project>(pe => pe.Project)
                .WithMany(p => p.ProjectEmployees)
                .HasForeignKey(pe => pe.PROJECT_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project_Employee>()
                .HasRequired<Employee>(pe => pe.Employee)
                .WithMany(e => e.ProjectEmployees)
                .HasForeignKey(pe => pe.EMPLOYEE_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
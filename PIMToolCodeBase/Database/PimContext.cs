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
        }

        public PimContext(DbConnection dbConnection) : base(dbConnection, true)
        {
            
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasKey(x => x.ID)
                .Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                                          
            modelBuilder.Entity<Employee>().HasKey(x => x.ID)
                .Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Group>().HasKey(x => x.ID)
                .Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			modelBuilder.Entity<Project>().ToTablePerConcreteTable().ToTable("PROJECT");
			modelBuilder.Entity<Employee>().ToTablePerConcreteTable().ToTable("EMPLOYEE");
			modelBuilder.Entity<Group>().ToTablePerConcreteTable().ToTable("GROUP");

			modelBuilder.Entity<Project_Employee>().HasKey(pe => new { pe.ProjectId, pe.EmployeeId });

			modelBuilder.Entity<Project_Employee>()
				.HasRequired<Project>(pe => pe.Project)
				.WithMany(p => p.ProjectEmployees)
				.HasForeignKey(pe => pe.ProjectId)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<Project_Employee>()
				.HasRequired<Employee>(pe => pe.Employee)
				.WithMany(e => e.ProjectEmployees)
				.HasForeignKey(pe => pe.EmployeeId)
				.WillCascadeOnDelete(false);
		}
	}
}
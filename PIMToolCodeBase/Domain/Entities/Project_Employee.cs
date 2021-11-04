using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMToolCodeBase.Domain.Entities
{
	[Table("PROJECT_EMPLOYEE")]
	public class Project_Employee
	{
		//[ForeignKey("Project")]
		[Column("PROJECT_ID")]
		public int projectId { get; set; }
		public Project Project { get; set; }

		//[ForeignKey("Employee")]
		[Column("EMPLOYEE_ID")]
		public int employeeId { get; set; }
		public Employee Employee { get; set; }
	}
}

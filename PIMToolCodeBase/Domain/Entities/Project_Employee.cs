using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMToolCodeBase.Domain.Entities
{
	[Table("PROJECT_EMPLOYEE")]
	public class Project_Employee
	{
		[Column("PROJECT_ID")]
		public int projectId { get; set; }
		public virtual Project Project { get; set; }

		[Column("EMPLOYEE_ID")]
		public int employeeId { get; set; }
		public virtual Employee Employee { get; set; }
	}
}

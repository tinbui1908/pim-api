using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMToolCodeBase.Domain.Entities
{
	[Table("PROJECT_EMPLOYEE")]
	public class Project_Employee
	{
		[ForeignKey("Project")]
		public int PROJECT_ID { get; set; }
		public Project Project { get; set; }

		[ForeignKey("Employee")]
		public int EMPLOYEE_ID { get; set; }
		public Employee Employee { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMToolCodeBase.Domain.Entities
{
	
	[Table("EMPLOYEE")]
	public class Employee: BaseEntity
	{

		[Required]
		[MaxLength(3)]
		public string VISA { get; set; }

		[Required]
		[MaxLength(50)]
		public string FIRST_NAME { get; set; }

		[Required]
		[MaxLength(50)]
		public string LAST_NAME { get; set; }

		[Required]
		public DateTime BIRTH_DATE { get; set; }

		[Required]
		public int VERSION { get; set; }

		// GROUP_LEADER_ID
		public ICollection<Group> Groups { get; set; }

		//
		public ICollection<Project_Employee> ProjectEmployees { get; set; }
	}
}

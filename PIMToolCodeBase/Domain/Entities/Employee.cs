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
		[Column("FIRST_NAME")]
		[MaxLength(50)]
		public string firstName { get; set; }

		[Required]
		[Column("LAST_NAME")]
		[MaxLength(50)]
		public string lastName { get; set; }

		[Required]
		[Column("BIRTH_DATE")]
		public DateTime birthDate { get; set; }

		[Required]
		public int VERSION { get; set; }

		//
		public ICollection<Project_Employee> project_employees { get; set; }
	}
}

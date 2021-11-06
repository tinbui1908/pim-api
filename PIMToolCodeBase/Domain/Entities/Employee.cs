using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMToolCodeBase.Domain.Entities
{
	public class Employee: BaseEntity
	{
		[Required]
		[MaxLength(3)]
		public string VISA { get; set; }

		[Required]
		[Column("FIRST_NAME")]
		[MaxLength(50)]
		public string FirstName { get; set; }

		[Required]
		[Column("LAST_NAME")]
		[MaxLength(50)]
		public string LastName { get; set; }

		[Required]
		[Column("BIRTH_DATE")]
		public DateTime BirthDate { get; set; }

		[Required]
		public int VERSION { get; set; }

		public virtual ICollection<Project_Employee> ProjectEmployees { get; set; } = new List<Project_Employee>();
	}
}

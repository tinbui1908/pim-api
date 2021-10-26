using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMToolCodeBase.Domain.Entities
{
	[Table("PROJECT")]
	public class Project: BaseEntity
	{
		[Required]
		public int PROJECT_NUMBER { get; set; }

		[Required]
		[MaxLength(50)]
		public string NAME { get; set; }

		[Required]
		[MaxLength(50)]
		public string CUSTOMER { get; set; }

		[Required]
		[MaxLength(3)]
		public string STATUS { get; set; }

		[Required]
		public DateTime START_DATE { get; set; }

		public DateTime? END_DATE { get; set; }

		[Required]
		public int VERSION { get; set; }

		//
		[ForeignKey("Group")]
		[Required]
		public int GROUP_ID { get; set; }
		public Group Group { get; set; }

		//
		public ICollection<Project_Employee> ProjectEmployees { get; set; }
	}
}

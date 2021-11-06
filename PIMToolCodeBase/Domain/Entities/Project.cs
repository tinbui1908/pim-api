using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMToolCodeBase.Domain.Entities
{
	public class Project: BaseEntity
	{
		[Required]
		[Column("PROJECT_NUMBER")]
		public int ProjectNumber { get; set; }

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
		[Column("START_DATE")]
		public DateTime StartDate { get; set; }

		[Column("END_DATE")]
		public DateTime? EndDate { get; set; }

		[Required]
		public int VERSION { get; set; }

		[Column("GROUP_ID")]
		[Required]
		public int GroupId { get; set; }
		public Group Group { get; set; }

		public virtual ICollection<Project_Employee> ProjectEmployees { get; set; } = new List<Project_Employee>();
	}
}

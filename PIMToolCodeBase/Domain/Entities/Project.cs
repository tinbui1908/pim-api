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
		[Column("PROJECT_NUMBER")]
		public int projectNumber { get; set; }

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
		public DateTime startDate { get; set; }

		[Column("END_DATE")]
		public DateTime? endDate { get; set; }

		[Required]
		public int VERSION { get; set; }

		//
		[ForeignKey("Group")]
		[Column("GROUP_ID")]
		[Required]
		public int groupId { get; set; }
		public Group Group { get; set; }

		//
		public ICollection<Employee> employees { get; set; } = new List<Employee>();
	}
}

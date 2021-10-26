using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMToolCodeBase.Domain.Entities
{
	[Table("GROUP")]
	public class Group: BaseEntity
	{
		//
		[ForeignKey("Employee")]
		[Required]
		public int GROUP_LEADER_ID { get; set; }
		public Employee Employee { get; set; }

		//
		public ICollection<Project> Projects { get; set; }

		//public Employee Employee { get; set; }
	}
}

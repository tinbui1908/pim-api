using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMToolCodeBase.Domain.Entities
{
	public class Group: BaseEntity
	{
		[ForeignKey("Employee")]
		[Required]
		[Column("GROUP_LEADER_ID")]
		public int GroupLeaderId { get; set; }
		public Employee Employee { get; set; }

		public ICollection<Project> Projects { get; set; }
	}
}

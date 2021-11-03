using PIMToolCodeBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMToolCodeBase.Dtos
{
	public class ProjectDto
	{
		public int id { get; set; }

		public int projectNumber { get; set; }

		public string name { get; set; }

		public string customer { get; set; }

		public string status { get; set; }

		public DateTime startDate { get; set; }

		public DateTime? endDate { get; set; }

		public int version { get; set; }

		public int groupId { get; set; }

		public int[] members { get; set; }

	}
}

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
		public int ID { get; set; }

		public int ProjectNumber { get; set; }

		public string Name { get; set; }

		public string Customer { get; set; }

		public string Status { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public int Version { get; set; }

		public int GroupId { get; set; }

		public IEnumerable<int> Members { get; set; }
	}
}

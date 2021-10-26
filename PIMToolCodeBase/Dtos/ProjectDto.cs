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

		public int PROJECT_NUMBER { get; set; }

		public string NAME { get; set; }

		public string CUSTOMER { get; set; }

		public string STATUS { get; set; }

		public DateTime START_DATE { get; set; }

		public DateTime? END_DATE { get; set; }

		public int VERSION { get; set; }

		public int GROUP_ID { get; set; }

		//public int[] MEMBERS { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMToolCodeBase.Dtos
{
	public class EmployeeDto
	{
		public int ID { get; set; }

		public string VISA { get; set; }

		public string FIRST_NAME { get; set; }

		public string LAST_NAME { get; set; }

		public DateTime BIRTH_DATE { get; set; }

		public int VERSION { get; set; }
	}
}

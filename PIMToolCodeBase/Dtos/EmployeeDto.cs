using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMToolCodeBase.Dtos
{
	public class EmployeeDto
	{
		public int id { get; set; }

		public string visa { get; set; }

		public string firstName { get; set; }

		public string lastName { get; set; }

		public DateTime birthDate { get; set; }

		public int version { get; set; }
	}
}

using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMToolCodeBase.Services
{
	public interface IEmployeeService
	{
		IEnumerable<Employee> Get();

		Employee Get(int id);

		Employee GetVisa(string visa);
	}
}

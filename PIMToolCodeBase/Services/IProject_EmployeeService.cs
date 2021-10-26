using PIMToolCodeBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMToolCodeBase.Services
{
	public interface IProject_EmployeeService
	{
		IEnumerable<Project_Employee> Get();

		Project_Employee Get(int id);
	}
}

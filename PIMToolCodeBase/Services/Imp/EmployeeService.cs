using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMToolCodeBase.Services.Imp
{
	public class EmployeeService : BaseService, IEmployeeService
	{
		private readonly IEmployeeRepository _employee;

		public EmployeeService(IEmployeeRepository employeeRepository)
		{
			_employee = employeeRepository;
		}

		public IEnumerable<Employee> Get()
		{
			return _employee.Get();
		}

		public Employee Get(int id)
		{
			return _employee.Get().SingleOrDefault(x => x.ID == id);
		}

		public Employee GetVisa(string visa)
		{
			return _employee.Get().SingleOrDefault(x => x.VISA == visa);
		}
	}
}

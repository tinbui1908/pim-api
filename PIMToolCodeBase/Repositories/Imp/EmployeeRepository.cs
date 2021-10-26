using PIMToolCodeBase.Database;
using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMToolCodeBase.Repositories.Imp
{
	public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(PimContext context): base(context)
		{
		} 
	}
}

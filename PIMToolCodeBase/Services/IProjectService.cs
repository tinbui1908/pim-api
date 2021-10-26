using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMToolCodeBase.Domain.Entities;

namespace PIMToolCodeBase.Services
{
	public interface IProjectService
	{
		IEnumerable<Project> Get();

		Project Get(int id);

		Project Create(Project project);
	}
}

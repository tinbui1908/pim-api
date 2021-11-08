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
		IQueryable<Project> Get();

		IEnumerable<Project> Get(string status, string search);

		Project Get(int id);

		Project Create(Project project);

		Project Update(Project project);

		void Delete(int[] selectedIDs);

		void Delete(int id);
	}
}

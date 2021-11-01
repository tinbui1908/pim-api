using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Repositories;

namespace PIMToolCodeBase.Services.Imp
{
	public class ProjectService : BaseService, IProjectService
	{
		private readonly IProjectRepository _project;

		public ProjectService(IProjectRepository projectRepository)
		{
			_project = projectRepository;
		}

		public IEnumerable<Project> Get()
		{
			return _project.Get();
		}

		public Project Get(int id)
		{
			return _project.Get().SingleOrDefault(x => x.ID == id);
		}

		public Project Create(Project project)
		{

			
			var projects = _project.Add(project);
			_project.SaveChange();
			return projects.FirstOrDefault();
		}
	}
}

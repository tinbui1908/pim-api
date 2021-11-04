using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Dtos;
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

		public IQueryable<Project> Get()
		{
			return _project.Get();
		}

		public Project Get(int id)
		{
			return _project.Get().Include(p => p.project_employees.Select(pe => pe.Employee)).SingleOrDefault(x => x.ID == id);
		}

		public Project Create(Project project)
		{			
			var projects = _project.Add(project);
			_project.SaveChange();
			return projects.FirstOrDefault();
		}

		public void Delete(int[] selectedIDs)
		{
			_project.Delete(selectedIDs);
			_project.SaveChange();
		}
	}
}

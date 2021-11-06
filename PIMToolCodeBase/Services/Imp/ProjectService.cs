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
			return _project.Get().Include(p => p.project_employees.Select(pe => pe.Employee));
		}

		public IEnumerable<Project> Get(string status, string search)
		{			
			try
			{
				int searchNumber = Int32.Parse(search);
				if (status is null)
				{
					return _project.Get().Where(p => p.projectNumber == searchNumber).ToList();
				}
				else
				{
					return _project.Get().Where(p => p.STATUS == status).Where(p => p.projectNumber == searchNumber).ToList();
				}
			}
			catch
			{
				if (status is null && !(search is null))
				{
					return _project.Get().Where(p => p.NAME.ToLower().Contains(search) || p.CUSTOMER.ToLower().Contains(search.ToLower())).ToList();
				}
				if (!(status is null) && search is null)
				{
					return _project.Get().Where(p => p.STATUS == status).ToList();

				}
				if (!(status is null) && !(search is null))
				{
					return _project.Get().Where(p => p.STATUS == status).Where(p => p.NAME.ToLower().Contains(search.ToLower()) || p.CUSTOMER.ToLower().Contains(search.ToLower())).ToList();

				}
			}
			return _project.Get().ToList();
		}          

		public Project Get(int id)
		{
			return _project.Get()
				.Include(p => p.project_employees.Select(pe => pe.Employee))
				.SingleOrDefault(x => x.ID == id);
		}

		public Project Create(Project project)
		{
			var projects = _project.Add(project);
			_project.SaveChange();
			return projects.FirstOrDefault();
		}

		public Project Update(Project project)
		{
			var projectDb = _project.Get(project.ID);
			if (projectDb == null)
			{
				throw new ArgumentException();
			}
			projectDb.project_employees.Clear();
			projectDb.NAME = project.NAME;
			projectDb.CUSTOMER = project.CUSTOMER;
			projectDb.STATUS = project.STATUS;
			projectDb.startDate = project.startDate;
			projectDb.endDate = project.endDate;
			projectDb.VERSION = project.VERSION;
			projectDb.groupId = project.groupId;
			projectDb.project_employees = project.project_employees;
			_project.SaveChange();
			return projectDb;
		}

		public void Delete(int[] selectedIDs)
		{
			_project.Delete(selectedIDs);
			_project.SaveChange();
		}
	}
}
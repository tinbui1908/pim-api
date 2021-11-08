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
		private readonly IProjectRepository _projectRepository;

		public ProjectService(IProjectRepository projectRepository)
		{
			_projectRepository = projectRepository;
		}

		public IQueryable<Project> Get()
		{
			return _projectRepository.Get().Include(p => p.ProjectEmployees.Select(pe => pe.Employee)).OrderBy(pro => pro.ProjectNumber);
		}

		public IEnumerable<Project> Get(string status, string search)
		{			
			try
			{
				int searchNumber = Int32.Parse(search);
				if (status is null)
				{
					return _projectRepository.Get().Where(p => p.ProjectNumber == searchNumber).OrderBy(pro => pro.ProjectNumber).ToList();
				}
				else
				{
					return _projectRepository.Get().Where(p => p.STATUS == status).Where(p => p.ProjectNumber == searchNumber).OrderBy(pro => pro.ProjectNumber).ToList();
				}
			}
			catch
			{
				if (status is null && !(search is null))
				{
					return _projectRepository.Get().Where(p => p.NAME.ToLower().Contains(search) || p.CUSTOMER.ToLower().Contains(search.ToLower())).OrderBy(pro => pro.ProjectNumber).ToList();
				}
				if (!(status is null) && search is null)
				{
					return _projectRepository.Get().Where(p => p.STATUS == status).OrderBy(pro => pro.ProjectNumber).ToList();

				}
				if (!(status is null) && !(search is null))
				{
					return _projectRepository.Get().Where(p => p.STATUS == status).Where(p => p.NAME.ToLower().Contains(search.ToLower()) || p.CUSTOMER.ToLower().Contains(search.ToLower())).OrderBy(pro => pro.ProjectNumber).ToList();

				}
			}
			return _projectRepository.Get().OrderBy(pro => pro.ProjectNumber).ToList();
		}          

		public Project Get(int id)
		{
			return _projectRepository.Get()
				.Include(p => p.ProjectEmployees.Select(pe => pe.Employee))
				.SingleOrDefault(x => x.ID == id);
		}

		public Project Create(Project project)
		{
			//The update is missing checking business (like: project number must be unique, end date must after start date...)
			var projects = _projectRepository.Add(project);
			_projectRepository.SaveChange();
			return projects.FirstOrDefault();
		}

		public Project Update(Project project)
		{
			var projectDb = _projectRepository.Get(project.ID);
			if (projectDb == null)
			{
				throw new ArgumentException();
			}
			projectDb.ProjectEmployees.Clear();
			projectDb.NAME = project.NAME;
			projectDb.CUSTOMER = project.CUSTOMER;
			projectDb.STATUS = project.STATUS;
			projectDb.StartDate = project.StartDate;
			projectDb.EndDate = project.EndDate;
			projectDb.VERSION = project.VERSION;
			projectDb.GroupId = project.GroupId;
			projectDb.ProjectEmployees = project.ProjectEmployees;
			_projectRepository.SaveChange();
			return projectDb;
		}

		public void Delete(int[] selectedIds)
		{
			_projectRepository.Delete(selectedIds);
			_projectRepository.SaveChange();
		}

		public void Delete(int id)
		{
			_projectRepository.Delete(id);
			_projectRepository.SaveChange();
		}
	}
}
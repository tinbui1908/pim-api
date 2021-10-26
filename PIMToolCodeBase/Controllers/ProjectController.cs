using AutoMapper;
using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Dtos;
using PIMToolCodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PIMToolCodeBase.Controllers
{
	public class ProjectController: BaseController
	{
		private readonly IMapper _mapper;
		private readonly IProjectService _projectService;

		public ProjectController(IProjectService projectService, IMapper mapper)
		{
			_projectService = projectService;
			_mapper = mapper;
		}

		/// <summary>
		///     URL: /project
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IEnumerable<ProjectDto> Get()
		{
			return _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDto>>(_projectService.Get());
		}

		/// <summary>
		///     URL: /project/1
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ProjectDto Get(int id)
		{
			return _mapper.Map<Project, ProjectDto>(_projectService.Get(id));
		}

		[HttpPost]
		public ProjectDto Post(ProjectDto project)
		{
			Project newProject = _mapper.Map<ProjectDto, Project>(project);
			//foreach(var id in project.MEMBERS)
			//{
			//	Project_Employee t = new Project_Employee();
			//	t.EMPLOYEE_ID = id;
			//	newProject.ProjectEmployees.Add(t);
			//}
			return _mapper.Map<Project, ProjectDto>(_projectService.Create(newProject));
		}
	}
}

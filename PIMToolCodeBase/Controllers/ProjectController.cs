using AutoMapper;
using PIMToolCodeBase.Database;
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
	public class ProjectController : BaseController
	{
		private readonly IMapper _mapper;
		private readonly IProjectService _projectService;
		private readonly IEmployeeService _employeeService;

		public ProjectController(IProjectService projectService, IMapper mapper, IEmployeeService employeeService)
		{
			_projectService = projectService;
			_mapper = mapper;
			_employeeService = employeeService;
		}

		/// <summary>	
		///     URL: /project
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("project")]
		public IEnumerable<ProjectDto> Get()
		{
			return _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDto>>(_projectService.Get());
		}

		[HttpGet]
		[Route("project")]
		public IEnumerable<ProjectDto> Get(string status, string search)
		{
			return _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDto>>(_projectService.Get(status, search));
		}

		/// <summary>
		///     URL: /project/1
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("project/{id}")]
		public ProjectDto Get(int id)
		{
			return _mapper.Map<Project, ProjectDto>(_projectService.Get(id));
		}

		[HttpPost]
		[Route("project")]
		public ProjectDto Post([FromBody] ProjectDto project)
		{                                                   
			Project newProject = _mapper.Map<ProjectDto, Project>(project);
			foreach (var member in project.members)
			{
				Project_Employee e = new Project_Employee();
				e.employeeId = member;
				newProject.project_employees.Add(e);
			}
			return _mapper.Map<Project, ProjectDto>(_projectService.Create(newProject));
		}

		[HttpPut]
		[Route("project")]
		public ProjectDto Put(ProjectDto project)
		{
			Project updateProject = _mapper.Map<ProjectDto, Project>(project);
			foreach (var member in project.members)
			{
				Project_Employee e = new Project_Employee();
				e.employeeId = member;
				updateProject.project_employees.Add(e);
			}
			return _mapper.Map<Project, ProjectDto>(_projectService.Update(updateProject));
		}

		[HttpPost]
		[Route("project/delete")]
		public void Delete([FromBody] int[] selectedIDs)
		{
			_projectService.Delete(selectedIDs);
		}


	}
}
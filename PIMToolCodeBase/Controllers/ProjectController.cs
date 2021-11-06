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

		/// <summary>	
		///     URL: /project?status=&search=
		/// </summary>
		/// <returns></returns>
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

		/// <summary>	
		///     URL: /project
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("project")]
		public ProjectDto Post([FromBody] ProjectDto project)
		{                                                   
			Project newProject = _mapper.Map<ProjectDto, Project>(project);
			foreach (var member in project.Members)
			{
				Project_Employee e = new Project_Employee();
				e.EmployeeId = member;
				newProject.ProjectEmployees.Add(e);
			}
			return _mapper.Map<Project, ProjectDto>(_projectService.Create(newProject));
		}

		/// <summary>	
		///     URL: /project
		/// </summary>
		/// <returns></returns>
		[HttpPut]
		[Route("project")]
		public ProjectDto Put(ProjectDto project)
		{
			Project updateProject = _mapper.Map<ProjectDto, Project>(project);
			foreach (var member in project.Members)
			{
				Project_Employee e = new Project_Employee();
				e.EmployeeId = member;
				updateProject.ProjectEmployees.Add(e);
			}
			return _mapper.Map<Project, ProjectDto>(_projectService.Update(updateProject));
		}

		/// <summary>	
		///     URL: /project/delete
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("project/delete")]
		public void Delete([FromBody] int[] selectedIds)
		{
			_projectService.Delete(selectedIds);
		}
	}
}
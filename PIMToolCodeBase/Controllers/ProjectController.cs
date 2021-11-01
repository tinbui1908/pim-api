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
	public class ProjectController: BaseController
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
			foreach (var member in project.members)
			{
				Employee e = new Employee();
				e.ID = member;
				newProject.employees.Add(e);
			}
			var employeeDbs = _employeeService.Get().ToList();

			var employees = from employee in employeeDbs
							join employee2 in newProject.employees
							on employee.ID equals employee2.ID
							select employee;

			employees = employees.ToList();

			newProject.employees.Clear();

			foreach (var employee in employees)
			{
				newProject.employees.Add(employee);
			}

			return _mapper.Map<Project, ProjectDto>(_projectService.Create(newProject));
		}
	}
}
         
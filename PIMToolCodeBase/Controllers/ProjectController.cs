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
		private static readonly string[] STATUS_VALUE = { "new", "pla", "inp", "fin" };
		private readonly IMapper _mapper;
		private readonly IProjectService _projectService;
		private readonly IEmployeeService _employeeService;
		private readonly IGroupService _groupService;

		public ProjectController(IProjectService projectService, IMapper mapper, IEmployeeService employeeService, IGroupService groupService)
		{
			_projectService = projectService;
			_mapper = mapper;
			_employeeService = employeeService;
			_groupService = groupService;
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
			if (project.ProjectNumber > 0)
			{
				bool isExistingProject = _projectService.Get().Any(pro => pro.ProjectNumber == project.ProjectNumber);

				if (!isExistingProject)
				{
					if (STATUS_VALUE.Contains(project.Status))
					{
						if (project.StartDate < project.EndDate || project.EndDate is null)
						{
							bool isExistingGroup = _groupService.Get().Any(group => group.ID == project.GroupId);

							if (isExistingGroup)
							{
								foreach (var employeeId in project.Members)
								{
									bool isExistingEmployee = _employeeService.Get().Any(employee => employee.ID == employeeId);

									if (!isExistingEmployee)
									{
										throw new Exception("Some employee Id maybe not exist");
									}
								}

								Project newProject = _mapper.Map<ProjectDto, Project>(project);

								foreach (var member in project.Members)
								{
									Project_Employee e = new Project_Employee();
									e.EmployeeId = member;
									newProject.ProjectEmployees.Add(e);
								}

								return _mapper.Map<Project, ProjectDto>(_projectService.Create(newProject));
							}
							else
							{
								throw new Exception("This group Id is not exist");
							}
						}
						else
						{
							throw new Exception("Start date and end date of this project is not valid");
						}
					}
					else
					{
						throw new Exception("Status is not valid");
					}					
				}
				else
				{
					throw new Exception("This project number has already existed");
				}
			}
			else
			{
				throw new Exception("This type of project number is not valid");
			}
		}

		/// <summary>	
		///     URL: /project
		/// </summary>
		/// <returns></returns>
		[HttpPut]
		[Route("project")]
		public ProjectDto Put(ProjectDto project)
		{
			if (project.ProjectNumber > 0 && project.ID > 0)
			{
				bool isExistingProject = _projectService.Get().Any(pro => pro.ID == project.ID);

				if (isExistingProject)
				{
					if (STATUS_VALUE.Contains(project.Status))
					{
						if (project.StartDate < project.EndDate || project.EndDate is null)
						{
							bool isExistingGroup = _groupService.Get().Any(group => group.ID == project.GroupId);

							if (isExistingGroup)
							{
								foreach (var employeeId in project.Members)
								{
									bool isExistingEmployee = _employeeService.Get().Any(employee => employee.ID == employeeId);

									if (!isExistingEmployee)
									{
										throw new Exception("Some employee Id maybe not exist");
									}
								}

								Project updateProject = _mapper.Map<ProjectDto, Project>(project);
								foreach (var member in project.Members)
								{
									Project_Employee e = new Project_Employee();
									e.EmployeeId = member;
									updateProject.ProjectEmployees.Add(e);
								}
								return _mapper.Map<Project, ProjectDto>(_projectService.Update(updateProject));
							}
							else
							{
								throw new Exception("This group Id is not exist");
							}
						}
						else
						{
							throw new Exception("Start date and end date of this project is not valid");
						}
					}
					else
					{
						throw new Exception("Status is not valid");
					}
				}
				else
				{
					throw new Exception("This project is not exist");
				}
			}
			else
			{
				throw new Exception("This type of project number or project ID is not valid");
			}
			
		}

		/// <summary>	
		///     URL: /project/delete
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("project/delete")]
		public void Delete([FromBody] int[] selectedIds)
		{
			bool isExistingProject;
			foreach (var memberId in selectedIds)
			{
				isExistingProject = _projectService.Get().Any(pro => pro.ID == memberId);
				if (!isExistingProject)
				{
					throw new Exception("MemberId " + memberId + "is not exist");
				}
			}
			_projectService.Delete(selectedIds);
		}

		/// <summary>	
		///     URL: /project/:id
		/// </summary>
		/// <returns></returns>
		[HttpDelete]
		[Route("project/{id}")]
		public void Delete(int id)
		{
			bool isExistingProject;

			isExistingProject = _projectService.Get().Any(pro => pro.ID == id);
			if (!isExistingProject)
			{
				throw new Exception("MemberId " + id + "is not exist");
			}

			_projectService.Delete(id);
		}
	}
}
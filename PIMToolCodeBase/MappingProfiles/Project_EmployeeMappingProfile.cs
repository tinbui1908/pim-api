using AutoMapper;
using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMToolCodeBase.MappingProfiles
{
	public class Project_EmployeeMappingProfile: Profile
	{
		public Project_EmployeeMappingProfile() : base(nameof(Project_EmployeeMappingProfile))
		{
			CreateMap<Project_Employee, Project_EmployeeDto>().ReverseMap();
		}
	}
}

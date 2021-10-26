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
	public class ProjectMappingProfile: Profile
	{
		public ProjectMappingProfile() : base(nameof(ProjectMappingProfile))
		{
			CreateMap<Project, ProjectDto>().ReverseMap();
		}
	}
}

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
	public class GroupMappingProfile : Profile
	{
		public GroupMappingProfile() : base(nameof(GroupMappingProfile))
		{
			CreateMap<Group, GroupDto>().ForMember(x => x.LeaderName, pt => pt.MapFrom(src => src.Employee.FirstName)).ReverseMap();
		}
	}
}

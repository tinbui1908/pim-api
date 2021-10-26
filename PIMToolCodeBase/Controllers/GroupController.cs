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
	public class GroupController: BaseController
	{
		private readonly IMapper _mapper;
		private readonly IGroupService _groupService;

		public GroupController(IGroupService groupService, IMapper mapper)
		{
			_groupService = groupService;
			_mapper = mapper;
		}

		/// <summary>
		///     URL: /group
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IEnumerable<GroupDto> Get()
		{
			return _mapper.Map<IEnumerable<Group>, IEnumerable<GroupDto>>(_groupService.Get());
		}

		/// <summary>
		///     URL: /group/1
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public GroupDto Get(int id)
		{
			return _mapper.Map<Group, GroupDto>(_groupService.Get(id));
		}
	}
}

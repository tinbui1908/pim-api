using PIMToolCodeBase.Domain.Entities;
using PIMToolCodeBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMToolCodeBase.Services.Imp
{
	public class GroupService : BaseService, IGroupService
	{
		private readonly IGroupRepository _group;

		public GroupService(IGroupRepository groupRepository)
		{
			_group = groupRepository;
		}

		public IQueryable<Group> Get()
		{
			return _group.Get();
		}

		public Group Get(int id)
		{
			return _group.Get().SingleOrDefault(x => x.ID == id);
		}
	}
}

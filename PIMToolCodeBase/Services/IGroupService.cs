﻿using PIMToolCodeBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMToolCodeBase.Services
{
	public interface IGroupService
	{
		IQueryable<Group> Get();

		Group Get(int id);
	}
}

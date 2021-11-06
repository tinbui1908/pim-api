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
	public class EmployeeController: BaseController
	{
		private readonly IMapper _mapper;
		private readonly IEmployeeService _employeeService;

		public EmployeeController(IEmployeeService employeeService, IMapper mapper)
		{
			_employeeService = employeeService;
			_mapper = mapper;
		}

		/// <summary>
		///     URL: /employee
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IEnumerable<EmployeeDto> Get()
		{
			return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(_employeeService.Get());
		}

		/// <summary>
		///     URL: /employee/1
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public EmployeeDto Get(int id)
		{
			return _mapper.Map<Employee, EmployeeDto>(_employeeService.Get(id));
		}

		/// <summary>
		///     URL: /employee?visa=
		/// </summary>
		/// <returns></returns>
		/// 
		[HttpGet]
		public EmployeeDto GetVisa(string visa)
		{
			return _mapper.Map<Employee, EmployeeDto>(_employeeService.GetVisa(visa));
		}
	}
}

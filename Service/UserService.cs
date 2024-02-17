using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	internal sealed class UserService : IUserService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;

		public UserService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}

		public IEnumerable<UserDTO> GetAllUsers(bool trackChanges)
		{
			try
			{
				var users = _repository.User.GetAllUsers(trackChanges);
				var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);
				return usersDTO;
			}
			catch (Exception e)
			{
				_logger.LogError($"Something went wrong in the {nameof(GetAllUsers)} service method {e}");
				throw;
			}
		}
	}
}

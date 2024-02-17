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

		public UserService(IRepositoryManager repository, ILoggerManager logger)
		{
			_repository = repository;
			_logger = logger;
		}

		public IEnumerable<UserDTO> GetAllUsers(bool trackChanges)
		{
			try
			{
				var user = _repository.User.GetAllUsers(trackChanges);
				var userDTO = user.Select(u => new UserDTO(u.Id, u.Image, u.Name, u.Email, u.Username))
									.ToList();
				return userDTO;
			}
			catch (Exception e)
			{
				_logger.LogError($"Something went wrong in the {nameof(GetAllUsers)} service method {e}");
				throw;
			}
		}
	}
}

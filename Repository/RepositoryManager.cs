using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Repository
{
	public sealed class RepositoryManager : IRepositoryManager
	{
		private readonly RepositoryContext _repositoryContext;
		private readonly Lazy<IUserRepository> _userRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
			_repositoryContext = repositoryContext;
			_userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
        }

		public IUserRepository User => _userRepository.Value;

        public void Save()
		{
			_repositoryContext.SaveChanges();
		}
	}
}

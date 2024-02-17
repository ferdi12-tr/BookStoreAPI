using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace BookStoreWebAPI
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}

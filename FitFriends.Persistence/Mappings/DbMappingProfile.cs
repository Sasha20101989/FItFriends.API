using AutoMapper;
using FitFriends.Logic.Models;
using FitFriends.Persistence.Entities;

namespace FitFriends.Persistence.Mappings
{
    public class DbMappingProfile : Profile
    {
        public DbMappingProfile()
        {
            CreateMap<User, UserEntity>().ReverseMap();
        }
    }
}

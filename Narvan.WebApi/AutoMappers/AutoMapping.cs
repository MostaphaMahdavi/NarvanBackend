using AutoMapper;
using Narvan.Domains.Users.Commands;
using Narvan.Domains.Users.Entities;
using Narvan.Domains.Users.Queries;

namespace Narvan.WebApi.AutoMappers
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<GetAllUserInfo, User>().ReverseMap();
            CreateMap<User, AddUserCommandInfo>().ReverseMap();
            CreateMap<User, EditUserCommandInfo>().ReverseMap();
            CreateMap<User, RegisterUserInfo>().ReverseMap();
        }
    }
}
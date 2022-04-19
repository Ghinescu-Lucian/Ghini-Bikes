using Application.Users.Commands.CreateUser;
using AutoMapper;
using Domain.Users;
using WebAPI.Dtos;

namespace WebAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto,CreateUserCommand>()
                .ForMember(u => u.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(u => u.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember( u => u.Email, opt => opt.MapFrom(s => s.Email))
                .ReverseMap();
            CreateMap<UserDto, NormalUser>()
                .ReverseMap();
        }
    }
}

using AutoMapper;
using Swipepick.Angular.Domain;
using Swipepick.Angular.UseCases.Users.AddUser;

namespace Swipepick.Angular.UseCases;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<AddUserCommand, User>()
            .ForMember(u => u.PasswordHash, dest => dest.Ignore())
            .ForMember(u => u.PasswordSalt, dest => dest.Ignore())
            .ForMember(u => u.Tests, dest => dest.Ignore())
            .ForMember(u => u.Students, dest => dest.Ignore())
            .ForMember(u => u.Id, dest => dest.Ignore());
    }
}

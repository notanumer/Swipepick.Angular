using AutoMapper;
using Swipepick.Angular.Domain;
using Swipepick.Angular.UseCases.Users.AddUser;

namespace Swipepick.Angular.UseCases;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<AddUserCommand, User>();
    }
}

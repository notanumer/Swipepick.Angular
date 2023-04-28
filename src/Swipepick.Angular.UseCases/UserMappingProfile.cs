using AutoMapper;
using Swipepick.Angular.Domain;
using Swipepick.Angular.DomainServices;

namespace Swipepick.Angular.UseCases;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserDto, User>();
    }
}

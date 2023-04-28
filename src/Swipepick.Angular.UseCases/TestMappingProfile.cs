using AutoMapper;
using Swipepick.Angular.Domain;
using Swipepick.Angular.DomainServices;

namespace Swipepick.Angular.UseCases;

public class TestMappingProfile : Profile
{
	public TestMappingProfile()
	{
		CreateMap<Test, TestDto>();
		CreateMap<Student, StudentDto>();
		CreateMap<Question, QuestionDto>()
			.ForMember(dto => dto.Question, dest => dest.MapFrom(q => q.QuestionContent));
	}
}

using AutoMapper;
using Swipepick.Angular.Domain;
using Swipepick.Angular.DomainServices;
using Swipepick.Angular.UseCases.Tests.CreateTest;

namespace Swipepick.Angular.UseCases;

public class TestMappingProfile : Profile
{
	public TestMappingProfile()
	{
		CreateMap<Test, TestDto>();

        CreateMap<Test, CreateTestDto>().ReverseMap();
		CreateMap<Student, StudentDto>().ReverseMap();
		CreateMap<Question, QuestionDto>()
			.ForMember(que => que.QuestionId, dest => dest.Ignore())
			.ReverseMap();
		CreateMap<Answer, AnswerDto>().ReverseMap();
		CreateMap<AnswerVariant, AnswerVariantDto>().ReverseMap();
	}
}

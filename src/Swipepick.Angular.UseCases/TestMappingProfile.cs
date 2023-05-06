using AutoMapper;
using Swipepick.Angular.Domain;
using Swipepick.Angular.DomainServices;
using Swipepick.Angular.UseCases.Tests.CreateTest;

namespace Swipepick.Angular.UseCases;

public class TestMappingProfile : Profile
{
	public TestMappingProfile()
	{
		CreateMap<Test, CreateTestDto>();
		CreateMap<Student, StudentDto>();
		CreateMap<Question, QuestionDto>()
			.ForMember(que => que.QuestionId, dest => dest.Ignore());
		CreateMap<Answer, AnswerDto>();
		CreateMap<AnswerVariant, AnswerVariantDto>();
	}
}

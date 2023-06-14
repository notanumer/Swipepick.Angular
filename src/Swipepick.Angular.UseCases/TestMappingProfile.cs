using AutoMapper;
using Swipepick.Angular.Domain;
using Swipepick.Angular.UseCases.Tests.CreateTest;
using Swipepick.Angular.UseCases.Tests.GetStudentStatistic;

namespace Swipepick.Angular.UseCases;

public class TestMappingProfile : Profile
{
	public TestMappingProfile()
	{
        CreateMap<Test, CreateTestDto>().ReverseMap();
        CreateMap<Question, DomainServices.QuestionDto>().ReverseMap();
        CreateMap<Answer, DomainServices.AnswerDto>().ReverseMap();
        CreateMap<AnswerVariant, DomainServices.AnswerVariantDto>().ReverseMap();

        CreateMap<Test, Tests.GetTestByCode.Dto.TestDto>().ReverseMap();
        CreateMap<Question, Tests.GetTestByCode.Dto.QuestionDto>().ReverseMap();
        CreateMap<Answer, Tests.GetTestByCode.Dto.AnswerDto>().ReverseMap();
        CreateMap<AnswerVariant, Tests.GetTestByCode.Dto.AnswerVariantDto>().ReverseMap();
        
		CreateMap<Student, Tests.GetTests.Dto.Student.StudentDto>().ReverseMap();
        CreateMap<StudentAnswer, Tests.GetTests.Dto.Student.StudentAnswerDto>().ReverseMap();
        CreateMap<StudentAnswerVariant, Tests.GetTests.Dto.Student.StudentAnswerVariantDto>().ReverseMap();

        CreateMap<Question, Tests.GetTests.Dto.Question.QuestionDto>().ReverseMap();

        CreateMap<Test, Tests.GetTests.Dto.Test.TestDto>().ReverseMap();

        CreateMap<Answer, Tests.GetTests.Dto.Answer.AnswerDto>().ReverseMap();
		CreateMap<AnswerVariant, Tests.GetTests.Dto.Answer.AnswerVariantDto>().ReverseMap();

        CreateMap<StudentAnswer, GetStudentStatisticAnswerDto>().ReverseMap();
        CreateMap<StudentAnswerVariant, GetStudentStatisticAnswerVariantDto>()
            .ForMember(src => src.IsCorrect, dest => dest.Ignore())
            .ReverseMap();
        CreateMap<Student, GetStudentStatisticDto>().ReverseMap();
    }
}

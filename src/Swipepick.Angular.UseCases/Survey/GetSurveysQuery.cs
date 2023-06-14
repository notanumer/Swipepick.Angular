using MediatR;

namespace Swipepick.Angular.UseCases.Survey;

public record GetSurveysQuery(string UserEmail) : IRequest<GetSurveysQueryResult>;

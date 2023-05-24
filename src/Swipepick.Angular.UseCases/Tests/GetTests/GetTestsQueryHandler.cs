using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Swipepick.Angular.DomainServices;
using Swipepick.Angular.Infrastructure.Abstractions.Exceptions;
using Swipepick.Angular.Infrastructure.Abstractions.Interfaces;

namespace Swipepick.Angular.UseCases.Tests.GetTests;

public class GetTestsQueryHandler : IRequestHandler<GetTestsQuery, GetTestsQueryResult>
{
    private readonly IAppDbContext appDbContext;
    private readonly IMapper mapper;

    public GetTestsQueryHandler(IAppDbContext appDbContext, IMapper mapper)
    {
        this.appDbContext = appDbContext;
        this.mapper = mapper;
    }

    public async Task<GetTestsQueryResult> Handle(GetTestsQuery request, CancellationToken cancellationToken)
    {
        var user = await appDbContext.Users
            .FirstOrDefaultAsync(u => u.Email == request.UserEmail, cancellationToken)
            ?? throw new UserNotFoundException($"User with email {request.UserEmail} not found.");

        var tests = await appDbContext.Tests
            .Where(x => x.UserId == user.Id)
            .ProjectTo<TestDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new GetTestsQueryResult() { Tests = tests };
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Swipepick.Angular.Infrastructure.Abstractions.Exceptions;
using Swipepick.Angular.Infrastructure.Abstractions.Interfaces;
using Swipepick.Angular.UseCases.Tests.GetTestByCode.Dto;

namespace Swipepick.Angular.UseCases.Tests.GetTestByCode;

public class GetTestByCodeQueryHandler : IRequestHandler<GetTestByCodeQuery, TestDto>
{
    private readonly IAppDbContext appDbContext;
    private readonly IMapper mapper;

    public GetTestByCodeQueryHandler(IMapper mapper, IAppDbContext appDbContext)
    {
        this.mapper = mapper;
        this.appDbContext = appDbContext;
    }

    public async Task<TestDto> Handle(GetTestByCodeQuery request, CancellationToken cancellationToken)
    {
        var test = await appDbContext.Tests
            .Where(test => test.UniqueCode == request.UniqueCode)
            .ProjectTo<TestDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (test == null)
        {
            throw new TestNotFoundException($"Test with code {request.UniqueCode} not found");
        }

        return test;
    }
}

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Swipepick.Angular.Domain;
using Swipepick.Angular.Infrastructure.Abstractions.Exceptions;
using Swipepick.Angular.Infrastructure.Abstractions.Interfaces;

namespace Swipepick.Angular.UseCases.Tests.CreateTest;

public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand, string>
{
    private readonly IAppDbContext dbContext;
    private readonly IMapper mapper;

    public CreateTestCommandHandler(IAppDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<string> Handle(CreateTestCommand request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.UserEmail, cancellationToken);
        if (user != null)
        {
            var test = mapper.Map<Test>(request.TestDto);
            test.UniqueCode = Guid.NewGuid().ToString().Split("-")[0];
            test.UserId = user.Id;
            test.CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
            test.UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
            dbContext.Tests.Add(test);
            await dbContext.SaveChangesAsync(cancellationToken);
            return test.UniqueCode;
        }

        throw new UserNotFoundException($"User with email {request.UserEmail} not found.");
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using Swipepick.Angular.Infrastructure.Abstractions.Exceptions;
using Swipepick.Angular.Infrastructure.Abstractions.Interfaces;

namespace Swipepick.Angular.UseCases.Tests.DeleteTest;

internal class DeleteTestCommandHandler : IRequestHandler<DeleteTestCommand>
{
    private readonly IAppDbContext appDbContext;

    public DeleteTestCommandHandler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task Handle(DeleteTestCommand request, CancellationToken cancellationToken)
    {
        var user = await appDbContext.Users
            .FirstOrDefaultAsync(u => u.Email == request.UserEmail, cancellationToken)
            ?? throw new UserNotFoundException("User not found.");

        var test = await appDbContext.Tests
            .FirstOrDefaultAsync(t => t.UniqueCode == request.Code && t.UserId == user.Id, cancellationToken)
            ?? throw new TestNotFoundException($"Test with code {request.Code} not found");

        appDbContext.Tests.Remove(test);

        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}

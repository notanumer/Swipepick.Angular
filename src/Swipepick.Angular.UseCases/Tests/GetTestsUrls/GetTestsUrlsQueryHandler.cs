using MediatR;
using Microsoft.EntityFrameworkCore;
using Swipepick.Angular.Infrastructure.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swipepick.Angular.UseCases.Tests.GetTestsUrls;

public class GetTestsUrlsQueryHandler : IRequestHandler<GetTestsUrlsQuery, IEnumerable<string>>
{
    private readonly IAppDbContext appDbContext;

    public GetTestsUrlsQueryHandler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<IEnumerable<string>> Handle(GetTestsUrlsQuery request, CancellationToken cancellationToken)
    {
        var user = await appDbContext.Users
            .FirstAsync(u => u.Email == request.UserEmail, cancellationToken);
        var testsUrls = appDbContext.Tests.Where(t => t.UserId == user.Id).Select(t => t.UniqueCode);
        return await testsUrls.ToListAsync(cancellationToken);
    }
}

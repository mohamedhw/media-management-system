using DCL.Application.Common.Interfaces;
using DCL.Application.LKPs.Models;
using DCL.Application.Media;
using MediatR;

namespace DCL.Application.Queries;

public class GetLKP : IRequest<List<GetLKPDto>>
{
    public string LKPName { get; init; } = string.Empty;
}

public class GetLKPHandler : IRequestHandler<GetLKP, List<GetLKPDto>>
{
    private readonly IApplicationDbContext _context;

    public GetLKPHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetLKPDto>> Handle(GetLKP request, CancellationToken cancellationToken)
    {
        var result = new List<GetLKPDto>();
        switch (request.LKPName)
        {
            case "MediaTypes":
                result = await _context
                    .MediaTypes.Select(mt => new GetLKPDto { Id = mt.Id, Name = mt.Name })
                    .ToListAsync(cancellationToken);
                break;
            case "AgeRatings":
                result = await _context
                    .AgeRatings.Select(ar => new GetLKPDto { Id = ar.Id, Name = ar.Name })
                    .ToListAsync(cancellationToken);
                break;
            case "Genres":
                result = await _context
                    .Genres.Select(g => new GetLKPDto { Id = g.Id, Name = g.Name })
                    .ToListAsync(cancellationToken);
                break;
            case "Actors":
                result = await _context
                    .Actors.Select(g => new GetLKPDto { Id = g.Id, Name = g.Name })
                    .ToListAsync(cancellationToken);
                break;
            case "Tags":
                result = await _context
                    .Tags.Select(t => new GetLKPDto { Id = t.Id, Name = t.Name })
                    .ToListAsync(cancellationToken);
                break;
            case "Country":
                result = await _context
                    .Countries.Select(t => new GetLKPDto { Id = t.Id, Name = t.Name })
                    .ToListAsync(cancellationToken);
                break;
            case "IsAdult":
                result = await _context
                    .IsAdults.Select(t => new GetLKPDto { Id = t.Id, Name = t.Name })
                    .ToListAsync(cancellationToken);
                break;
            case "Gender":
                result = await _context
                    .Genders.Select(t => new GetLKPDto { Id = t.Id, Name = t.Name })
                    .ToListAsync(cancellationToken);
                break;
            default:
                throw new ArgumentException($"Unsupported LKP name: {request.LKPName}");
        }
        return result;
    }
}

using DCL.Application.Actors.Models;
using MediatR;

namespace DCL.Application.Actors.Queries;

// List with optional name filter
public record GetActorsQuery(string? Name = null) : IRequest<List<GetActorDto>>;

public class GetActorsQueryHandler : IRequestHandler<GetActorsQuery, List<GetActorDto>>
{
    private readonly IApplicationDbContext _context;

    public GetActorsQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<List<GetActorDto>> Handle(GetActorsQuery request, CancellationToken ct)
    {
        var query = _context.Actors.Include(a => a.Tags).ThenInclude(t => t.Tag).AsQueryable();

        if (!string.IsNullOrEmpty(request.Name))
            query = query.Where(a => a.Name.Contains(request.Name));

        return await query
            .Select(a => new GetActorDto
            {
                Id = a.Id,
                Name = a.Name,
                OriginalName = a.OriginalName,
                CountryId = a.CountryId,
                DateOfBirth = a.DateOfBirth,
                BloodType = a.BloodType,
                Height = a.Height,
                Weight = a.Weight,
                BreastSize = a.BreastSize,
                WaistSize = a.WaistSize,
                HipsSize = a.HipsSize,
                CupSize = a.CupSize,
                ProfileImagePath = a.ProfileImagePath,
                Notes = a.Notes,
                Tags = a.Tags.Select(t => t.Tag.Name).ToList(),
                Biography = a.Biography,
                GenderId = a.GenderId,
                IsAdultsId = a.IsAdultsId,
                IMDB = a.IMDB,
                Instgram = a.Instgram,
                Twiter = a.Twiter,
                Facebook = a.Facebook,
                Riddet = a.Riddet,
                Website = a.Website,
            })
            .ToListAsync(ct);
    }
}

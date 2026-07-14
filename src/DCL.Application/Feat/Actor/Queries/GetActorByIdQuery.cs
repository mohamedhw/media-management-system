using DCL.Application.Actors.Models;
using MediatR;

namespace DCL.Application.Actors.Queries;

public record GetActorByIdQuery(long Id) : IRequest<GetActorDto>;

public class GetActorByIdQueryHandler : IRequestHandler<GetActorByIdQuery, GetActorDto>
{
    private readonly IApplicationDbContext _context;

    public GetActorByIdQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<GetActorDto> Handle(GetActorByIdQuery request, CancellationToken ct)
    {
        var actor =
            await _context
                .Actors.Include(c => c.Country)
                .Include(a => a.Tags)
                    .ThenInclude(t => t.Tag)
                .Where(a => a.Id == request.Id)
                .Select(a => new GetActorDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    GenderId = a.GenderId,
                    OriginalName = a.OriginalName,

                    CountryId = a.CountryId,
                    CountryName = a.Country != null ? a.Country.Name : null,

                    DateOfBirth = a.DateOfBirth,
                    BloodType = a.BloodType,

                    Height = a.Height,
                    Weight = a.Weight,

                    BreastSize = a.BreastSize,
                    WaistSize = a.WaistSize,
                    HipsSize = a.HipsSize,
                    CupSize = a.CupSize,

                    ProfileImagePath = a.ProfileImagePath,

                    Biography = a.Biography,
                    Notes = a.Notes,

                    IMDB = a.IMDB,
                    Instgram = a.Instgram,
                    Twiter = a.Twiter,
                    Facebook = a.Facebook,
                    Riddet = a.Riddet,
                    Website = a.Website,

                    IsAdultsId = a.IsAdultsId,

                    Tags = a.Tags.Select(t => t.Tag.Name).ToList(),
                })
                .FirstOrDefaultAsync(ct)
            ?? throw new NotFoundException(nameof(Actor), request.Id);

        return actor;
    }
}

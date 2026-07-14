using DCL.Application.Actors.Models;
using MediatR;

namespace DCL.Application.Actors.Commands;

public record CreateActorCommand : IRequest<long>
{
    public CreateActorDto Data { get; init; } = null!;
}

public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, long>
{
    private readonly IApplicationDbContext _context;
    private readonly IFileStorageService _fileStorage;

    public CreateActorCommandHandler(IApplicationDbContext context, IFileStorageService fileStorage)
    {
        _context = context;
        _fileStorage = fileStorage;
    }

    public async Task<long> Handle(CreateActorCommand request, CancellationToken ct)
    {
        string? imagePath = null;

        if (request.Data.ProfileImage != null)
        {
            using var stream = request.Data.ProfileImage.OpenReadStream();

            imagePath = await _fileStorage.SaveAsync(
                stream,
                request.Data.ProfileImage.FileName,
                "profile_images"
            );
        }

        var actor = new Actor
        {
            Name = request.Data.Name.Trim(),
            GenderId = request.Data.GenderId,
            OriginalName = request.Data.OriginalName,
            CountryId = request.Data.CountryId,
            DateOfBirth = request.Data.DateOfBirth,

            BloodType = request.Data.BloodType,
            Height = request.Data.Height,
            Weight = request.Data.Weight,

            Measurements = request.Data.Measurements,

            BreastSize = request.Data.BreastSize,
            WaistSize = request.Data.WaistSize,
            HipsSize = request.Data.HipsSize,
            CupSize = request.Data.CupSize,

            ProfileImagePath = imagePath,

            Biography = request.Data.Biography,
            Notes = request.Data.Notes,

            IMDB = request.Data.IMDB,
            Instgram = request.Data.Instgram,
            Twiter = request.Data.Twiter,
            Facebook = request.Data.Facebook,
            Riddet = request.Data.Riddet,
            Website = request.Data.Website,

            IsAdultsId = request.Data.IsAdultsId,
        };

        _context.Actors.Add(actor);
        await _context.SaveChangesAsync(ct);

        if (request.Data.TagIds?.Any() == true)
        {
            foreach (var tagId in request.Data.TagIds)
            {
                _context.ActorTags.Add(new ActorTag { ActorId = actor.Id, TagId = tagId });
            }

            await _context.SaveChangesAsync(ct);
        }

        return actor.Id;
    }
}

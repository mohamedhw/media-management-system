using DCL.Application.Actors.Models;
using DCL.Application.Common.Exceptions;
using DCL.Application.Common.Interfaces;
using DCL.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DCL.Application.Actors.Commands;

public record UpdateActorCommand : IRequest
{
    public UpdateActorDto Data { get; init; } = null!;
}

public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IFileStorageService _fileStorage;

    public UpdateActorCommandHandler(IApplicationDbContext context, IFileStorageService fileStorage)
    {
        _context = context;
        _fileStorage = fileStorage;
    }

    public async Task Handle(UpdateActorCommand request, CancellationToken ct)
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

        var actor =
            await _context
                .Actors.Include(a => a.Tags)
                .FirstOrDefaultAsync(a => a.Id == request.Data.Id, ct)
            ?? throw new NotFoundException(nameof(Actor), request.Data.Id);

        actor.Name = request.Data.Name.Trim();
        actor.OriginalName = request.Data.OriginalName;
        actor.CountryId = request.Data.CountryId;
        actor.GenderId = request.Data.GenderId;
        actor.IsAdultsId = request.Data.IsAdultsId;
        actor.DateOfBirth = request.Data.DateOfBirth;
        actor.BloodType = request.Data.BloodType;
        actor.Height = request.Data.Height;
        actor.Weight = request.Data.Weight;
        actor.Measurements = request.Data.Measurements;
        actor.BreastSize = request.Data.BreastSize;
        actor.WaistSize = request.Data.WaistSize;
        actor.HipsSize = request.Data.HipsSize;
        actor.CupSize = request.Data.CupSize;
        actor.ProfileImagePath = request.Data.ProfileImagePath;
        actor.Biography = request.Data.Biography;
        actor.Notes = request.Data.Notes;
        actor.IMDB = request.Data.IMDB;
        actor.Instgram = request.Data.Instgram;
        actor.Twiter = request.Data.Twiter;
        actor.Facebook = request.Data.Facebook;
        actor.Riddet = request.Data.Riddet;
        actor.Website = request.Data.Website;

        // sync tags
        // var currentTagIds = actor.Tags.Select(t => t.TagId).ToHashSet();
        var requestedTagIds = request.Data.TagIds ?? [];

        var currentTagIds = actor.Tags.Select(t => t.TagId).ToHashSet();

        var toAdd = requestedTagIds.Except(currentTagIds).ToList();
        var toRemove = currentTagIds.Except(requestedTagIds).ToList();

        if (toRemove.Any())
            _context.ActorTags.RemoveRange(actor.Tags.Where(t => toRemove.Contains(t.TagId)));

        foreach (var tagId in toAdd)
            _context.ActorTags.Add(new ActorTag { ActorId = actor.Id, TagId = tagId });

        await _context.SaveChangesAsync(ct);
    }
}

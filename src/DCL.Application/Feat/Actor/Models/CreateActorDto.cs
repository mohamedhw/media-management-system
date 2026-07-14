using Microsoft.AspNetCore.Http;

namespace DCL.Application.Actors.Models;

public record CreateActorDto(
    string Name,
    int? GenderId,
    string? OriginalName,
    int? CountryId,
    DateOnly? DateOfBirth,
    string? BloodType,
    string? Height,
    string? Weight,
    string? Measurements,
    string? BreastSize,
    string? WaistSize,
    string? HipsSize,
    string? CupSize,
    string? ProfileImagePath,
    IFormFile? ProfileImage,
    string? Biography,
    string? Notes,
    string? IMDB,
    string? Instgram,
    string? Twiter,
    string? Facebook,
    string? Riddet,
    string? Website,
    int? IsAdultsId,
    List<long> TagIds
);

using Microsoft.AspNetCore.Http;

namespace DCL.Application.Actors.Models;

public record UpdateActorDto(
    long Id,
    string Name,
    int? GenderId,
    string? OriginalName,
    int? CountryId,
    DateOnly? DateOfBirth,
    string? BloodType,
    string? Measurements,
    string? Height,
    string? Weight,
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
    List<long>? TagIds = null
);

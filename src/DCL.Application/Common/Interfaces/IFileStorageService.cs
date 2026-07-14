using DCL.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DCL.Application.Common.Interfaces;

public interface IFileStorageService
{
    Task<string> SaveAsync(Stream fileStream, string fileName, string folder);
}

using DCL.Application.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace DCL.Infrastructure.Persistence;

public class FileStorageService : IFileStorageService
{
    private readonly IWebHostEnvironment _env;

    public FileStorageService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task<string> SaveAsync(Stream fileStream, string fileName, string folder)
    {
        var uploadsPath = Path.Combine(_env.WebRootPath, folder);

        if (!Directory.Exists(uploadsPath))
            Directory.CreateDirectory(uploadsPath);

        var safeName = $"{Guid.NewGuid()}_{fileName}";
        var fullPath = Path.Combine(uploadsPath, safeName);

        using var stream = new FileStream(fullPath, FileMode.Create);
        await fileStream.CopyToAsync(stream);

        return Path.Combine(folder, safeName).Replace("\\", "/");
    }
}

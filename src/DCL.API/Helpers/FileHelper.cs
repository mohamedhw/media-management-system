using Microsoft.AspNetCore.Http;

public static class FileHelper
{
    public static async Task<byte[]?> ToByteArrayAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return null;

        using var ms = new MemoryStream();
        await file.CopyToAsync(ms);
        return ms.ToArray();
    }

    public static async Task<string?> SaveFileAsync(
        IFormFile file,
        string rootPath,
        string folder = "uploads",
        bool useUniqueName = true
    )
    {
        if (file == null || file.Length == 0)
            return null;

        var uploadPath = Path.Combine(rootPath, folder);

        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        var extension = Path.GetExtension(file.FileName);
        var fileName = useUniqueName
            ? $"{Guid.NewGuid()}{extension}"
            : Path.GetFileName(file.FileName);

        var fullPath = Path.Combine(uploadPath, fileName);

        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return fileName;
    }
}

using DCL.Application.MediaFiles;
using MediatR;

namespace DCL.Application.MediaFiles.Commands;

public record AddMediaFileBatchCommand : IRequest<List<GetMediaFileDto>>
{
    public long MediaId { get; init; }
    public long StorageDeviceId { get; init; }
    public long FileFormatId { get; init; }
    public string BaseFilePath { get; init; } = string.Empty; // shared directory for all files

    public List<AddImageFileItemDto> Images { get; init; } = [];
}

/// <summary>
/// One image in a batch insert. Path here is relative to BaseFilePath.
/// </summary>
public class AddImageFileItemDto
{
    public string FileName { get; set; } = string.Empty;
    public long? FileSize { get; set; }
    public bool IsPrimary { get; set; }
    public string? Notes { get; set; }

    public int? Width { get; set; }
    public int? Height { get; set; }
    public double? BitDepth { get; set; }
    public string? ColorSpace { get; set; }
    public bool HasAlpha { get; set; }
}

using DCL.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DCL.Application.MediaFiles.Queries;

public class GetMediaFilesQuery : IRequest<List<GetMediaFileDto>>
{
    public long MediaId { get; init; }
}

public class GetMediaFilesQueryHandler : IRequestHandler<GetMediaFilesQuery, List<GetMediaFileDto>>
{
    private readonly IApplicationDbContext _context;

    public GetMediaFilesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetMediaFileDto>> Handle(
        GetMediaFilesQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _context
            .MediaFiles.Where(f => f.MediaId == request.MediaId)
            .Select(f => new GetMediaFileDto
            {
                Id = f.Id,
                MediaId = f.MediaId,
                StorageDevice = f.StorageDevice.Name,
                FileFormat = f.FileFormat.Name,
                FilePath = f.FilePath,
                FileName = f.FileName,
                FileSize = f.FileSize,
                IsPrimary = f.IsPrimary,
                Notes = f.Notes,
                VideoDetail =
                    f.VideoDetail == null
                        ? null
                        : new GetVideoDetailDto
                        {
                            Quality =
                                f.VideoDetail.Quality != null ? f.VideoDetail.Quality.Name : null,
                            ScanType =
                                f.VideoDetail.ScanType != null ? f.VideoDetail.ScanType.Name : null,
                            FrameRateMode =
                                f.VideoDetail.FrameRateMode != null
                                    ? f.VideoDetail.FrameRateMode.Name
                                    : null,
                            BitRate = f.VideoDetail.BitRate,
                            FrameRate = f.VideoDetail.FrameRate,
                            BitsPerPixelFrame = f.VideoDetail.BitsPerPixelFrame,
                            BitDepth = f.VideoDetail.BitDepth,
                            ReferenceFrame = f.VideoDetail.ReferenceFrame,
                            Duration = f.VideoDetail.Duration,
                        },
                ImageDetail =
                    f.ImageDetail == null
                        ? null
                        : new GetImageDetailDto
                        {
                            Width = f.ImageDetail.Width,
                            Height = f.ImageDetail.Height,
                            BitDepth = f.ImageDetail.BitDepth,
                            ColorSpace = f.ImageDetail.ColorSpace,
                            HasAlpha = f.ImageDetail.HasAlpha,
                        },
            })
            .ToListAsync(cancellationToken);
    }
}

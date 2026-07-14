using DCL.Application.Common.Exceptions;
using DCL.Application.Common.Interfaces;
using DCL.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DCL.Application.MediaFiles.Commands;

public class AddMediaFileCommandHandler : IRequestHandler<AddMediaFileCommand, GetMediaFileDto>
{
    private readonly IApplicationDbContext _context;

    public AddMediaFileCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GetMediaFileDto> Handle(
        AddMediaFileCommand request,
        CancellationToken cancellationToken
    )
    {
        var dto = request.File;

        // Validate the media exists
        var mediaExists = await _context.Media.AnyAsync(
            m => m.Id == dto.MediaId,
            cancellationToken
        );
        if (!mediaExists)
            throw new NotFoundException(nameof(Media), dto.MediaId);

        // Validate the storage device exists
        var storageExists = await _context.StorageDevices.AnyAsync(
            s => s.Id == dto.StorageDeviceId,
            cancellationToken
        );
        if (!storageExists)
            throw new NotFoundException(nameof(StorageDevice), dto.StorageDeviceId);

        // If this file is marked primary, demote any existing primary for this media
        if (dto.IsPrimary)
        {
            var currentPrimary = await _context
                .MediaFiles.Where(f => f.MediaId == dto.MediaId && f.IsPrimary)
                .ToListAsync(cancellationToken);

            foreach (var f in currentPrimary)
                f.IsPrimary = false;
        }

        var mediaFile = new MediaFile
        {
            MediaId = dto.MediaId,
            StorageDeviceId = dto.StorageDeviceId,
            FileFormatId = dto.FileFormatId,
            FilePath = dto.FilePath,
            FileName = dto.FileName,
            FileSize = dto.FileSize,
            IsPrimary = dto.IsPrimary,
            Notes = dto.Notes,
        };

        if (dto.VideoDetail != null)
        {
            mediaFile.VideoDetail = new VideoFileDetail
            {
                QualityId = dto.VideoDetail.QualityId,
                ScanTypeId = dto.VideoDetail.ScanTypeId,
                FrameRateModeId = dto.VideoDetail.FrameRateModeId,
                BitRate = dto.VideoDetail.BitRate,
                FrameRate = dto.VideoDetail.FrameRate,
                BitsPerPixelFrame = dto.VideoDetail.BitsPerPixelFrame,
                BitDepth = dto.VideoDetail.BitDepth,
                ReferenceFrame = dto.VideoDetail.ReferenceFrame,
                Duration = dto.VideoDetail.Duration,
            };
        }
        else if (dto.ImageDetail != null)
        {
            mediaFile.ImageDetail = new ImageFileDetail
            {
                Width = dto.ImageDetail.Width,
                Height = dto.ImageDetail.Height,
                BitDepth = dto.ImageDetail.BitDepth,
                ColorSpace = dto.ImageDetail.ColorSpace,
                HasAlpha = dto.ImageDetail.HasAlpha,
            };
        }

        _context.MediaFiles.Add(mediaFile);
        await _context.SaveChangesAsync(cancellationToken);

        return await ProjectToDto(mediaFile.Id, cancellationToken);
    }

    private async Task<GetMediaFileDto> ProjectToDto(long id, CancellationToken ct)
    {
        return await _context
                .MediaFiles.Where(f => f.Id == id)
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
                                    f.VideoDetail.Quality != null
                                        ? f.VideoDetail.Quality.Name
                                        : null,
                                ScanType =
                                    f.VideoDetail.ScanType != null
                                        ? f.VideoDetail.ScanType.Name
                                        : null,
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
                .FirstOrDefaultAsync(ct)
            ?? throw new NotFoundException(nameof(MediaFile), id);
    }
}

using DCL.Application.Common.Exceptions;
using DCL.Application.Common.Interfaces;
using DCL.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DCL.Application.MediaFiles.Commands;

public class AddMediaFileBatchCommandHandler
    : IRequestHandler<AddMediaFileBatchCommand, List<GetMediaFileDto>>
{
    private readonly IApplicationDbContext _context;

    public AddMediaFileBatchCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetMediaFileDto>> Handle(
        AddMediaFileBatchCommand request,
        CancellationToken cancellationToken
    )
    {
        var mediaExists = await _context.Media.AnyAsync(
            m => m.Id == request.MediaId,
            cancellationToken
        );
        if (!mediaExists)
            throw new NotFoundException(nameof(Media), request.MediaId);

        var storageExists = await _context.StorageDevices.AnyAsync(
            s => s.Id == request.StorageDeviceId,
            cancellationToken
        );
        if (!storageExists)
            throw new NotFoundException(nameof(StorageDevice), request.StorageDeviceId);

        // If any incoming file is marked primary, demote the existing one first
        bool anyPrimary = request.Images.Any(i => i.IsPrimary);
        if (anyPrimary)
        {
            var currentPrimary = await _context
                .MediaFiles.Where(f => f.MediaId == request.MediaId && f.IsPrimary)
                .ToListAsync(cancellationToken);

            foreach (var f in currentPrimary)
                f.IsPrimary = false;
        }

        var files = request
            .Images.Select(img => new MediaFile
            {
                MediaId = request.MediaId,
                StorageDeviceId = request.StorageDeviceId,
                FileFormatId = request.FileFormatId,
                FilePath = request.BaseFilePath,
                FileName = img.FileName,
                FileSize = img.FileSize,
                IsPrimary = img.IsPrimary,
                Notes = img.Notes,
                ImageDetail = new ImageFileDetail
                {
                    Width = img.Width,
                    Height = img.Height,
                    BitDepth = img.BitDepth,
                    ColorSpace = img.ColorSpace,
                    HasAlpha = img.HasAlpha,
                },
            })
            .ToList();

        _context.MediaFiles.AddRange(files);
        await _context.SaveChangesAsync(cancellationToken);

        var insertedIds = files.Select(f => f.Id).ToList();

        return await _context
            .MediaFiles.Where(f => insertedIds.Contains(f.Id))
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

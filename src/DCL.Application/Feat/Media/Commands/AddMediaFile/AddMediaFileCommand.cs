using DCL.Application.MediaFiles;
using MediatR;

namespace DCL.Application.MediaFiles.Commands;

public record AddMediaFileCommand : IRequest<GetMediaFileDto>
{
    public AddMediaFileDto File { get; init; } = null!;
}

using MediatR;

namespace DCL.Application.Media.Commands.CreateMedia;

public record UpdateMediaCommand : IRequest<GetMediaDetailDto>
{
    public UpdateMediaDto Media { get; set; } = null!;
}

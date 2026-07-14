using MediatR;

namespace DCL.Application.Actors.Commands;

public record DeleteActorCommand(long Id) : IRequest;

public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteActorCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task Handle(DeleteActorCommand request, CancellationToken ct)
    {
        var actor =
            await _context.Actors.FindAsync([request.Id], ct)
            ?? throw new NotFoundException(nameof(Actors), request.Id);

        _context.Actors.Remove(actor);
        await _context.SaveChangesAsync(ct);
    }
}

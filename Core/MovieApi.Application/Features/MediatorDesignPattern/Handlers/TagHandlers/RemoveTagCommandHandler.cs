using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class RemoveTagCommandHandler : IRequestHandler<RemoveCastCommand>
    {
        private readonly MovieContext _context;
        public RemoveTagCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Tags.FindAsync(request.CastId);
            _context.Tags.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}

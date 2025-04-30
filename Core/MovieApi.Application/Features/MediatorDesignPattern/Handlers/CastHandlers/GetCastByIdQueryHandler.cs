using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _context;
        public GetCastByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Casts.FindAsync(request.CastId);
            return new GetCastByIdQueryResult
            {
                CastId = value.CastId,
                Title = value.Title,
                Name = value.Name,
                Surname = value.Surname,
                ImageUrl = value.ImageUrl,
                Overview = value.Overview,
                Biography = value.Biography
            };
        }
    }
}

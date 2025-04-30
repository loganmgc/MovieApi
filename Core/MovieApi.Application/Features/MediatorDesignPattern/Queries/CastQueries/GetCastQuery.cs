using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries
{
    public class GetCastQuery : IRequest<List<GetCastQueryResult>>
    {
        public GetCastQuery(int castId)
        {
            CastId = castId;
        }
        public int CastId { get; set; }
    }
}

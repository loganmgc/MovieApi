using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries
{
    public class GetTagQuery : IRequest<List<GetTagQueryResult>>
    {
        public GetTagQuery(int tagId)
        {
            TagId = tagId;
        }
        public int TagId { get; set; }
    }
}

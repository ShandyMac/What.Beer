using MediatR;

namespace What.Beer.Queries.GetBeer
{
    public class GetBeerQuery : IRequest<GetBeerQueryResponse>
    {
        public string Id { get; set; }
    }
}

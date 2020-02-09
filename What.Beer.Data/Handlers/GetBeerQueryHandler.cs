using MediatR;
using System.Threading;
using System.Threading.Tasks;
using What.Beer.Data.Repositories;
using What.Beer.Queries.GetBeer;

namespace What.Beer.Data.Handlers
{
    public class GetBeerQueryHandler : IRequestHandler<GetBeerQuery, GetBeerQueryResponse>
    {
        private readonly IBeerRepository beerRepository;

        public GetBeerQueryHandler(IBeerRepository beerRepository) 
        {
            this.beerRepository = beerRepository;
        }

        public async Task<GetBeerQueryResponse> Handle(GetBeerQuery request, CancellationToken cancellationToken)
        {
            var result = await this.beerRepository.FindById(request.Id);
            return new GetBeerQueryResponse { Beer = result };
        }
    }
}

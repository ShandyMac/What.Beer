using MediatR;
using System.Threading;
using System.Threading.Tasks;
using What.Beer.Data.Repositories;
using What.Beer.Queries.GetBeer;

namespace What.Beer.Data.Handlers
{
    /// <summary>
    /// The <see cref="GetBeerQueryHandler"/> class.
    /// </summary>
    public class GetBeerQueryHandler : IRequestHandler<GetBeerQuery, GetBeerQueryResponse>
    {
        /// <summary>
        /// The beer repository.
        /// </summary>
        private readonly IBeerRepository beerRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="GetBeerQueryHandler"/> class.
        /// </summary>
        /// <param name="beerRepository">The beer repository.</param>
        public GetBeerQueryHandler(IBeerRepository beerRepository) 
        {
            this.beerRepository = beerRepository;
        }

        /// <summary>
        /// Handle the query request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="GetBeerQueryResponse"/></returns>
        public async Task<GetBeerQueryResponse> Handle(GetBeerQuery request, CancellationToken cancellationToken)
        {
            var result = await this.beerRepository.FindById(request.Id);
            return new GetBeerQueryResponse { Beer = result };
        }
    }
}

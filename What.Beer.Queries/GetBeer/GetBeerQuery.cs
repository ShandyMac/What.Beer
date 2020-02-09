using MediatR;

namespace What.Beer.Queries.GetBeer
{
    /// <summary>
    /// The <see cref="GetBeerQuery"/> class.
    /// </summary>
    public class GetBeerQuery : IRequest<GetBeerQueryResponse>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }
    }
}

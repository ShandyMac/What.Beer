using MediatR;
using System.Threading;
using System.Threading.Tasks;
using What.Beer.Commands.SaveBeer;
using What.Beer.Data.Repositories;

namespace What.Beer.Data.Handlers
{
    /// <summary>
    /// The <see cref="SaveBeerCommandHandler"/> class.
    /// </summary>
    public class SaveBeerCommandHandler : AsyncRequestHandler<SaveBeerCommand>
    {
        /// <summary>
        /// The beer repository.
        /// </summary>
        private readonly IBeerRepository beerRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="SaveBeerCommandHandler"/>
        /// </summary>
        /// <param name="beerRepository">The beer repository.</param>
        public SaveBeerCommandHandler(IBeerRepository beerRepository)
        {
            this.beerRepository = beerRepository;
        }

        /// <summary>
        /// Handle the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="Task"/></returns>
        protected override async Task Handle(SaveBeerCommand command, CancellationToken cancellationToken)
        {
            await this.beerRepository.SaveOrUpdate(command.ToSave);
        }
    }
}

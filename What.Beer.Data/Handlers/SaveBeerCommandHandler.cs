using MediatR;
using System.Threading;
using System.Threading.Tasks;
using What.Beer.Commands.SaveBeer;
using What.Beer.Data.Repositories;

namespace What.Beer.Data.Handlers
{
    public class SaveBeerCommandHandler : AsyncRequestHandler<SaveBeerCommand>
    {
        private readonly IBeerRepository beerRepository;

        public SaveBeerCommandHandler(IBeerRepository beerRepository)
        {
            this.beerRepository = beerRepository;
        }

        protected override async Task Handle(SaveBeerCommand request, CancellationToken cancellationToken)
        {
            await this.beerRepository.SaveOrUpdate(request.ToSave);
        }
    }
}

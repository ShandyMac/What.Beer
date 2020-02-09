using MediatR;

namespace What.Beer.Commands.SaveBeer
{
    public class SaveBeerCommand : IRequest
    {
        public Common.Domain.Beer ToSave { get; set; }
    }
}

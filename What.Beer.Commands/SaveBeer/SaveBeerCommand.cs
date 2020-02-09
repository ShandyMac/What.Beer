using MediatR;

namespace What.Beer.Commands.SaveBeer
{
    /// <summary>
    /// The <see cref="SaveBeerCommand"/> class.
    /// </summary>
    public class SaveBeerCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the beer to save.
        /// </summary>
        public Common.Domain.Beer ToSave { get; set; }
    }
}

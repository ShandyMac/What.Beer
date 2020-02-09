using Microsoft.AspNetCore.Mvc;
using What.Beer.Commands.SaveBeer;
using What.Beer.Queries.GetBeer;
using What.Beer.Transport;

namespace What.Beer.Integration.Rest.Controllers
{
    /// <summary>
    /// The <see cref="BeerController"/>
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BeerController : ControllerBase
    {
        /// <summary>
        /// The message bus.
        /// </summary>
        private readonly IMessageBus messageBus;

        /// <summary>
        /// Initializes a new instance of <see cref="BeerController"/>
        /// </summary>
        /// <param name="messageBus"></param>
        public BeerController(IMessageBus messageBus)
        {
            this.messageBus = messageBus;
        }

        /// <summary>
        /// Get a beer by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="IActionResult"/></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            var query = new GetBeerQuery { Id = id };
            return Ok(this.messageBus.SendQuery(query));
        }

        /// <summary>
        /// Save a beer.
        /// </summary>
        /// <param name="beer">The beer.</param>
        /// <returns>The <see cref="IActionResult"/></returns>
        [HttpPost]
        public IActionResult Save(Common.Domain.Beer beer) 
        {
            var command = new SaveBeerCommand
            {
                ToSave = beer
            };

            return Ok(this.messageBus.SendCommand(command));
        }
    }
}
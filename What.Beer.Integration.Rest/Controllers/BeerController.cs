using Microsoft.AspNetCore.Mvc;
using What.Beer.Commands.SaveBeer;
using What.Beer.Queries.GetBeer;
using What.Beer.Transport;

namespace What.Beer.Integration.Rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerController : ControllerBase
    {
        private readonly IMessageBus messageBus;

        public BeerController(IMessageBus messageBus)
        {
            this.messageBus = messageBus;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            var query = new GetBeerQuery { Id = id };
            return Ok(this.messageBus.SendQuery(query));
        }

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
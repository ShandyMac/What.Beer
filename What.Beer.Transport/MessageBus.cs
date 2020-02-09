using MediatR;
using System;
using System.Threading.Tasks;

namespace What.Beer.Transport
{
    /// <summary>
    /// The <see cref="MessageBus"/> class.
    /// </summary>
    class MessageBus : IMessageBus
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediatr;

        /// <summary>
        /// Initializes a new instance of <see cref="MessageBus"/>
        /// </summary>
        /// <param name="mediatr"></param>
        public MessageBus(IMediator mediatr) 
        {
            this.mediatr = mediatr;
        }

        /// <summary>
        /// Send the query.
        /// </summary>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>The <see cref="{TResponse}"/></returns>
        public async Task<TResponse> SendQuery<TResponse>(IRequest<TResponse> query)
        {
            return await this.TrySend(this.mediatr.Send(query));
        }

        /// <summary>
        /// Send a command.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task SendCommand(IRequest request)
        {
            var action = this.mediatr.Send(request);
            await this.TrySend(action);
        }

        /// <summary>
        /// Try and send a request through the mediator.
        /// </summary>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <param name="action">The action to perform.</param>
        /// <returns>The <see cref="Task"/></returns>
        private async Task<TResponse> TrySend<TResponse>(Task<TResponse> action)
        {
            try
            {
                return await action;
            }
            catch (AggregateException aggregateException)
            {
                foreach (var exception in aggregateException.InnerExceptions)
                {
                    // further exception handling here...
                }

                throw aggregateException;
            }
        }
    }
}

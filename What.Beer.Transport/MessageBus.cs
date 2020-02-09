using MediatR;
using System;
using System.Threading.Tasks;

namespace What.Beer.Transport
{
    class MessageBus : IMessageBus
    {
        private readonly IMediator mediatr;

        public MessageBus(IMediator mediatr) 
        {
            this.mediatr = mediatr;
        }

        public async Task SendCommand(IRequest request)
        {
            var action = this.mediatr.Send(request);
            await this.TrySend(action);
        }

        public async Task<TResponse> SendQuery<TResponse>(IRequest<TResponse> query)
        {
            return await this.TrySend(this.mediatr.Send(query));
        }

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

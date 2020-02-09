using MediatR;
using System.Threading.Tasks;

namespace What.Beer.Transport
{
    /// <summary>
    /// The <see cref="IMessageBus"/> interface.
    /// </summary>
    public interface IMessageBus
    {
        /// <summary>
        /// Send the query.
        /// </summary>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>The <see cref="{TResponse}"/></returns>
        Task<TResponse> SendQuery<TResponse>(IRequest<TResponse> query);

        /// <summary>
        /// Send a command.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="Task"/></returns>
        Task SendCommand(IRequest request);
    }
}

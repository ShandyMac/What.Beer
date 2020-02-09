using MediatR;
using System.Threading.Tasks;

namespace What.Beer.Transport
{
    public interface IMessageBus
    {
        Task<TResponse> SendQuery<TResponse>(IRequest<TResponse> query);

        Task SendCommand(IRequest request);
    }
}

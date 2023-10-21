using MediatR;

namespace DotNetStarter.Bridges
{
    public class MediatorHangfireBridge
    {
        private readonly IMediator _mediator;

        public MediatorHangfireBridge(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Send(IRequest request)
        {
            await _mediator.Send(request);
        }

        public async Task Publish(INotification notification)
        {
            await _mediator.Publish(notification);
        }
    }
}

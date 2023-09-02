using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetStarter.Common
{
    public abstract class BaseRequestHandler<TRequest> : IRequestHandler<TRequest>
        where TRequest : IRequest
    {
        private IServiceProvider _serviceProvider { get; }

        public BaseRequestHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Handle(TRequest request, CancellationToken cancellationToken)
        {
            var validator = _serviceProvider.GetService<IValidator<TRequest>>();

            if (validator != null)
            {
                await validator.ValidateAndThrowAsync(request);
            }

            await Process(request, cancellationToken);
        }

        public abstract Task Process(TRequest request, CancellationToken cancellationToken);
    }

    public abstract class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private IServiceProvider _serviceProvider { get; }

        public BaseRequestHandler(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var validator = _serviceProvider.GetService<IValidator<TRequest>>();

            if (validator != null)
            {
                await validator.ValidateAndThrowAsync(request);
            }

            return await Process(request, cancellationToken);
        }

        public abstract Task<TResponse> Process(TRequest request, CancellationToken cancellationToken);
    }
}

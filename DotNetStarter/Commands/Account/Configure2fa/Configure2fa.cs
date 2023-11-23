using MediatR;

namespace DotNetStarter.Commands.Account.Configure2fa
{
    public sealed class Configure2fa : IRequest<Configure2faResponse>
    {
        public Guid UserId { get; }

        public bool Is2faEnabled { get; }

        public Configure2fa
        (
            Guid userId,
            bool is2faEnabled
        ) 
        {
            UserId = userId;
            Is2faEnabled = is2faEnabled;
        }
    }
}

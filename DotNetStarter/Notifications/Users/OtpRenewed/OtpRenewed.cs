using MediatR;

namespace DotNetStarter.Notifications.Users.SentOtp
{
    public sealed class OtpRenewed : INotification
    {
        public string Email { get; }

        public string Firstname { get; }

        public string Code { get; }

        public OtpRenewed(string email, string firstname, string code)
        {
            Email = email;
            Firstname = firstname;
            Code = code;
        }
    }
}

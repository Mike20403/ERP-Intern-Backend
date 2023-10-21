using DotNetStarter.Common.Enums;
using MediatR;

namespace DotNetStarter.Commands.Invitations.RegisterTalent
{
    public sealed class RegisterTalent : IRequest
    {
        public Guid InvitationId { get; }

        public string Code { get; }

        public string Username { get; }

        public string Password { get; }

        public string? Firstname { get; }

        public string? Lastname { get; }

        public string? PhoneNumber { get;}

        public Gender Gender { get; }

        public RegisterTalent(
            Guid invitationId,
            string code, 
            string username, 
            string password, 
            string firstname,
            string lastname,
            string phoneNumber,
            Gender gender
        ) 
        { 
            InvitationId = invitationId;
            Code = code;
            Username = username;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
            PhoneNumber = phoneNumber;
            Gender = gender;
        }
    }
}

using DotNetStarter.Common.Enums;
using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Users.Create
{
    public sealed class CreateUser : IRequest<User>
    {
        public string Username { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string Password { get; }

        public string PhoneNumber { get; }

        public Status Status { get; }

        public CreateUser(string username, string firstname, string lastname, string password, string phoneNumber, Status status)
        {
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
            Password = password;
            PhoneNumber = phoneNumber;
            Status = status;
        }
    }
}

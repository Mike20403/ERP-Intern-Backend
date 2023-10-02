using DotNetStarter.Common.Enums;
using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Users.Create
{
    public sealed class CreateUser : IRequest<User>
    {
        public string RoleName { get; }

        public string Username { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string Password { get; }

        public string PhoneNumber { get; }

        public Gender Gender { get; }

        public Status Status { get; }

        public CreateUser(string roleName, string username, string firstname, string lastname, string password, string phoneNumber, Gender gender, Status status)
        {
            RoleName = roleName;
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
            Password = password;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Status = status;
        }
    }
}

using DotNetStarter.Common.Enums;
using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Talents.Create
{
    public sealed class CreateTalent : IRequest<Talent>
    {
        public string Username { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string Password { get; }

        public string PhoneNumber { get; }

        public Gender Gender { get; }

        public Status Status { get; }

        public bool IsAvailable { get; }

        // TODO: change to `List<string>`
        public List<string>? PrivilegeNames { get; }

        public CreateTalent(
            string username, 
            string firstname, 
            string lastname, 
            string password, 
            string phoneNumber, 
            Gender gender, 
            Status status,
            bool isAvailable,
            List<string>? privilegeNames
        )
        {
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
            Password = password;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Status = status;
            IsAvailable = isAvailable;
            PrivilegeNames = privilegeNames;
        }
    }
}

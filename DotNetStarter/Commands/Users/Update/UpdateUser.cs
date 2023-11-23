using DotNetStarter.Common.Enums;
using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Users.Update
{
    public sealed class UpdateUser : IRequest<User>
    {
        public Guid UserId { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string PhoneNumber { get; }

        public Gender Gender { get; }

        public Status Status { get; }

        public string RoleName { get; }

        public List<string>? PrivilegeNames { get; }

        public UpdateUser
        (
            string roleName,
            Guid userId, 
            string firstname, 
            string lastname, 
            string phoneNumber, 
            Gender gender, 
            Status status,
            List<string>? privilegeNames
        )
        {
            UserId = userId;
            Firstname = firstname;
            Lastname = lastname;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Status = status;
            RoleName = roleName;
            PrivilegeNames = privilegeNames;
        }
    }
}

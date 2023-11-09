using DotNetStarter.Common.Enums;
using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Talents.Update
{
    public sealed class UpdateTalent : IRequest<Talent>
    {
        public Guid UserId { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string PhoneNumber { get; }

        public Gender Gender { get; }

        public Status Status { get; }

        public bool IsAvailable { get; }

        // TODO: change to `List<string>`
        public List<string>? PrivilegeNames { get; }

        public UpdateTalent(
            Guid userId,
            string firstname,
            string lastname,
            string phoneNumber,
            Gender gender,
            Status status,
            bool isAvailable,
            List<string>? privilegeNames 
        )
        {
            UserId = userId;
            Firstname = firstname;
            Lastname = lastname;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Status = status;
            IsAvailable = isAvailable;
            PrivilegeNames = privilegeNames;
        }
    }
}

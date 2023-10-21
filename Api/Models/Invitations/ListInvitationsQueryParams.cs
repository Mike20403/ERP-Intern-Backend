using DotNetStarter.Common.Enums;

namespace Api.Models.Invitations
{
    public class ListInvitationsQueryParams : ListQueryParams
    {
        public InvitationStatus? InvitationStatus { get; set; }
    }
}

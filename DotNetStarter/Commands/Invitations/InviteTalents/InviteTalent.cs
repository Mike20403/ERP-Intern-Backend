namespace DotNetStarter.Commands.Invitations.InviteTalents
{
    public sealed class InviteTalent
    {
        public string? Email { get; }

        public Guid? Id { get; }

        public InviteTalent(string? email, Guid? id)
        {
            Email = email;
            Id = id;
        }
    }
}

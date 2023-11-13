using DotNetStarter.Common.Models;
using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Comments.Create
{
    public sealed class CreateComment : IRequest<DataChanged<Comment>>
    {
        public Guid ProjectId { get; }

        public Guid CardId { get; }

        public string Description { get; }

        public Guid? ParentId { get; }

        public Guid? ProjectManagerId { get; }

        public Guid? TalentId { get; }

        public CreateComment(Guid projectId, Guid cardId, string description, Guid? parentId, Guid? projectManagerId, Guid? talentId)
        {
            ProjectId = projectId;
            CardId = cardId;
            Description = description;
            ParentId = parentId;
            ProjectManagerId = projectManagerId;
            TalentId = talentId;
        }
    }
}

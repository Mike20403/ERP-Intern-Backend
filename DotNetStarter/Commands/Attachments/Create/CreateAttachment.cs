using DotNetStarter.Common.Models;
using DotNetStarter.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DotNetStarter.Commands.Attachments.Create
{
    public sealed class CreateAttachment : IRequest<DataChanged<Attachment>>
    {
        public Guid? ProjectManagerId { get; }

        public Guid? TalentId { get; }


        public IFormFile File { get; }

        public Guid CardId { get; }

        public Guid ProjectId { get; }

        public CreateAttachment(Guid? projectManagerId, Guid? talentId, IFormFile file, Guid cardId, Guid projectId)
        {
            ProjectManagerId = projectManagerId;
            TalentId = talentId;
            File = file;
            CardId = cardId;
            ProjectId = projectId;
        }
    }
}

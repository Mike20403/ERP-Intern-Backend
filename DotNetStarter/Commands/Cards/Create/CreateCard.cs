﻿using DotNetStarter.Common.Models;
using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Cards.Create
{
    public sealed class CreateCard : IRequest<List<DataChanged<Card>>>
    {
        public Guid? ProjectManagerId { get; }

        public Guid? TalentId { get; }

        public string Name { get; }

        public Guid? PrevCardId { get; }

        public Guid? NextCardId { get; }

        public Guid StageId { get; }

        public Guid ProjectId { get; }

        public CreateCard(Guid? projectManagerId, Guid? talentId, string name, Guid? prevCardId, Guid? nextCardId, Guid stageId, Guid projectId)
        {
            ProjectManagerId = projectManagerId;
            TalentId = talentId;
            Name = name;
            PrevCardId = prevCardId;
            NextCardId = nextCardId;
            StageId = stageId;
            ProjectId = projectId;
        }
    }
}

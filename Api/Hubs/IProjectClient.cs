﻿using Api.Dtos;
using DotNetStarter.Common.Models;

namespace Api.Hubs
{
    public interface IProjectClient
    {
        Task StagesChanged(List<StageDto> stages);

        Task CardsMoved(List<DataChanged<MovingCardDto>> cards);

        Task CardsChanged(List<DataChanged<CardDto>> cards);
    }
}

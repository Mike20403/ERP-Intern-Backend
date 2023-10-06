﻿using AutoMapper;
using DotNetStarter.Commands.Projects.Create;
using DotNetStarter.Commands.Projects.Update;
using DotNetStarter.Commands.Talents.Create;
using DotNetStarter.Commands.Talents.Update;
using DotNetStarter.Commands.Users.Create;
using DotNetStarter.Commands.Users.Update;
using DotNetStarter.Entities;

namespace DotNetStarter.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region User
            CreateMap<CreateUser, User>();
            CreateMap<UpdateUser, User>();
            #endregion

            #region Talent
            CreateMap<CreateTalent, Talent>();
            CreateMap<UpdateTalent, Talent>();
            #endregion

            #region Project
            CreateMap<CreateProject, Project>();
            CreateMap<UpdateProject, Project>();
            #endregion
        }
    }
}

﻿using Api.Dtos;
using AutoMapper;
using DotNetStarter.Commands.Projects.Create;
using DotNetStarter.Commands.Projects.Update;
using DotNetStarter.Commands.Users.Create;
using DotNetStarter.Commands.Users.Update;
using DotNetStarter.Entities;

namespace Api.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region User
            CreateMap<User, UserDto>();
            CreateMap<CreateUser, User>();
            CreateMap<UpdateUser, User>();
            #endregion

            #region Account
            CreateMap<User, AccountDto>();
            #endregion

            #region Project
            CreateMap<Project, ProjectDto>();
            CreateMap<CreateProject, Project>();
            CreateMap<UpdateProject, Project>();
            #endregion
        }
    }
}

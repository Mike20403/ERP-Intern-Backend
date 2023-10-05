using Api.Dtos;
using DotNetStarter.Common;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;

namespace Api.Common
{
    public class ApiAutoMapperProfile : AutoMapperProfile
    {
        public ApiAutoMapperProfile()
        {
            #region User
            CreateMap<User, UserDto>();
            CreateMap<User, StaffMemberDto>()
                .ForMember(s => s.Type, opt => opt.MapFrom(u => u.Role!.Name.ToStaffMemberType()));
            CreateMap<User, PersonDto>();
            #endregion

            #region Account
            CreateMap<User, AccountDto>();
            #endregion

            #region Project
            CreateMap<Project, ProjectDto>();
            #endregion
        }
    }
}

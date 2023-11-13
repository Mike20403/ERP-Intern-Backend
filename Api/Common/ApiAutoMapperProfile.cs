using Api.Dtos;
using DotNetStarter.Commands.Cards.MoveCards;
using DotNetStarter.Common;
using DotNetStarter.Common.Models;
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
                .ForMember(s => s.Type, opt => opt.MapFrom(u => u.Role!.Name.ToStaffMemberType()))
                .ForMember(s => s.Privileges, opt => opt.MapFrom(u => u.Privileges.Select(p => p.Name)));
            CreateMap<User, PersonDto>();
            #endregion

            #region Talent
            CreateMap<Talent, TalentDto>()
                .ForMember(s => s.Privileges, opt => opt.MapFrom(u => u.Privileges.Select(p => p.Name)));
            #endregion

            #region Account
            CreateMap<User, AccountDto>();
            #endregion

            #region Project
            CreateMap<Project, ProjectDto>();
            #endregion

            #region Stage
            CreateMap<Stage, StageDto>();
            #endregion

            #region Card
            CreateMap<Card, CardDto>();
            CreateMap<MovingCard, MovingCardDto>();
            #endregion

            #region Attachment
            CreateMap<Attachment, AttachmentDto>();
            #endregion

            #region Invitation
            CreateMap<Invitation, InvitationDto>();
            #endregion

            #region Payment
            CreateMap<Card, PaymentCardDto>();
            CreateMap<Payment, PaymentDto>();
            #endregion

            #region Comment
            CreateMap<Comment, CommentDto>();
            #endregion

            #region DataChanged
            CreateMap(typeof(DataChanged<>), typeof(DataChanged<>));
            #endregion
        }
    }
}

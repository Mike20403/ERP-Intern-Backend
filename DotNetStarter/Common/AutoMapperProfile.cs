using AutoMapper;
using DotNetStarter.Commands.Attachments.Create;
using DotNetStarter.Commands.Cards.Create;
using DotNetStarter.Commands.Cards.MoveCards;
using DotNetStarter.Commands.Cards.Update;
using DotNetStarter.Commands.Comments.Create;
using DotNetStarter.Commands.Comments.Update;
using DotNetStarter.Commands.Invitations.InviteTalents;
using DotNetStarter.Commands.Invitations.RegisterTalent;
using DotNetStarter.Commands.Payments.Create;
using DotNetStarter.Commands.Payments.Update;
using DotNetStarter.Commands.Projects.Create;
using DotNetStarter.Commands.Projects.Update;
using DotNetStarter.Commands.Talents.Create;
using DotNetStarter.Commands.Talents.Update;
using DotNetStarter.Commands.Users.Create;
using DotNetStarter.Commands.Users.Update;
using DotNetStarter.Common.ImportDataUsers;
using DotNetStarter.Common.Models;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;

namespace DotNetStarter.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region User
            CreateMap<CreateUser, User>();
            CreateMap<UpdateUser, User>();
            CreateMap<User, ImportStaffMemberDto>()
                .ForMember(s => s.RoleName, opt => opt.MapFrom(u => u.Role!.Name.ToStaffMemberType()))
                .ForMember(s => s.Privileges, opt => opt.MapFrom(u => string.Join(", ", u.Privileges.Select(p => p.Name))));
            CreateMap<ImportStaffMemberDto, ImportDataStaffMembers>()
                .ForMember(dest => dest.Privileges, opt => opt.MapFrom((src, dest) => src.Privileges.Split(", ").ToList()));
            #endregion

            #region Talent
            CreateMap<CreateTalent, Talent>();
            CreateMap<UpdateTalent, Talent>();
            CreateMap<RegisterTalent, Talent>();
            CreateMap<Talent, ImportTalentDto>()
                .ForMember(s => s.Privileges, opt => opt.MapFrom(u => string.Join(", ", u.Privileges.Select(p => p.Name))));
            CreateMap<ImportTalentDto, ImportDataTalents>()
                .ForMember(dest => dest.Privileges, opt => opt.MapFrom((src, dest) => src.Privileges.Split(", ").ToList()));
            #endregion

            #region Project
            CreateMap<CreateProject, Project>();
            CreateMap<UpdateProject, Project>();
            #endregion

            #region Card
            CreateMap<CreateCard, Card>();
            CreateMap<UpdateCard, Card>();
            CreateMap<MovingCard, Card>().ReverseMap();
            #endregion

            #region Attachment
            CreateMap<CreateAttachment, Attachment>();
            #endregion

            #region Invitation
            CreateMap<InviteTalents, Invitation>();
            CreateMap<InviteTalent, Invitation>().ReverseMap();
            #endregion

            #region Comment
            CreateMap<CreateComment, Comment>();
            CreateMap<UpdateComment, Comment>();
            #endregion

            #region Payment
            CreateMap<CreatePayment, Payment>();
            CreateMap<UpdatePayment, Payment>();
            #endregion
        }
    }
}

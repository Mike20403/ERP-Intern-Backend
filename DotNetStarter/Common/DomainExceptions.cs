using DotNetStarter.Common.Models;

namespace DotNetStarter.Common
{
    public static class DomainExceptions
    {
        public static readonly DomainException NotFound = new DomainException
        {
            Code = "NotFound",
            Message = "NotFound",
        };

        public static readonly DomainException Conflict = new DomainException
        {
            Code = "Conflict",
            Message = "Conflict",
        };

        public static readonly DomainException Unauthorized = new DomainException
        {
            Code = "Unauthorized",
            Message = "Unauthorized",
        };

        public static readonly DomainException Forbidden = new DomainException
        {
            Code = "Forbidden",
            Message = "Forbidden",
        };

        public static readonly DomainException BadCredentials = new DomainException
        {
            Code = "BadCredentials",
            Message = "Username or password is incorrect",
        };

        public static readonly DomainException UserNotFound = new DomainException
        {
            Code = "UserNotFound",
            Message = "User not found",
        };

        public static readonly DomainException TalentNotFound = new DomainException
        {
            Code = "TalentNotFound",
            Message = "Talent not found",
        };

        public static readonly DomainException AgencyMemberNotFound = new DomainException
        {
            Code = "AgencyMemberNotFound",
            Message = "Agency member not found",
        };

        public static readonly DomainException ProjectManagerNotFound = new DomainException
        {
            Code = "ProjectManagerNotFound",
            Message = "Project manager not found",
        };

        public static readonly DomainException ProjectNotFound = new DomainException
        {
            Code = "ProjectNotFound",
            Message = "Project not found",
        };

        public static readonly DomainException ProjectHasStages = new DomainException
        {
            Code = "ProjectHasStages",
            Message = "Project has stages",
        };

        public static readonly DomainException StageNotFound = new DomainException
        {
            Code = "StageNotFound",
            Message = "Stage not found",
        };

        public static readonly DomainException StageHasCards = new DomainException
        {
            Code = "StageHasCards",
            Message = "Stage has cards",
        };

        public static readonly DomainException CardNotFound = new DomainException
        {
            Code = "CardNotFound",
            Message = "Card not found",
        };

        public static readonly DomainException AttachmentNotFound = new DomainException
        {
            Code = "AttachmentNotFound",
            Message = "Attachment not found",
        };

        public static readonly DomainException InvalidOtp = new DomainException
        {
            Code = "InvalidOtp",
            Message = "OTP doesn't exist, used or expired",
        };

        public static readonly DomainException OtpNotFound = new DomainException
        {
            Code = "OtpNotFound",
            Message = "Otp not found",
        };

        public static readonly DomainException OtpExpired = new DomainException
        {
            Code = "OtpExpired",
            Message = "Otp expired",
        };

        public static readonly DomainException UserAlreadyExists = new DomainException
        {
            Code = "UserAlreadyExists",
            Message = "User already exists",
        };

        public static readonly DomainException TalentAlreadyExists = new DomainException
        {
            Code = "TalentAlreadyExists",
            Message = "This talent is already in this card",
        };

        public static readonly DomainException EmailAlreadyExists = new DomainException
        {
            Code = "EmailAlreadyExists",
            Message = "Email already exists",
        };

        public static readonly DomainException InvalidPassword = new DomainException
        {
            Code = "InvalidPassword",
            Message = "Password should have at least 8 characters, 1 lower case, 1 upper case, 1 number and 1 special character",
        };

        public static readonly DomainException InvalidPhoneNumber = new DomainException
        {
            Code = "InvalidPhoneNumber",
            Message = "Invalid phone number",
        };

        public static readonly DomainException PhoneNumberAlreadyExists = new DomainException
        {
            Code = "PhoneNumberAlreadyExists",
            Message = "Phone number already exists",
        };

        public static readonly DomainException InvalidAuthToken = new DomainException
        {
            Code = "InvalidAuthToken",
            Message = "Invalid auth token",
        };

        public static readonly DomainException IncorrectPassword = new DomainException
        {
            Code = "IncorrectPassword",
            Message = "Current password is incorrect",
        };

        public static readonly DomainException InvalidRoleName = new DomainException
        {
            Code = "InvalidRoleName",
            Message = "This role name is invalid!",
        };

        public static readonly DomainException InvalidPrivilege = new DomainException
        {
            Code = "InvalidPrivilege",
            Message = "Invalid Privilege for doing this",
        };

        public static readonly DomainException InvalidInvitation = new DomainException
        {
            Code = "InvalidInvitation",
            Message = "Invalid Invitation",
        };

        public static readonly DomainException PaymentNotFound = new DomainException
        {
            Code = "PaymentNotFound",
            Message = "Payment NotFound",
        };

        public static readonly DomainException NotProjectTalent = new DomainException
        {
            Code = "NotProjectTalent",
            Message = "Not Project Talent",
        };
    }
}

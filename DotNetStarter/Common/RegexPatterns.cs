namespace DotNetStarter.Common
{
    public static class RegexPatterns
    {
        public const string Password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$";
        public const string PhoneNumber = @"^(\+)?(84|0)([35789])([0-9]{8})$";
    }
}

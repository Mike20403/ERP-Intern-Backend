namespace DotNetStarter.Services.Password
{
    public class PasswordService : IPasswordService
    {
        public const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        public const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string DigitChars = "0123456789";
        public const string SpecialChars = "#$^+=!*()@%&";
        public const string AllowedChars = LowercaseChars + UppercaseChars + DigitChars + SpecialChars;
        public static List<string> MustHaveChars = new List<string>
        {
            LowercaseChars,
            UppercaseChars,
            DigitChars,
            SpecialChars,
        };

        public string GenerateRandomPassword()
        {
            var random = new Random();

            char[] chars = new char[8];

            return string.Join("", chars.Select((_, index) =>
            {
                if (index < MustHaveChars.Count)
                {
                    var allowedChars = MustHaveChars.ElementAt(index);
                    return allowedChars[random.Next(allowedChars.Length)];
                }

                return AllowedChars[random.Next(AllowedChars.Length)];
            }).OrderBy(c => Guid.NewGuid()));
        }
    }
}

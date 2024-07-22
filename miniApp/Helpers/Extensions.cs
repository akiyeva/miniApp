using System.Text.RegularExpressions;

namespace miniApp.Helpers
{
    public static class Extensions
    {
        public static bool CheckName(this string value)
        {
            var trimmedValue = value.Trim();

            return !string.IsNullOrWhiteSpace(trimmedValue)
                && char.IsUpper(trimmedValue[0])
                && trimmedValue.Length >= 3
                && !trimmedValue.Contains(" ");
        }

        public static bool CheckClassroomName(this string value)
        {
            var trimmedValue = value.Trim();

            return Regex.IsMatch(trimmedValue, @"^[A-Z]{2}\d{3}$");
        }
    }
}

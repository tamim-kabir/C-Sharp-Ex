using System.Text.RegularExpressions;

namespace Check.Valid

{
    public static class Check
    {
        public static bool IsValidEmail(this string input)
        {
            return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }
        public static bool IsValidPassword(this string input)
        {
            return Regex.IsMatch(input, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*()^_+=|,.`~;:/.[{\]}<>""-])[a-zA-Z0-9#?!@$%^&*()^_+=|,.`~;:/.[{\]}<>""-].{8,}$");
        }
        public static bool IsValidXmlTag(this string input)
        {
            return Regex.IsMatch(input, @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$");
        }
        public static bool IsValidHex(this string input)
        {
            return Regex.IsMatch(input, "#?([a-fA-F0-9]{3}|[a-fA-F0-9]{6})$");
        }
    }
}

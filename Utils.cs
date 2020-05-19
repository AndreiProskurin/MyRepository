using System;

namespace Tests
{
    public static class Utils
    {
        public static string GetRandomString(int length)
        {
            var random = new Random();
            if (length == 0)
            {
                length = random.Next(65);
            }
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789 ";
            var stringChars = new char[length];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}

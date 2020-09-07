using System;

namespace Schools.Application.Utilities.Generator
{
    public class NameGenerator
    {
        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString("N").Substring(0,5).Replace("-", "");
        }
    }
}

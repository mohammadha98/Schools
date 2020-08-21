using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Application.Utilities.Generator
{
    public class NameGenerator
    {
        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString("N").Substring(0,4).Replace("-", "");
        }
    }
}

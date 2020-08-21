using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Application.Utilities.Convertors
{
    public class FixedText
    {
        public static string FixedEmail(string email)
        {
            return email.Trim().ToLower();
        }
    }
}

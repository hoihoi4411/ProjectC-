using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectCsharp.Animation
{
    public class Validation
    {
        public static bool checkId(string ID)
        {
            var regex = @"^[0-9A-Za-z]{5,49}$";
            var match = Regex.Match(ID, regex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return false;
            }
            return true;
        }
        public static bool checkEmail(string ID)
        {
            var regex = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var match = Regex.Match(ID, regex, RegexOptions.IgnoreCase);
            return match.Success;
        }
        public static bool checkName(string ID)
        {
            var regex = @"^[A-Za-z ]{5,49}$";
            var match = Regex.Match(ID, regex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return false;
            }
            return true;
        }
        public static bool checkMaxLenghtAndMin(string input, int max, int min)
        {
            if(input.Length < min || input.Length > max)
            {
                return false;
            }
            return true;
        }
    }
}

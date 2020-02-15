using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BlazorForum.Domain.Utilities.Formatting
{
    public class RegularExp
    {
        public static string RemoveScriptTags(string valueToClean)
        {
            var pattern = @"<script[^>]*>[\s\S]*?</script>";
            return Regex.Replace(valueToClean, pattern, "");
        }
    }
}

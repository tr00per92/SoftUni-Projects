using System;
using System.Web;

namespace DocumentSystem.Utils
{
    public static class StringExtensions
    {
        public static string HtmlEncode(this string str)
        {
            return HttpUtility.HtmlEncode(str);
        }
    }
}

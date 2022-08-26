using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchBar
{
    /// <summary>
    /// Contains the Replacement Strings List
    /// </summary>
    internal static class ReplacmentStringList
    {
        public static string StringGet(char c)
        {
            string str = Rstring(c);
            return str;
        }
        private static string Rstring(char c)
        {
            if(c == '+')
            {
                return "%2B";
            }
            if(c == '=')
            {
                return "%3D";
            }
            if(c == '/')
            {
                return "%2F";
            }
            if(c == 'a')
            {
                return "a";
            }
            else
            {
                return "ERR";
            }
        }
    }
}

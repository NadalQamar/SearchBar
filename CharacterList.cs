using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchBar
{
    /// <summary>
    /// Contains the Character List
    /// </summary>
    internal static class CharacterList
    {
        //Methods
        public static char CharGet(char c)
        {
            c = CharList(c);
            return c;
        }

        private static Char CharList(char c)
        {
            if(c == ' ')
            {
                return 's';//for space just return nothing
            }
            if (c == '+')//for add
            {
                return '+';
            }
            if (c == '=')//for equals to
            {
                return '=';
            }
            if (c == '/')//for forwardslash
            {
                return '/';
            }
            else
            {
                return 'n';//for none
            }
        }
    }
}

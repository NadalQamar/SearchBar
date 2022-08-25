using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SearchBar
{
    /// <summary>
    /// Main Code for SearchBar
    /// </summary>
    public partial class SearchBar : Form
    {
        //added a field variable to take shapshot of the search query at the time of pressing the Enter key
        string searchText;
        public SearchBar()
        {
            InitializeComponent();
        }

        private void SearchBar_Load(object sender, EventArgs e)
        {
            
            searchEngineSelector.SelectedIndex = 0;
            searchBox.Focus();

        }
        //Methods
        private string BeginningOfString(string str)
        {
            char c = str[0];
            int iteration = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)//for whichever character that starts the string
                {
                    iteration++;
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < iteration; i++)//remove the number of repeated character of same type
            {
                str = str.Substring(1);
            }
            for (int i = 0; i < iteration; i++)//add the same number of character of same type
            {
                if(c == ' ')
                {
                    break;
                }
                if(c == '+')
                {
                    str = "%2B" + str;
                }
                if (c == '=')
                {
                    str = "%3D" + str;
                }
                if (c == '/')
                {
                    str = "%2F" + str;
                }

            }
            return str;
        }
        private string MiddleOfString1(string str1)
        {
            StringBuilder str2 = new StringBuilder(str1);
            StringBuilder insertCharacter;
            int i = 0;
            do
            {
                if (str2[i] == '+' || str2[i] == '=' || str2[i] == '/')
                {
                    insertCharacter = MiddleOfString2(str2[i]);
                    str2 = str2.Insert(i, insertCharacter);
                    str2 = str2.Remove(i + 3, 1);
                }
                else
                {
                    i++;
                }
            } while (str2.ToString().Contains('+') || str2.ToString().Contains('=') || str2.ToString().Contains('/'));
            return str2.ToString();
        }
        private StringBuilder MiddleOfString2(char c)
        {
            StringBuilder str = new StringBuilder();
            if(c == '+')
            {
                str.Append("%2B");
            }
            if (c == '=')
            {
                str.Append("%3D");
            }
            if (c == '/')
            {
                str.Append("%2F");
            }
            return str;
        }

        private void SearchBox_PressEnter(object sender, KeyEventArgs e)
        {
        //Key Feature
            if (e.KeyCode == Keys.Enter)
            {
                searchText = searchBox.Text;
                searchText = BeginningOfString(searchText);
                //if search query is spaced
                if (searchText.Contains (" "))
                {

                    string[] splitString = searchText.Split(' ');
                    searchText = "";
                    for (int i = 0; i < splitString.Length; i++)
                    {
                        if (i == 0)
                        {  
                            searchText = MiddleOfString1(splitString[i]);
                        }
                        else
                        {   //if search query has any un-needed spaces
                            if (splitString[i] == "")
                            {
                                continue;
                            }
                            searchText = searchText + "+" + MiddleOfString1(splitString[i]);
                            
                        }
                    }
                }else
                {
                    searchText = MiddleOfString1(searchText);
                }
                try
                {//SubFeature
                    if(searchEngineSelector.SelectedIndex == 0)
                    {
                        Process.Start($"https://www.google.com/search?q={searchText}");
                    }
                    if(searchEngineSelector.SelectedIndex == 1)
                    {
                        Process.Start($"https://www.bing.com/search?q={searchText}");
                    }
                    
                }
                catch (Win32Exception noBrowser)
                {
                    if (noBrowser.ErrorCode == -2137367259)
                    {
                        MessageBox.Show(noBrowser.Message);
                    }
                }
                catch (System.Exception other)
                {
                    MessageBox.Show(other.Message);
                }
                
            }
        }
    }
}

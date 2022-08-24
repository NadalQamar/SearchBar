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
        private string MiddleOfString(char c)
        {
            string str = "";
            if(c == '+')
            {
                str = "%2B";
            }
            if (c == '=')
            {
                str = "%3D";
            }
            if (c == '/')
            {
                str = "%2F";
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
                        string insertCharacter = "";
                        if (i == 0)
                        {

                            for(int j = 0; j < splitString[i].Length; j++)
                            {
                                char[] chars = splitString[i].ToCharArray();
                                if (chars[j] == '+' || chars[j] == '=' || chars[j] == '/')
                                {
                                    insertCharacter = MiddleOfString(chars[j]);
                                    splitString[i] = splitString[i].Insert(j, insertCharacter);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            searchText = splitString[i];
                        }
                        else
                        {   //if search query has any un-needed spaces
                            if (splitString[i] == "")
                            {
                                continue;
                            }
                            char mainC = searchText[i];
                            if (mainC == '+' || mainC == '=' || mainC == '/')//good reference to use ASCII maybe?
                            {
                                insertCharacter = MiddleOfString(mainC);
                                searchText = searchText.Insert(i, insertCharacter);
                            }
                            else
                            {
                                searchText = searchText + "+" + splitString[i];
                            }
                        }
                    }
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

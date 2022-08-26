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
    /// Contains SearchBar's main code
    /// </summary>
    public partial class SearchBar : Form
    {
        string searchText;//added a field variable to take shapshot of the search query at the time of pressing the Enter key
        bool spaceOnlyEventFlag = false;//for space only event
        
        public SearchBar()
        {
            InitializeComponent();
        }
        //On LoadTime
        private void SearchBar_Load(object sender, EventArgs e)
        {
            searchEngineSelector.SelectedIndex = 0;//default search engine
            searchBox.Focus();//takes focus from other applications and redirects it to SearchBar
        }
        //Methods start
        private string BeginningOfString(string str)//for the first character of the string
        {
            char c = str[0];
            char compareC = CharacterList.CharGet(c);

            if(compareC != 'n')//if the first char of the string just has a letter or any character not in CharacterList, it will skip
            {
                int iteration = 0;
                
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == c) iteration++;//for whichever character that starts the string, how many times does it iterate?
                    else break;
                }
                for (int i = 0; i < iteration; i++) str = str.Substring(1);//remove the number of repeated character of same type
                for (int i = 0; i < iteration; i++)//add the same number of character of same type
                {
                    if (compareC == 's')
                    {
                        if(str == "") spaceOnlyEventFlag = true;//This condition is only valid if only space was entered      
                        break;
                    }
                    if (c == CharacterList.CharGet(c)) str = ReplacmentStringList.StringGet(c) + str;//replaces the character found with the string and added it to the beginning of the main str
                }
            }   
            return str;
        }
        private string EndOfString(string str1)
        { 
            StringBuilder str2 = new StringBuilder(str1);//takes the string and converts it to StringBuilder
            StringBuilder insertCharacter;//needed for adding the substring to string
            char compareC;

            for (int i = 0; i < str2.Length; i++)//checks for and if found changes the character to the substring
            {
                char c = str2[i];

                compareC = CharacterList.CharGet(c);//takes the char from string and runs it against its list
                if (compareC != 'n')//if found it will go into the if statement, else it will go to else statement
                {
                    insertCharacter = new StringBuilder(ReplacmentStringList.StringGet(c));
                    str2 = str2.Insert(i, insertCharacter);
                    str2 = str2.Remove(i + 3, 1);
                }
                else continue; //goes to next char in string
            }
            return str2.ToString();
        }
        //Methods end
        //Form Methods start
        private void SearchBox_PressEnter(object sender, KeyEventArgs e)//Key Feature
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchText = searchBox.Text;//taking shapshot
                searchText = BeginningOfString(searchText);//checking first char of the string
                
                if(spaceOnlyEventFlag == true)//room for improvement here only occurs when the user just enters space as query
                {
                    spaceOnlyEventFlag = false;//set it back to default value       
                }
                //if search query is spaced or has a repeat of certain characters
                if (searchText.Contains (" "))//multiple words in a query, separated by space
                {
                    string[] splitString = searchText.Split(' ');//splits the string on space
                    searchText = "";//clears the searchText and reuse the variable after validation of each of the characters is done
                    for (int i = 0; i < splitString.Length; i++)
                    {
                        if (i == 0) searchText = EndOfString(splitString[i]);//first word of string
                        else
                        {   
                            if (splitString[i] == "") continue;//if search query has any un-needed nulls within its elements it will skip them
                            searchText = searchText + "+" + EndOfString(splitString[i]);//second and subsequent words             
                        }
                    }
                }else searchText = EndOfString(searchText);
                try
                {//SubFeature
                    if(searchEngineSelector.SelectedIndex == 0 && searchText != "") Process.Start($"https://www.google.com/search?q={searchText}");//go to google and enter query
                    if(searchEngineSelector.SelectedIndex == 1 && searchText != "") Process.Start($"https://www.bing.com/search?q={searchText}");//go to bing and enter query
                    //space only Event
                    if(searchText == "") searchBox.Clear();//clear the searchBox and do nothing
                }
                catch (Win32Exception noBrowser)
                {
                    if (noBrowser.ErrorCode == -2137367259) MessageBox.Show(noBrowser.Message);
                }
                catch (System.Exception other)
                {
                    MessageBox.Show(other.Message);
                }
                
            }
        }
    }
}

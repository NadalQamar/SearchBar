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

        }

        private void searchBox_PressEnter(object sender, KeyEventArgs e)
        {
        //Key Feature
            if (e.KeyCode == Keys.Enter)
            {
                searchText = searchBox.Text;
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

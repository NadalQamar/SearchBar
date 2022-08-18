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
   
    public partial class SearchBar : Form
    {
        string searchText;
        public SearchBar()
        {
            InitializeComponent();
        }

        private void SearchBar_Load(object sender, EventArgs e)
        {


        }

        private void searchBox_PressEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchText = searchBox.Text;
                try
                {
                    Process.Start($"https://www.google.com/search?q={searchText}");
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

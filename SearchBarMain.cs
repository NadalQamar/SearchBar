using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchBar
{
    static class SearchBarMain
    {
        [STAThread]
       static void Main (string[] args)
        {
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);
            Application.Run (new SearchBar ());
            
        }
    }
}

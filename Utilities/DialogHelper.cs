using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathBox
{
    public static class DialogHelper
    {

        public static string DialogOpenFolder(string InitialDirectory)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            return dialog.SelectedPath;
        }

        public static string DialogOpenFile(string InitialDirectory,string filter)
        {
            // Create OpenFileDialog 
            var dialog = new Microsoft.Win32.OpenFileDialog();
            string filename = "";
            // Set filter for file extension and default file extension 
            dialog.Filter = filter;
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dialog.ShowDialog();
            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                filename = dialog.FileName;
            }
            return filename;
        }

    }
}

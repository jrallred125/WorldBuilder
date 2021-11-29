using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace WorldBuilderWPF.Services
{
    public class OpenFileDialogService
    {
        public string OpenFileDialog()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Select an Image";
            openFile.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == true)
            {
                return openFile.FileName;
            }
            return string.Empty;
        }
    }
}

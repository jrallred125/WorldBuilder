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
            openFile.Filter = "Image Files (*.jpeg; *.jpg; *.png;)|*.jpeg; *.jpg; *.png;|PNG files|*.png|JPEG files|*.jpg;*.jepg";
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == true)
            {
                return openFile.FileName;
            }
            return string.Empty;
        }
    }
}

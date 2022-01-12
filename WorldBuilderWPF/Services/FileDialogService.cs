using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace WorldBuilderWPF.Services
{
    public class FileDialogService
    {
        public string OpenFileDialogImage()
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

        public string OpenFileDialogJson()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Select Json";
            openFile.Filter = "Json Files (*.json)|*.json;";
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == true)
            {
                return openFile.FileName;
            }
            return string.Empty;
        }

        public string SaveFileDialogJson()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save Json";
            saveDialog.Filter = "Json Files (*.json)|*.json";
            if (saveDialog.ShowDialog() == true)
            {
                return saveDialog.FileName;
            }
            return string.Empty;
        }
    }
}

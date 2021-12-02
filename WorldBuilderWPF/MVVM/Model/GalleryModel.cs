using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;

namespace WorldBuilderWPF.MVVM.Model
{
    [Serializable]
    public class GalleryModel :ObservableObject
    {
        /// <summary>
        /// This is the index of the main Image. 
        /// </summary>
        public int MainImageIndex;
        /// <summary>
        /// The private collection of the filepaths or url to the location of the image to be loaded.
        /// </summary>
        private ObservableCollection<string> _images;
        /// <summary>
        /// The public collection of the images.
        /// </summary>
        public ObservableCollection<string> Images
        {
            get { return _images; }
            set 
            { 
                _images = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// The constructor of the class.
        /// </summary>
        public GalleryModel()
        {
            Images = new ObservableCollection<string>();
            MainImageIndex = 0;
        }
        /// <summary>
        /// Sets the main image filepath or URL for the object holding the class. 
        /// Will take the old filepath or URL and move it to the last. 
        /// </summary>
        /// <param name="image">The Image to be added in.</param>
        public void SetMainImage(string image)
        {
            if (!Images.Contains(image) && !string.IsNullOrWhiteSpace(image))
            {
                Images.Add(image);
            }
            MainImageIndex = Images.IndexOf(image);
        }
        /// <summary>
        /// Gets the main image filepath or URL for the object holding the gallery. 
        /// </summary>
        /// <returns>The string to the filepath or URL of the image.</returns>
        public string GetMainImage()
        {
            if (Images.Count > 0 && MainImageIndex > -1)
            {
                return Images[MainImageIndex];
            }
            return "";
        }
        /// <summary>
        /// Add the file path or url for the image to be added into the collection.
        /// </summary>
        /// <param name="image">The string to the file path or Url of the image.</param>
        public void AddIamge(string image)
        {
            if (!Images.Contains(image) && !string.IsNullOrWhiteSpace(image))
            {
                Images.Add(image);
            }
        }
        /// <summary>
        /// Removes the image file path or URl from the collection.
        /// Also checks that the main image indes is the same as the image to be removed
        /// if it is the same have the index be -1.
        /// </summary>
        /// <param name="image">The string of the file path or Url of the image.</param>
        public void RemoveImage(string image)
        {
            if (MainImageIndex == Images.IndexOf(image))
            {
                MainImageIndex -= 1;
            }
            Images.Remove(image);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WorldBuilder.Domain.Models
{
    public class ImageGallery : DBclass
    {
        public List<BitmapImage> Gallery { get; set; }
        public int Index;

        public ImageGallery()
        {

            Gallery = new List<BitmapImage>();
        }
        /// <summary>
        /// This will add an image to the character's image gallery. 
        /// </summary>
        /// <param name="image">The image to be added.</param>
        public void AddImage(BitmapImage image)
        {
            if (!Gallery.Contains(image) && image != null)
            {
                Gallery.Add(image);
            }
        }

        /// <summary>
        /// This will remove an image from the character's gallery.
        /// </summary>
        /// <param name="image">The image to be removed.</param>
        public void RemoveImage(BitmapImage image)
        {
            Gallery.Remove(image);
        }
        /// <summary>
        /// This will change the index of the gallery and return the image at that index
        /// </summary>
        /// <returns>The image at the changed index</returns>
        public BitmapImage Prev()
        {
            Index--;
            if (Index < 0)
            {
                Index = Gallery.Count - 1;
            }
            return Gallery[Index];
        }
        /// <summary>
        /// This will change the index of the gallery and return the image at that index
        /// </summary>
        /// <returns>The image at the changed index</returns>
        public BitmapImage Next()
        {
            Index = ++Index % Gallery.Count;
            return Gallery[Index];
        }



    }
}

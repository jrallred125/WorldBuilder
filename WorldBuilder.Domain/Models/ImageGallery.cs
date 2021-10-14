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
        /// <summary>
        /// A list of images that have been saved.
        /// </summary>
        public List<BitmapImage> Gallery { get; set; }
        /// <summary>
        /// The Index of the current image that is being viewed. 
        /// </summary>
        private int Index;

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
            if (!Gallery.Any())
            {
                Index = 0;
                return null;
            }
            if (--Index < 0)
            {
                Index = Gallery.Count - 1;
            }
            if (Gallery.Count == 0)
            {
                return null;
            }
            return Gallery[Index];
        }
        /// <summary>
        /// This will change the index of the gallery and return the image at that index
        /// </summary>
        /// <returns>The image at the changed index</returns>
        public BitmapImage Next()
        {
            if (!Gallery.Any())
            {
                Index = 0;
                return null;
            }
            Index = ++Index % Gallery.Count;
            
            return Gallery[Index];
        }
        /// <summary>
        /// This will return the image at the current index.
        /// </summary>
        /// <returns>The image at the current index value.</returns>
        public BitmapImage Current()
        {
            if (!Gallery.Any())
            {
                Index = 0;
                return null;
            }
            return Gallery[Index];
        }



    }
}

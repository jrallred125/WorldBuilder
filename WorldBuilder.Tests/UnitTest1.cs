using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Media.Imaging;
using WorldBuilder.Domain.Models;

namespace WorldBuilder.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CharacterClassTests()
        {
            Character A = new Character("Bobbie", "Fun loving kid.", "Has a head shaped like a football.");
            Character B = new Character("Mommy", "Stern but loving.", "Tall and slender.");
            A.AddContact(B);
            Assert.AreEqual(B.Contacts.Count, 0);
            Assert.AreEqual(A.Contacts.Count, 1);
            B.AddContact(A, true);
            Assert.AreEqual(B.Contacts.Count, 1);
            Assert.AreEqual(A.Contacts.Count, 1);
            A.RemoveContact(B);
            Assert.AreEqual(B.Contacts.Count, 1);
            Assert.AreEqual(A.Contacts.Count, 0);
            B.RemoveContact(A, true);
            Assert.AreEqual(B.Contacts.Count, 0);
            Assert.AreEqual(A.Contacts.Count, 0);
            B.AddContact(null);
            Assert.AreEqual(B.Contacts.Count, 0);
            A.AddTitle("son");
            Assert.AreEqual(A.Titles.Count, 1);
            A.RemoveTitle("son");
            Assert.AreEqual(A.Titles.Count, 0);
            A.AddTitle(null);
            Assert.AreEqual(A.Titles.Count, 0);
            A.AddTitle("");
            Assert.AreEqual(A.Titles.Count, 0);
            A.AddTitle("   ");
            Assert.AreEqual(A.Titles.Count, 0);
            A.AddImage(null);
            Assert.AreEqual(A.Gallery.Gallery.Count, 0);
            
        }
        [TestMethod]
        public void ImageGalleyClassTest()
        {
            ImageGallery A = new ImageGallery();
            Uri resourceUri = new Uri("/Images/hidden_horde.jpg", UriKind.Relative);
            BitmapImage testImage = new BitmapImage(resourceUri);
            A.AddImage(testImage);
            Assert.AreEqual(A.Gallery.Count, 1);
            Assert.AreEqual(A.Current(), testImage);
            Assert.AreEqual(A.Next(), testImage);
            Assert.AreEqual(A.Prev(), testImage);
            A.AddImage(testImage);
            Assert.AreEqual(A.Gallery.Count, 1);
            A.RemoveImage(testImage);
            Assert.AreEqual(A.Gallery.Count, 0);
            Assert.IsNull(A.Current());
            Assert.IsNull(A.Next());
            Assert.IsNull(A.Prev());
            
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Media.Imaging;
using WorldBuilder.Domain.Models;
using System.IO;

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
        }
    }
}

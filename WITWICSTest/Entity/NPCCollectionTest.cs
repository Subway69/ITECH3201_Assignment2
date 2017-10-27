using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WITWICS.Entity;

namespace WITWICSTest.Entity
{
    [TestClass]
    public class NPCCollectionTest
    {
        private NPCCollection collection;

        [TestInitialize]
        public void Init()
        {
            collection = new NPCCollection();

        }

        [TestMethod]
        public void It_Adds_The_NPC()
        {
            Assert.IsTrue(collection.AddNPC("john", new NonPlayerCharacter()));
        }

        [TestMethod]
        public void It_Finds_The_NPC()
        {
            collection.AddNPC("john", new NonPlayerCharacter());
            Assert.IsFalse(collection.GetNPC("john") == null);
        }

        [TestMethod]
        public void It_Lists_The_NPC()
        {
            collection.AddNPC("john", new NonPlayerCharacter("John", new Clue()));
            Assert.IsTrue(collection.ListNPCs().ToLower().Contains("john"));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WITWICS.Entity;

namespace WITWICSTest.Entity
{
    [TestClass]
    public class LocationCollectionTest
    {
        private LocationCollection collection;

        [TestInitialize]
        public void Init()
        {
            collection = new LocationCollection();

        }

        [TestMethod]
        public void It_Adds_The_Location()
        {
            Assert.IsTrue(collection.AddLocation("location", new Location("Location", "Location")));
        }

        [TestMethod]
        public void It_Finds_The_Location()
        {
            collection.AddLocation("location", new Location("Location", "Location"));
            Assert.IsFalse(collection.GetLocation("location") == null);
        }

        [TestMethod]
        public void It_Lists_The_Location()
        {
            collection.AddLocation("location", new Airport("Location", "Location"));
            Assert.IsTrue(collection.ListLocations().ToLower().Contains("location"));
        }
    }
}

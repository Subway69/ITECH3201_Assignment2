using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WITWICS.Entity;

namespace WITWICSTest.Entity
{
    [TestClass]
    public class DestinationCollectionTest
    {
        private DestinationCollection collection;
        private Location location;

        [TestInitialize]
        public void Init()
        {
            collection = new DestinationCollection();
            location = new Location("some area", "destination");
        }

        [TestMethod]
        public void It_Adds_The_Destinaation()
        {
            Assert.IsTrue(collection.AddDestination("some-place", new Destination("airport", location)));
        }

        [TestMethod]
        public void It_Finds_The_Destination()
        {
            collection.AddDestination("destination", new Destination("airport", location));
            Assert.IsFalse(collection.GetDestination("destination") == null);
        }

        [TestMethod]
        public void It_Lists_Destination()
        {
            collection.AddDestination("destination", new Destination("destination", location));
            Assert.IsTrue(collection.ListLocations().ToLower().Contains("destination"));
        }
    }
}

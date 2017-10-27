using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WITWICS.Entity;

namespace WITWICSTest.Entity
{
    [TestClass]
    public class AirportCollectionTest
    {
        private AirportCollection collection;

        [TestInitialize]
        public void Init()
        {
            collection = new AirportCollection();

        }

        [TestMethod]
        public void It_Adds_The_Airport()
        {
            Assert.IsTrue(collection.AddAirport("airport", new Airport("airport", "airport")));
        }

        [TestMethod]
        public void It_Finds_The_Airport()
        {
            collection.AddAirport("airport", new Airport("airport", "airport"));
            Assert.IsFalse(collection.GetAirport("airport") == null);
        }

        [TestMethod]
        public void It_Lists_The_Airport()
        {
            collection.AddAirport("airport", new Airport("airport", "airport"));
            Assert.IsTrue(collection.ListAirports().ToLower().Contains("airport"));
        }
    }
}

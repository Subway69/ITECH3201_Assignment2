using Microsoft.VisualStudio.TestTools.UnitTesting;
using WITWICS.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WITWICS.Entity;

namespace WITWICS.Control
{
    [TestClass]
    public class FlightStateTests
    {
        private Detective detective;
        private Airport airport;
        private Location movement;
        private FlightState commandState;

        [TestInitialize]
        public void Init()
        {
            detective = new Detective("johno");
            airport = new Airport("an airport", "airport");
            movement = new Location("a location", "location");
            commandState = new FlightState();
        }

        [TestMethod]
        public void It_Updates_The_FlightState()
        {
            detective.Location = airport;
            Assert.IsTrue(commandState.Update(detective) is FlightState);
            detective.Location = movement;
            Assert.IsTrue(commandState.Update(detective) is MovementState);
        }
    }
}
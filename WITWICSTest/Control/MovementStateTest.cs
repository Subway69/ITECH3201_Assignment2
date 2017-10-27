using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WITWICS.Control;
using WITWICS.Entity;

namespace WITWICSTest.Control
{
    [TestClass]
    public class MovementStateTest
    {
        private Detective detective;
        private Airport airport;
        private Location movement;
        private MovementState commandState;

        [TestInitialize]
        public void Init()
        {
            detective = new Detective("johno");
            airport = new Airport("an airport", "airport");
            movement = new Location("a location", "location");
            commandState = new MovementState();
        }

        [TestMethod]
        public void It_Updates_The_MovementState()
        {
            detective.Location = movement;
            Assert.IsTrue(commandState.Update(detective) is MovementState);
            detective.Location = airport;
            Assert.IsTrue(commandState.Update(detective) is FlightState);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WITWICS.Entity;
using WITWICS.Control;
using System.Collections;

namespace WITWICSTest.Control
{
    [TestClass]
    public class MoveCommandTest
    {
        private MoveCommand command;
        private LocationCollection locationCollection;
        private Detective detective;

        [TestInitialize] 
        public void Init()
        {
            command = new MoveCommand();
            locationCollection = new LocationCollection();
            locationCollection.AddLocation("city", new Location("a city", "city"));
            locationCollection.AddLocation("town", new Location("a town", "town"));
            locationCollection.GetLocation("city").GetDestinationCollection().AddDestination(
                "town", new Destination("a town", locationCollection.GetLocation("town"))
            );
            locationCollection.GetLocation("town").GetDestinationCollection().AddDestination(
                "city", new Destination("a city", locationCollection.GetLocation("city"))
            );
            detective = new Detective("Johno");
            detective.Location = locationCollection.GetLocation("town");
        }

        [TestMethod]
        public void It_Moves_The_Detective()
        {
            ArrayList argument = new ArrayList();
            argument.Add("city");
            command.Execute(new ParsedCommand("move", argument), detective);
            Assert.IsTrue(detective.Location == locationCollection.GetLocation("city"));
            Assert.IsFalse(detective.Location == locationCollection.GetLocation("town"));
        }

        [TestMethod]
        public void It_Requires_A_Destination()
        {
            ArrayList argument = new ArrayList();
            Assert.IsTrue(argument.Count == 0);
            CommandResponse response = command.Execute(new ParsedCommand("move", argument), detective);
            Assert.IsTrue(response.Message.Contains("where you want to move to"));
        }

        [TestMethod]
        public void It_Can_Only_Move_To_A_Known_Destination()
        {
            ArrayList argument = new ArrayList();
            argument.Add("unknown-area");
            CommandResponse response = command.Execute(new ParsedCommand("move", argument), detective);
            Assert.IsTrue(response.Message.ToLower().Contains("i can't move there, try going somewhere else"));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WITWICS.Entity;
using WITWICS.Control;
using System.Collections;

namespace WITWICSTest.Control
{
    [TestClass]
    public class FlyCommandTest
    {
        private FlyCommand command;
        private AirportCollection airportCollection;
        private Detective detective;

        [TestInitialize]
        public void Init()
        {
            command = new FlyCommand();
            airportCollection = new AirportCollection();

            airportCollection.AddAirport("usa", new Airport("usa airport", "usa"));
            airportCollection.AddAirport("aus", new Airport("aus airport", "aus"));

            airportCollection.GetAirport("usa").GetFlightsCollection().AddDestination(
                "aus",
                new Destination("aus airport", airportCollection.GetAirport("aus"))
            );

            airportCollection.GetAirport("aus").GetFlightsCollection().AddDestination(
                "usa",
                new Destination("usa airport", airportCollection.GetAirport("usa"))
            );

            detective = new Detective("Johno");
            detective.Location = airportCollection.GetAirport("usa");
        }

        [TestMethod]
        public void It_Flys_The_Detective()
        {
            ArrayList argument = new ArrayList();
            argument.Add("aus");   
            CommandResponse response = command.Execute(new ParsedCommand("fly", argument), detective);
            Airport location = (Airport)detective.Location;
            Assert.IsTrue(location.Name == airportCollection.GetAirport("aus").Name);
            Assert.IsFalse(location == airportCollection.GetAirport("usa"));
        }

        [TestMethod]
        public void It_Requires_A_Destination()
        {
            ArrayList argument = new ArrayList();
            Assert.IsTrue(argument.Count == 0);
            CommandResponse response = command.Execute(new ParsedCommand("fly", argument), detective);
            Assert.IsTrue(response.Message.Contains("where you want to fly to"));
        }

        [TestMethod]
        public void It_Can_Only_Fly_To_A_Known_Destination()
        {
            ArrayList argument = new ArrayList();
            argument.Add("unknown-area");
            CommandResponse response = command.Execute(new ParsedCommand("fly", argument), detective);
            Assert.IsTrue(response.Message.ToLower().Contains("i can't fly there, try going somewhere else"));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WITWICS.Entity;
using WITWICS.Control;
using System.Collections;

namespace WITWICSTest.Control
{
    [TestClass]
    public class TalkSuspectCommandTest
    {
        private TalkSuspectCommand command;
        private Airport airport;
        private Suspect suspect;
        private Detective detective;

        [TestInitialize]
        public void Init()
        {
            command = new TalkSuspectCommand();

            airport = new Airport("shown down", "airport");
            suspect = new Suspect("Steve", "Male", "Brown", "Blue", "Knitting", "Missing Eye", "Commodore");
            detective = new Detective("Johno");

            airport.Suspect = suspect;
            detective.Location = airport;
        }

        [TestMethod]
        public void It_Talks_With_The_Suspect()
        {
            ArrayList arguments = new ArrayList();
            arguments.Add("steve");
            arguments.Add("hair");
            CommandResponse response = command.Execute(
                new ParsedCommand("talk", arguments),
                detective
            );
            Assert.IsTrue(response.Message.ToLower().Contains("brown hair"));
        }

        [TestMethod]
        public void It_Cant_Talk_To_A_Suspect_That_Doesnt_Exist()
        {
            ArrayList arguments = new ArrayList();
            arguments.Add("john");
            arguments.Add("hair");
            CommandResponse response = command.Execute(
                new ParsedCommand("talk", arguments),
                detective
            );
            Assert.IsTrue(response.Message.ToLower().Contains("isn't here!"));
        }

        [TestMethod]
        public void It_Requires_The_Suspect_Name()
        {
            ArrayList arguments = new ArrayList();
            CommandResponse response = command.Execute(
                new ParsedCommand("talk", arguments),
                detective
            );
            Assert.IsTrue(response.Message.ToLower().Contains("who you want to talk to"));
        }

        [TestMethod]
        public void It_Requires_The_Suspect_Query()
        {
            ArrayList arguments = new ArrayList();
            arguments.Add("steve");
            CommandResponse response = command.Execute(
                new ParsedCommand("talk", arguments),
                detective
            );
            Assert.IsTrue(response.Message.ToLower().Contains("what you want to talk about"));
        }

        [TestMethod]
        public void It_Can_Only_Talk_About_Suspect_Identifiers()
        {
            ArrayList arguments = new ArrayList();
            arguments.Add("steve");
            arguments.Add("wife");
            CommandResponse response = command.Execute(
                new ParsedCommand("talk", arguments),
                detective
            );
            Assert.IsTrue(response.Message.ToLower().Contains("don't want to answer that"));
        }
    }
}

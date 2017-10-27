using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WITWICS.Entity;
using System.Collections;
using WITWICS.Control;

namespace WITWICSTest.Control
{
    [TestClass]
    public class TalkNPCCommandTest
    {
        private TalkNPCCommand command;
        private Location location;
        private NonPlayerCharacter npc;
        private Detective detective;

        [TestInitialize]
        public void Init()
        {
            command = new TalkNPCCommand();

            location = new Location("shown down", "airport");
            npc = new NonPlayerCharacter("Matt", new Clue("Orange hair"));
            detective = new Detective("Johno");
            location.GetNPCCollection().AddNPC("matt", npc);
            detective.Location = location;
        }

        [TestMethod]
        public void It_Talks_With_The_NPC()
        {
            ArrayList arguments = new ArrayList();
            arguments.Add("matt");
            CommandResponse response = command.Execute(
                new ParsedCommand("talk", arguments),
                detective
            );
            Assert.IsTrue(response.Message.ToLower().Contains("orange hair"));
        }

        [TestMethod]
        public void It_Cant_Talk_To_A_NPC_That_Doesnt_Exist()
        {
            ArrayList arguments = new ArrayList();
            arguments.Add("john");
            CommandResponse response = command.Execute(
                new ParsedCommand("talk", arguments),
                detective
            );
            Assert.IsTrue(response.Message.ToLower().Contains("npc doesn't exist"));
        }

        [TestMethod]
        public void It_Requires_The_NPC_Name()
        {
            ArrayList arguments = new ArrayList();
            CommandResponse response = command.Execute(
                new ParsedCommand("talk", arguments),
                detective
            );
            Assert.IsTrue(response.Message.ToLower().Contains("who you want to talk to"));
        }
    }
}

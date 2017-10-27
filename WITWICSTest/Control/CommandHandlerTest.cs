using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WITWICS.Entity;
using WITWICS.Control;

namespace WITWICSTest.Control
{
    [TestClass]
    public class CommandHandlerTest
    {
        private CommandHandler commandHandler;
        private Detective detective;
        // private Location location;
        [TestInitialize]
        public void Init()
        {
            commandHandler = new CommandHandler();
            detective = new Detective("Johnno");
            // location = new Location("A place", "place");
        }

        [TestMethod]
        public void It_Processes_The_Turn()
        {
            CommandResponse response = commandHandler.ProcessTurn("commands", detective);
            // If it has executed the command correctly move should be contained in the message as it is an available command.
            Assert.IsTrue(response.Message.Contains("move"));
            // The game should not have finished though
            Assert.IsFalse(response.FinishedGame);
        }

        [TestMethod]
        public void It_Quits_The_Game()
        {
            CommandResponse response = commandHandler.ProcessTurn("quit", detective);
            Assert.IsTrue(response.Message.ToLower().Contains("quit"));
            // The game should have finished
            Assert.IsTrue(response.FinishedGame);
        }
    }
}

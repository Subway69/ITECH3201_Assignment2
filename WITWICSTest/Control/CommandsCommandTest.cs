using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WITWICS.Entity;
using System.Collections;
using WITWICS.Control;

namespace WITWICSTest.Control
{
    [TestClass]
    public class CommandsCommandTest
    {
        private Detective detective;
        private Hashtable availableCommands;

        [TestInitialize]
        public void Init()
        {
            detective = new Detective("Johno");
            availableCommands = new Hashtable();
            availableCommands.Add("testCommand1", "");
            availableCommands.Add("testCommand2", "");
        }

        [TestMethod]
        public void It_Lists_Available_Commands()
        {
            CommandsCommand commandsCommand = new CommandsCommand(availableCommands);
            CommandResponse response = commandsCommand.Execute(new ParsedCommand("", new ArrayList()), detective);
            Assert.IsTrue(response.Message.Contains("testCommand1"));
            Assert.IsFalse(response.Message.Contains("non-existing-command"));
        }
    }
}

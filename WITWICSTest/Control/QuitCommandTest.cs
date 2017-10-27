using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WITWICS.Entity;
using WITWICS.Control;
using System.Collections;

namespace WITWICSTest.Control
{
    [TestClass]
    public class QuitCommandTest
    {
        private Detective detective;
        private QuitCommand command;

        [TestInitialize]
        public void Init()
        {
            detective = new Detective("Johno");
            command = new QuitCommand();
        }

        [TestMethod]
        public void It_Finishes_The_Game()
        {
            CommandResponse response = command.Execute(new ParsedCommand("", new ArrayList()), detective);
            Assert.IsTrue(response.FinishedGame);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WITWICS.Control;
using System.Collections;

namespace WITWICSTest.Control
{
    [TestClass]
    public class CommandParserTest
    {
        private CommandParser commandParser;
        private CommandParser commandParserIgnoreWords;
        private ArrayList validCommands;
        private ArrayList ignoredWords;

        [TestInitialize]
        public void Init()
        {
            validCommands = new ArrayList();
            validCommands.Add("test");
            validCommands.Add("talk");
            ignoredWords = new ArrayList();
            ignoredWords.Add("lucas");
            commandParser = new CommandParser(validCommands);
            commandParserIgnoreWords = new CommandParser(validCommands, ignoredWords);
        }

        [TestMethod]
        public void It_Parses_The_Command()
        {
            ParsedCommand command = commandParser.Parse("talk john");
            Assert.IsTrue(command.Command.Equals("talk"));
            Assert.IsTrue(command.Arguments.Contains("john"));
            ParsedCommand commandNotValid = commandParser.Parse("I really like john");
            Assert.IsTrue(commandNotValid.Command.Equals(""));
            Assert.IsTrue(commandNotValid.Arguments.Count == 4);

        }

        [TestMethod]
        public void It_Ignores_Words()
        {
            ParsedCommand command = commandParserIgnoreWords.Parse("talk lucas");
            Assert.IsTrue(command.Arguments.Count == 0);
        }
    }
}

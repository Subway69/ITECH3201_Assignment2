using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITWICS.Control
{
    public class CommandParser
    {
        private ArrayList ignoredWords;
        private ArrayList validCommands;

        // TODO: Determine whether or not we should set ignoredWords from within the class, this wouldn't be 
        // a best practice elsewhere due to ignoredWords constantly changing as more commands are added.
        // Perhaps ignored words should be set by each respective command or contained within a dictionary elsewhere.


        // Constructor commented out for now as we determine the best course of action.
        public CommandParser(ArrayList validCommands)
        {
            this.validCommands = validCommands;
            this.ignoredWords = new ArrayList();
        }

        public CommandParser(ArrayList validCommands, ArrayList ignoredWords)
        {
            this.validCommands = validCommands;
            this.ignoredWords = ignoredWords;
        }

        public ParsedCommand Parse(String input)
        {
            // Split our input into each separate word [input.Split() = input.Split(" ")]
            ArrayList inputArray = new ArrayList(input.ToLower().Split());
            // Create the object and assign data to it via setters
            ParsedCommand parsedCommand = new ParsedCommand();
            // TODO: Check variable naming, could it be more clear?
            foreach(string word in inputArray)
            {
                // If it's a valid command then set the command to be the word.
                if(validCommands.Contains(word))
                {
                    // String
                    parsedCommand.Command = word;
                }
                // If the word isn't in our list of ignored words then we will add it as an argument to the command.
                else if(!ignoredWords.Contains(word))
                {
                    // ArrayList
                    parsedCommand.Arguments.Add(word);
                }
            }

            // Return the object once all the data has been set.
            return parsedCommand;
        }
    }
}

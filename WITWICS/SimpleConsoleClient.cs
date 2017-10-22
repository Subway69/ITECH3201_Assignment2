using System;
using WITWICS.Boundary;

namespace WITWICS
{
    class SimpleConsoleClient : IGameClient
    {
        public SimpleConsoleClient()
        {
            Console.Title = "Where in the World?";
            Console.WindowWidth = 150;
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// 
        /// <param name="question"></param>
        public String GetReply(String question)
        {
            Console.Out.Write("\n" + question + " ");
            return Console.In.ReadLine();
        }

        /// 
        /// <param name="message"></param>
        public void ConsoleMessage(String message)
        {
            Console.Out.Write(message);
        }

        public String GetCommand()
        {
            // Write out a template for entering input.
            Console.Out.WriteLine("\n>>> ");
            // Return the users input.
            return Console.In.ReadLine();
        }
    }
}

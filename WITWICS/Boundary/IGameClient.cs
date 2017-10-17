using System;

namespace WITWICS.Boundary
{
    interface IGameClient
    {
        /// <param name="question"></param>
        String GetReply(String question);

        
        /// <param name="message"></param>
        void ConsoleMessage(String message);
    }
}

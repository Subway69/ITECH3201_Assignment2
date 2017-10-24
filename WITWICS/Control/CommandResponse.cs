using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WITWICS.Control
{
    public class CommandResponse
    {
        private string message;
        private bool finishedGame;

        // By default we want the game to continue so unless we specify otherwise continue.
        public CommandResponse(string message)
        {
            Message = message;
            FinishedGame = false;
        }

        // This can be used by commands that would finish the game e.g. Quit or Arrest Suspect
        public CommandResponse(string message, bool finishedGame)
        {
            Message = message;
            FinishedGame = finishedGame;
        }

        public bool FinishedGame
        {
            get => finishedGame;
            set => finishedGame = value;
        }

        public string Message
        {
            get => message;
            set => message = value;
        }
    }
}
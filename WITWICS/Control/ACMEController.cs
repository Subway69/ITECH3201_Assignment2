using System;
using WITWICS.Boundary;
using WITWICS.Entity;

namespace WITWICS.Control
{
    class ACMEController
    {
        private IGameClient gameClient;
        private IGameData gameData;
        private Detective detective;
        private CommandHandler commandHandler;

        public ACMEController(IGameData gameData, IGameClient gameClient)
        {
            this.gameData = gameData;
            this.gameClient = gameClient;
            commandHandler = new CommandHandler();
        }

        public void PrintWelcome()
        {
            gameClient.ConsoleMessage(gameData.GetWelcomeMessage());
        }

        public void SetupDetective()
        {
            gameClient.ConsoleMessage("\nLocation: " + gameData.GetStartingLocation().Name + "\n");
            gameClient.ConsoleMessage("You see before you ");
            gameClient.ConsoleMessage(gameData.GetStartingLocation().Description + "\n");
            String DetectiveName = gameClient.GetReply("Detective at keyboard, please identify yourself: ");
            detective = new Detective(DetectiveName);
            detective.Location = gameData.GetStartingLocation();
            gameClient.ConsoleMessage("You have been identified, " + DetectiveName + "\n\n");
            gameClient.ConsoleMessage("Your current rank is: " + detective.GetRank() + "\n");

            gameClient.GetReply("<< Press Enter to continue >>");
        }

        public void AssignCaseLoad()
        {
            // Extract method: GetGenderNouns?
            String hisher, himher, malefemale;
            if (gameData.GetCurrentCase().Villain.Sex == "Male")
            {
                hisher = "his";
                himher = "him";
                malefemale = "Male";
            }
            else
            {
                hisher = "her";
                himher = "her";
                malefemale = "Female";
            }
            // End Extract Method

            // Use string formatter to make one larger string?
            gameClient.ConsoleMessage("\n*** FLASH ***\n");

            // print out case headline
            gameClient.ConsoleMessage(gameData.GetCurrentCase().Title + " stolen from " + gameData.GetCurrentCase().StartingCity.Name + ".\n\n");


            // print out case description
            gameClient.ConsoleMessage("The treasure has been identified as " + gameData.GetCurrentCase().Description + ".\n\n");

            // print out suspect reported at scene of crime
            gameClient.ConsoleMessage(malefemale + " suspect reported at the scene of the crime.\n\n");

            // print out "Your assignment: Track the thief from <city> to <his / her> hideout and arrest <him / her>
            gameClient.ConsoleMessage("Your assignment: Track the thief from " + gameData.GetCurrentCase().StartingCity.Name + " to " + hisher + " hideout and arrest " + himher + "!\n\n");

            gameClient.ConsoleMessage("Good luck, " + detective.GetRank() + " " + detective.Name + ".");
        }

        public void RunGame()
        {
            PrintWelcome();
            SetupDetective();
            AssignCaseLoad();
            
            while(HandleTurn())
            {
                // Do something
            }
        }

        private bool HandleTurn()
        {
            // Create a command response from the command entered.
            CommandResponse commandResponse = commandHandler.ProcessTurn(
                gameClient.GetCommand(),
                detective
            );

            // Get the message from the command reponse and write it to the client.
            gameClient.ConsoleMessage(commandResponse.Message);

            // Return the opposite of the FinishedGame bool [default: false]
            return !commandResponse.FinishedGame;
        }
    }
}

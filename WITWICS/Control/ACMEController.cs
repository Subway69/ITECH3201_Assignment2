using System;
using WITWICS.Boundary;
using WITWICS.Entity;

namespace WITWICS.Control
{
    class ACMEController
    {
        public IGameClient gameClient;
        public IGameData gameData;
        public Detective theDetective;

        public ACMEController(IGameData gameData, IGameClient gameClient)
        {
            this.gameData = gameData;
            this.gameClient = gameClient;
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
            theDetective = new Detective(DetectiveName);
            gameClient.ConsoleMessage("You have been identified, " + DetectiveName + "\n\n");
            gameClient.ConsoleMessage("Your current rank is: " + theDetective.GetRank() + "\n");

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

            gameClient.ConsoleMessage("Good luck, " + theDetective.GetRank() + " " + theDetective.Name + ".");
        }

        public void RunGame()
        {
            PrintWelcome();
            SetupDetective();
            AssignCaseLoad();

            gameClient.GetReply("<< Press Enter to exit game >>");
        }
    }
}

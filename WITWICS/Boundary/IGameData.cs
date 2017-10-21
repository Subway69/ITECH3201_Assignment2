using System;
using WITWICS.Entity;

namespace WITWICS.Boundary
{
    interface IGameData
    {
        Location GetStartingLocation();
        Case GetCurrentCase();
        String GetWelcomeMessage();
    }
}

using WITWICS.Control;


namespace WITWICS
{
    class Program
    {
        static void Main(string[] args)
        {
            ACMEController theAgency = new ACMEController(new HardCodedData(), new SimpleConsoleClient());
            theAgency.RunGame();
        }
    }
}

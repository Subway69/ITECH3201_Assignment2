using System;
using WITWICS.Boundary;
using WITWICS.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WITWICS
{
    class HardCodedData : IGameData
    {
        private Location startUp;
        private Suspect villian;
        private Case currentCase;

        private AirportCollection airports;
        private LocationCollection locations;
        private Suspect[] suspects;
        private NonPlayerCharacter[] npcs;

        public HardCodedData()
        {
            CreateWorldMap();
        }
        
        // Could use this to clean up objects if we were to be doing multiple cases.
        public virtual void Dispose()
        {
        }


        public Location GetStartingLocation()
        {
            return startUp;
        }

        public Case GetCurrentCase()
        {
            return currentCase;
        }

        public String GetWelcomeMessage()
        {
            return "Carmen's gang has pulled another caper!\nAnd it's up to you to crack the case...\n";
        }

        private void CreateWorldMap()
        {
            CreateAirports();
            CreateLocations();
            CreateDestinations();
            CreateSuspects();
            AssignSuspects();
            villian = AssignVillian();
            CreateNPCS();
            AssignNPCS();

            startUp = airports.GetAirport("acme");

            // Create suspects
            

            // Create case
            currentCase = new Case("Valuable Treasure", "preserved artifacts from Jewish synagogues", villian, airports.GetAirport("china"));
        }

        private void CreateNPCS()
        {
            npcs = new NonPlayerCharacter[6];
            npcs[0] = new NonPlayerCharacter("Matthew", new Clue(
                "has " + villian.Eyes + " eyes"
            ));
            npcs[1] = new NonPlayerCharacter("Aaron", new Clue(
                "has " + villian.Hair + " hair"
            ));
            npcs[2] = new NonPlayerCharacter("Logan", new Clue(
                "enjoys " + villian.Hobby + " in their spare time"
            ));
            npcs[3] = new NonPlayerCharacter("Keira", new Clue(
                "can be identified by their " + villian.Feature
            ));
            npcs[4] = new NonPlayerCharacter("Brianna", new Clue(
                "drove a " + villian.Vehicle
            ));
            npcs[5] = new NonPlayerCharacter("Abbey", new Clue(
                "is a " + villian.Sex
            ));
        }

        private void AssignNPCS()
        {
            // TODO: Implement random assigning of NPCS to locations.
            Location[] theLocations = new Location[locations.GetLocations().Count];
            int i = 0;
            foreach (string locationLabel in locations.GetLocations().Keys)
            {
                theLocations[i] = locations.GetLocation(locationLabel);
                i++;
            }
            Random rand = new Random();
            foreach (NonPlayerCharacter npc in npcs)
            {
                // A random location label
                Location randomLocation = theLocations[rand.Next(0, (theLocations.Length - 1))];

                if (randomLocation.GetNPCCollection().AddNPC((npc.Name.ToLower()), npc))
                    Console.Out.WriteLine("Assigning " + npc.Name + " to " + randomLocation.Name);
                Console.Out.WriteLine(randomLocation.GetNPCCollection().ListNPCs());
            }
        }

        private void CreateSuspects()
        {
            suspects = new Suspect[4];
            suspects[0] = new Suspect("William", "Male", "Brown", "Blue", "Long sandy walks on the beach", "Monobrow", "Commodore");
            suspects[1] = new Suspect("John", "Male", "Blonde", "Blue", "Hunting", "Scar", "Audi");
            suspects[2] = new Suspect("Jessica", "Female", "Blonde", "Brown", "Knitting", "Dimples", "Hyundai");
            suspects[3] = new Suspect("Kate", "Female", "Red", "Green", "Gym", "Muscles", "Rangerover");
        }

        private void AssignSuspects()
        {
            int i = 0;
            foreach(string location in airports.GetAirports().Keys)
            {
                if (!location.Equals("acme"))
                {
                    airports.GetAirport(location).Suspect = suspects[i];
                    i++;
                }
            }
        }

        private Suspect AssignVillian()
        {
            Random rand = new Random();
            return suspects[rand.Next(0, 3)];
        }

        private void CreateAirports()
        {
            airports = new AirportCollection();

            airports.AddAirport("acme", new Airport(
                "A rundown open office, with yellowing paperwork on the desks and note from old investigations written in chalk on the blackboards",
                "ACME Headquarters"
            ));

            airports.AddAirport("australia", new Airport(
                "The land down under",
                "Australia"
            ));

            airports.AddAirport("africa", new Airport(
                "A vast plain filled with wildlife",
                "Africa"
            ));

            airports.AddAirport("china", new Airport(
                "The economical forefront of the world",
                "China"
            ));

            airports.AddAirport("india", new Airport(
                "A land bustling with people",
                "India"
            ));

            LinkAirports();            
        }

        // Iterate through each airport in our hashtable and link them. ???
        private void LinkAirports()
        {
            foreach(string airport in airports.GetAirports().Keys)
            {
                foreach(string destination in airports.GetAirports().Keys)
                {
                    if(!(airport == destination))
                    {
                        // Console.Out.WriteLine("Added airport " + airport + " destination: " + destination);
                        Airport theAirport = airports.GetAirport(airport);
                        Location theDestination = airports.GetAirport(destination);
                        theAirport.GetFlightsCollection().AddDestination(destination, new Destination(
                            theDestination.Description,
                            theDestination
                        ));
                    }
                }
            }
        }

        private void CreateLocations()
        {
            locations = new LocationCollection();

            CreateAustraliaLocations();
            CreateAfricaLocations();
            CreateChinaLocations();
            CreateIndiaLocations();
        }

        private void CreateIndiaLocations()
        {
            locations.AddLocation("newdelhi", new Location(
                "The capital of India",
                "New Delhi"
            ));

            locations.AddLocation("mumbai", new Location(
                "The financial center and largest city in India",
                "Mumbai"
            ));

            locations.AddLocation("chennai", new Location(
                "A very cultural city",
                "Chennai"
            ));
        }

        private void CreateChinaLocations()
        {
            locations.AddLocation("beijing", new Location(
                "The capital of China",
                "Beijing"
            ));

            locations.AddLocation("shanghai", new Location(
                "Shanghai noon was filmed here",
                "Shanghai"
            ));

            locations.AddLocation("shenzhen", new Location(
                "A city known for it's shopping destinations and great bargains",
                "Shenzhen"
            ));
        }

        private void CreateAfricaLocations()
        {
            locations.AddLocation("cairo", new Location(
                "A desert plain covered in pyramids",
                "Cairo"
            ));

            locations.AddLocation("legos", new Location(
                "The largest city in Africa",
                "Legos"
            ));

            locations.AddLocation("johannesburg", new Location(
                "South Africa's biggest city",
                "Johannesburg"
            ));
        }

        private void CreateAustraliaLocations()
        {
            locations.AddLocation("melbourne", new Location(
                "A city filled with trains and trams.",
                "Melbourne"
            ));

            locations.AddLocation("perth", new Location(
                "A city where the sun is always scorching",
                "Perth"
            ));

            locations.AddLocation("sydney", new Location(
                "A city with a large house used for Opera",
                "Sydney"
            ));
        }

        private void CreateDestinations()
        {
            CreateDestinations("australia", new string[] { "sydney", "perth", "melbourne" });
            CreateDestinations("india", new string[] { "mumbai", "newdelhi", "chennai" });
            CreateDestinations("africa", new string[] { "cairo", "legos", "johannesburg" });
            CreateDestinations("china", new string[] { "beijing", "shanghai", "shenzhen" });
        }

        // TODO: Rename method
        private void CreateDestinations(string airport, string[] cities)
        {
            // TODO: Please for the love of god comment out what this does
            foreach(string city in cities)
            {
                airports.GetAirport(airport).GetDestinationCollection().AddDestination(city, new Destination(
                    locations.GetLocation(city).Description,
                    locations.GetLocation(city)
                ));

                locations.GetLocation(city).GetDestinationCollection().AddDestination(airport, new Destination(
                    airports.GetAirport(airport).Description,
                    airports.GetAirport(airport)
                ));
                foreach (string destination in cities)
                {
                    if(!(city == destination))
                    {
                        locations.GetLocation(city).GetDestinationCollection().AddDestination(destination, new Destination(
                            locations.GetLocation(destination).Description,
                            locations.GetLocation(destination)
                        ));
                    }
                }
            }

        }

    }
}

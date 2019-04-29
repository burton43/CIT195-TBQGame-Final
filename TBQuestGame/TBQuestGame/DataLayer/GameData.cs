using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;


namespace TBQuestGame.DataLayer
{
    public static class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                GetID = 1,
                GetName = "Jessie",

                Sex = Player.Gender.Man,
                GetScared = false,
                GetFear = 10,
                Inventory = new ObservableCollection<GameItemQuantity>()
                {

                }
            };
        }
        private static NPC NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.GetID == id);
        }

        public static string InitialMessages(string _messages)
        {

            return _messages;
        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 4 };
        }
        public static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        public static Location[,] GameMap()
        {
            int rows = 1;
            int columns = 14;

            Location[,] mapLocations = new Location[rows, columns];


            mapLocations[0, 0] = new Location()
            {
                GetID = -1,
                GetName = "",
                GetDescription = "",
                GetReachable = false,
                FearPoints = 10,
                Accessible = false
            };
            mapLocations[0, 1] = new Location()
            {
                GetID = 1,
                GetName = "Rear of the Caboose",
                GetDescription = "The end of the train.The exit door on back of the train is welded shut. This is the dishwashers area" +
                " of the kitchen. Stacks of old greasy dishes are piled around the nasty sink. The sink basin is filled with a foul " +
                "green liquid. A dismembered human torso sits upon the floor.",
                GetReachable = true,
                Accessible = false,
                Npcs = new ObservableCollection<NPC>()
                {
                    NpcById(1001),
                },
                RequiredItemsId = 4001,
                FearPoints = 10
            };
            mapLocations[0, 2] = new Location()
            {
                GetID = 2,
                GetName = "Front of the Caboose",
                GetDescription = "The Caboose. It appears to have been used as the kitchen area for the dining car. A acrid stench of rotting" +
                "food hits you in the face as you enter. Trying not to gag you survey the car. There is a large refrigerator here, as well a couple of " +
                "stove ranges, and a microwave. A rat moves about to and fro, totally unafraid of you. There is a door to the rear of the car",
                GetReachable = true,
                Accessible = true,
                FearPoints = 10

            };


            mapLocations[0, 3] = new Location()
            {
                GetID = 3,
                GetName = "Rear of the Dining Car",
                GetDescription = "Spiders scurry away as you enter. Here too the windows are barred. This was obviously a dining car. Table and chairs" +
                " line the train car. The windows are larger than the other parts of the train. Written in dust on one window is 'NO HOPE'.",
                
                GetReachable = true,
                FearPoints = 10,
                Accessible = true
            };
            mapLocations[0, 4] = new Location()
            {
                GetID = 4,
                GetName = "Front of the Dining Car",
                GetDescription = "Cobwebs cover the tables and chairs. Here and there a table or chair is overturned, but for the most part " +
                "it appears to have been abandoned in place. The table cloths that cover the tables are faded by age, but appear to have " +
                "been quite fancy in their day. Silverware sets still sit on the tables that stand up right, and each table holds a " +
                "candleabra.",
                GetReachable = true,
                FearPoints = 10,
                Accessible = true
            };


            mapLocations[0, 5] = new Location()
            {
                GetID = 5,
                GetName = "Rear of the Economy Car",
                GetDescription = "The passenger economy car: the seats are basic and cramped. The whole car smells of mildew and decay. " +
                "A couple of the windows are broken but the bars set across them hold fast. The seats are all empty save one; a skeleton sits " +
                "upright in one of the seats.",
                GetReachable = true,
                FearPoints = 10,
                Accessible = true
            };
            mapLocations[0, 6] = new Location()
            {
                GetID = 6,
                GetName = "Front of the Economy Car",
                GetDescription = "The dust in the air makes your eyes water. Everything is dusty. The cloth seats are moth eaten and dingy." +
                " In a 'Break in case of Emergency box' in the front is a the outline of a crowbar. The crowbar is missing though.",
                GetReachable = true,
                FearPoints = 10,
                Accessible = true
            };
            mapLocations[0, 7] = new Location()
            {
                GetID = 7,
                GetName = "Rear of the First Class Car",
                GetDescription = "The first class car: the car is divided into seperate rooms with booths. Looking into the first two " +
                "booths you find little and less. The booths are nice however, though in a bad need of a cleaning. Each has a window " +
                "and a bunk, and even a small fold out table.",
                GetReachable = true,
                FearPoints = 10,
                Accessible = true
            };
            mapLocations[0, 8] = new Location()
            {
                GetID = 8,
                GetName = "Front of the First Class Car",
                GetDescription = "The first class car: the car is divided into seperate rooms with booths. Your heart skips a beat as you " +
                "walk past booth 3. The booth is awash in what appears to be blood. What are almost assuradly human remains are scattered" +
                "about the inside of the room.",
                GetReachable = true,
                FearPoints = 10,
               
                
                Accessible = true
            };
            mapLocations[0, 9] = new Location()
            {
                GetID = 9,
                GetName = "Rear of the Luggage car",
                GetDescription = "Boxes and crates line the walls. It smells like musty cloth. The boxes are all nailed shut.",
                GetReachable = true,
                FearPoints = 10,
                Accessible = true
            };
            mapLocations[0, 10] = new Location()
            {
                GetID = 10,
                GetName = "Front of the Luggage car",
                GetDescription = "Large suitcases are strewn about. Piles of cloths are strewn about. Under one larger pile of cloths " +
                "a human like figure can be seen.",
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(4001), 1)
                },
                GetReachable = true,
                FearPoints = 10,
                Accessible = true
            };
            mapLocations[0, 11] = new Location()
            {
                GetID = 11,
                GetName = "Cab of the Engine",
                GetDescription = "The front of the train. This is the main engine. Here candles burn on everyavaible surface." +
                " Demonic symbols are scrawled on the floor and ceiling. A doll with your likeness sits in the center of the " +
                "symbols on the floor.",
                GetReachable = true,
                FearPoints = 10,
                Accessible = true
            };
            mapLocations[0, 12] = new Location()
            {
                GetID = 12,
                GetName = "Train Tunnel",
                GetDescription = "You're free! You Win!!",
                GetReachable = true,
                FearPoints = 10,
                Accessible = false
            };
            mapLocations[0, 13] = new Location()
            {
                GetID = 13,
                GetName = "",
                GetDescription = "",
                GetReachable = false,
                FearPoints = 10,
                Accessible = false
            };
            return mapLocations;
        }



        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Items(4001, "Rusted Key", "A key. It is covered in rust.",  "You have opened the rear of the Caboose.", Items.UseActionType.OPENLOCATION),
                new Items(4002, "Crowbar", "A two foot long steel crowbar. Its been painted black.",  "Wedging the the crowbar into the door opening, you pull hard. With a groan the door slides open.", Items.UseActionType.PRYOPEN)
            };
        }
        public static List<NPC> Npcs()
        {
            return new List<NPC>()
            {


                new Habitants()
                {
                    GetID = 1001,
                    GetName = "Limbless Torso",

                    Description = "Its limbes are gone and its caked in dried blood.",
                    Messages = new ObservableCollection<GameItemQuantity>()
                    {
                        
                    
                
                        
                        new GameItemQuantity(GameItemById(4002), 1)
                    },
                    Sights = new List<string>()
                    {
                        "Looking closer you can something is lodged in the torso's esophagus. It appears to be the crowbar.",
                        
                    }
                },

                
            };
        }
            


    }
    }

    

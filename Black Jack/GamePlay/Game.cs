//#define GAME_TEST
namespace Black_Jack {
    public class Game{
        public static Dealer dealer = new Dealer();
        // public static NPC npc1 = new NPC();
        // public NPC npc2 = new NPC();
        //public static Player player = new Player("default name");

        public List<Person> peopleInGame = new List<Person>{dealer};
        
        /// <summary> Set up a player with name, bankroll and bet from console, and add it to the PeopleInGame list. </summary>
        public void SetUpPlayer(){
            #if GAME_TEST
                 System.Console.WriteLine("GetPlayerName is entered");
            #endif
            string? alias = Console.ReadLine();
            //Console.WriteLine(alias);
            while (String.IsNullOrWhiteSpace(alias)){
                Console.WriteLine("No name was entered. Please try again.");
                alias = Console.ReadLine();
            } 
            System.Console.WriteLine("Welcome {0}", alias);
            peopleInGame.Add(new Player(alias));
            #if GAME_TEST 
                System.Console.WriteLine("List of people in game:");
                foreach (Person p in peopleInGame) {System.Console.WriteLine(p.name);}
            #endif
            System.Console.WriteLine("To play, you need to deposit an amount of credits to your bankroll, to be used for betting.");
            System.Console.WriteLine("Please enter an amount of whole numbers between 1.000 and 50.000, excluding dots.");


            string? depositString = Console.ReadLine();
            int deposit;
            while (!int.TryParse(depositString, out deposit) || (deposit < 1000  || deposit > 50000)){
                System.Console.WriteLine("Invalid input. Please enter an integer between 1000 and 50000."); 
                depositString = Console.ReadLine();
            }    

            peopleInGame[1].DepositToBankroll(deposit);
            System.Console.WriteLine("\nThank you! A deposit of {0} credits has been made to your bankroll,\nwhich you can now use to place your bet for the first round.", deposit);
            System.Console.WriteLine("\nThe game can now begin. You will be playing against the dealer.");
        }
        

        public void RunGame(){
             #if GAME_TEST
                 System.Console.WriteLine("Game.RunGame is entered");
             #endif
            bool beginNewRound = true;
            while (beginNewRound) {
                //Starting a new round
                Round r = new Round(peopleInGame);
                //#if GAME_TEST
                //    System.Console.WriteLine("TEST: The deck is now generated:"); r.d.TEST_PrintDeck();
                //#endif
                //after the end of a round:
                // CHECK if new round is wanted.
                System.Console.WriteLine("Do you want to play another round? Enter Y/y for \"yes\" and N/n for \"No\".");
                string? answer = System.Console.ReadLine();
                if (answer == "Y" || answer == "y"){continue;}
                if (answer == "N" || answer == "n"){
                    beginNewRound = false;
                    System.Console.WriteLine("Thank you for playing.");
                    }
                else {
                    beginNewRound = false;
                    System.Console.WriteLine("Invalid input. There is no functionality defined for this.\nThe game will now end.");
                    }
                
                System.Console.WriteLine("The bankroll of each player is as follows:");
                    foreach (Person p in peopleInGame){
                        System.Console.WriteLine("{0}: {1} credits", p.name, p.bankroll);
                    }
                System.Console.WriteLine("Goodbye.");
            }
        }
        
    }
}

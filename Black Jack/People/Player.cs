//#define PLAYER_TEST
namespace Black_Jack {
    public class Player : Person {
        public Player(string nm){
            #if PLAYER_TEST
                System.Console.WriteLine("PLAYER: A new player is being created");
            #endif 
            name = nm;
            isDealer = false;
        }//TODO: also set bet at some point.


        /// <summary> Place bet for that round. </summary>
        public void PlaceBet(){    
            Console.WriteLine("You have {0} credits available in your bankroll.\n Please place your bet.", bankroll);//peopleInRound[1].bankroll);
            string? stringBet = System.Console.ReadLine();
            //TODO: Check for valid string of number characters

            //Convert to Int32
            int credits = Convert.ToInt32(stringBet);
            //Check that the requested amount is available in bankroll
            
            bet = credits;
            bankroll -= credits;
        }

        public void CheckForAce(){
            int count = 0;
            foreach (Card c in hand.cardList){
                count++;
                if(c.cardSymbol is CardSymbol.Ace){
                    Console.WriteLine("Card number {0} in your hand is an Ace! Would you like its value to be 11? Y/N", count);
                    string? reply = Console.ReadLine();

                    //Check for null or whitespace    
                    while (String.IsNullOrWhiteSpace(reply)){
                    Console.WriteLine("No name was entered. Please try again.");
                    reply = Console.ReadLine();
                    }
                    
                    //Ace = 11
                    if (reply == "Y" || reply == "y"){
                        c.cardValue = 11;
                        Console.WriteLine("The Ace of card number {0} now has a value of 11.", count);
                    }

                    //Ace = 1
                    if (reply == "N" || reply == "n"){
                        c.cardValue = 1;
                        Console.WriteLine("The Ace of card number {0} now has a value of 1.", count);
                    }
                    else {Console.WriteLine("Invalid input. There is no functionality defined for this.\nThe Aces card will keep its value of {0}", c.cardValue);}
                }
            }
        }


        public override HandState CheckHand(){
            hand.CalculateTotal();
            switch (hand.total){
                case 21:
                    if (hand.cardList.Count() == 2){
                        System.Console.WriteLine("You have Black Jack!");
                        return HandState.BlackJack;
                    } 
                    else {//(hand.cardList.Count() > 2)
                        System.Console.WriteLine("You have 21!");
                        return HandState.EqualTo21;
                    }
                case > 21: 
                    System.Console.WriteLine("You've gone bust!");
                    return HandState.Bust;
                case < 21:
                    System.Console.WriteLine("You have a total of {0}.", hand.total);
                    return HandState.Below21;
            }
            
        
            //Equals 21 -> Win 1,5 //We change it to x3 instead to get around having to use floats
            
            //Is above 21 -> Bust()

            //Is below 21 -> ChooseAction()
        }


        public  override ActionState ChooseAction(){
            //TODO: implement getting input about choice of action from terminal player.
            System.Console.WriteLine("To add a new card to your hand, enter \"Y\"/\"y\" to \"Hit\". Else enter \"N\"/\"n\" to \"Stay\".");
            string? reply = System.Console.ReadLine();//TDOD:Check for proper input format and type.
            if (reply == "Y" || reply == "y"){return ActionState.Player_Hit;}
            if (reply == "N" || reply == "n"){return ActionState.Player_Stay;}
            System.Console.WriteLine("Invalid choice of action. You will keep your current hand.");
            return ActionState.Player_Stay;
        }
    }
}
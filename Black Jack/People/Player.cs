#define PLAYER_TEST
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
            Console.WriteLine("Please place your bet. You have {0} credits available in your bankroll", bankroll);//peopleInRound[1].bankroll);
            string? stringBet = System.Console.ReadLine();
            //TODO: Check for valid string of number characters

            //Convert to Int32
            int credits = Convert.ToInt32(stringBet);
            //Check that the requested amount is available in bankroll
            
            bet += credits;
            bankroll -= credits;
        }
        public override HandState CheckHand(){
        
            switch (hand.total)
            {
                case 21: 
                    //Win!
                    return HandState.Player_Equals21;
                case > 21: 
                    return HandState.Player_Above21;
                case < 21:
                    return HandState.Player_Below21;
            }
            
        
            //Equals 21 -> Win 1,5 //We change it to x3 instead to get around having to use floats
            
            //Is above 21 -> Bust()

            //Is below 21 -> ChooseAction()
        }


        public  override ActionState ChooseAction(){
            //TODO: implement getting input about choice of action from terminal player.
            System.Console.WriteLine("To add a new card to your hand, enter \"H\"/\"h\" for \"Hit\". Else enter \"S\"/\"s\" to \"Stay\".");
            string? reply = System.Console.ReadLine();//TDOD:Check for proper input format and type.
            if (reply == "H" || reply == "h"){return ActionState.Player_Hit;}
            if (reply == "S" || reply == "s"){return ActionState.Player_Stay;}
            System.Console.WriteLine("Invalid choice of action. You will keep your current hand.");
            return ActionState.Next;
        }
    }
}
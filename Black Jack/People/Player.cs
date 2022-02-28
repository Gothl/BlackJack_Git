#define PLAYER_TEST
namespace Black_Jack {
    public class Player : Person {
        public int Bet {get; set;}
        public Player(string nm){
            #if PLAYER_TEST
                System.Console.WriteLine("PLAYER: A new player is being created");
            #endif 
            name = nm;
        }//TODO: also set bet at some point.


        /// <summary> Choose to hit or stay. </summary>
        public void ChooseAction(string a){
            //Ask for choice of action:

            //if "hit":

            //if "stay"

            //else (invalid input)
        }

        /// <summary> Place bet for that round. </summary>
        public void PlaceBet(int credits){    
            Bet += credits;}
    }
}
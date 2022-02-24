namespace Black_Jack {
    public class Player : Person {
        public int Bet {get; set;}
        public Player(string nm){name = nm;}//TODO: also set bet at some point.
        public void ChooseAction(string a){}
        public void PlaceBet(int b){Bet += b;}
    }
}
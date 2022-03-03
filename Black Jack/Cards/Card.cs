namespace Black_Jack {
    public class Card {
        public int cardValue;
        public CardColor cardColor;//Spades, Hearts, Diamonds or Clubs
        public CardSymbol cardSymbol;


        public void DisplayCard(){
            if(cardValue < 10){
                System.Console.WriteLine("+--------+");
                System.Console.WriteLine("|      {0} |", cardValue);
                System.Console.WriteLine("|        |");
                System.Console.WriteLine("|        |");
                System.Console.WriteLine("| {0}      |", cardValue);
                System.Console.WriteLine("+--------+");
            }
            if(cardValue > 9){
                System.Console.WriteLine("+--------+");
                System.Console.WriteLine("|     {0} |", cardValue);
                System.Console.WriteLine("|        |");
                System.Console.WriteLine("|        |");
                System.Console.WriteLine("| {0}     |", cardValue);
                System.Console.WriteLine("+--------+");
            }
        } 
        public Card(CardSymbol s){
            cardSymbol = s;
            cardValue = (int)cardSymbol;
            //if (cardValue)
        }         
    }
}
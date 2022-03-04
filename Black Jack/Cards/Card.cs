namespace Black_Jack {
    public class Card {
        public int cardValue;
        public string? cardString;
        public CardColor cardColor;//Spades, Hearts, Diamonds or Clubs
        public CardSymbol cardSymbol;

        public ValueAndString? cValueAndString;


        public void DisplayCard(){
            if(cardSymbol is CardSymbol.Ten){
                System.Console.WriteLine("+--------+");
                System.Console.WriteLine("|     {0} |", cardString);
                System.Console.WriteLine("|        |");
                System.Console.WriteLine("|        |");
                System.Console.WriteLine("| {0}     |", cardString);
                System.Console.WriteLine("+--------+");
            }
            else{//if(cardValue < 10 || cardSymbol == J, Q or K){
                System.Console.WriteLine("+--------+");
                System.Console.WriteLine("|      {0} |", cardString);
                System.Console.WriteLine("|        |");
                System.Console.WriteLine("|        |");
                System.Console.WriteLine("| {0}      |", cardString);
                System.Console.WriteLine("+--------+");
            }
            
        } 
        public Card(CardSymbol s){
            cardSymbol = s;
            cValueAndString = Program.cardDictionary[s];
            cardString = cValueAndString.cString;
            cardValue = cValueAndString.value;
            //if (cardValue)
        }         
    }
}
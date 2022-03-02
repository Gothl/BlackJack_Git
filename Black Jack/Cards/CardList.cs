//#define CARD_LIST_TEST
namespace Black_Jack {
    public class CardList {

        //A CardList consists of an array of integers.
        public List<int> cardList = new List<int>();
        
        
        /// <summary> Returns the  amount of "cards" in the CardList </summary>
        public int GetNumberOfCards(){
            #if CARD_ARRAY_TEST
                System.Console.WriteLine("CardList.GetNumberOfCards is entered");
            #endif
            return cardList.Count;
        }

        public void displayCardlist(){
            foreach (int c in cardList){
                if(c < 10){
                    System.Console.WriteLine("+--------+");
                    System.Console.WriteLine("|      {0} |", c);
                    System.Console.WriteLine("|        |");
                    System.Console.WriteLine("|        |");
                    System.Console.WriteLine("| {0}      |", c);
                    System.Console.WriteLine("+--------+");
                }
                if(c > 9){
                    System.Console.WriteLine("+--------+");
                    System.Console.WriteLine("|     {0} |", c);
                    System.Console.WriteLine("|        |");
                    System.Console.WriteLine("|        |");
                    System.Console.WriteLine("| {0}     |", c);
                    System.Console.WriteLine("+--------+");
                }
            }
        }

        #if CARD_LIST_TEST
        /// <summary> Prints all "cards" in the CardList </summary>
        public void TEST_PrintDeck(){
            Console.WriteLine("CardList.TEST_PrintDeck is entered");
            Console.WriteLine("\nThe CardList consists of the following cards:");
            foreach (var i in this.cardList){Console.WriteLine(i);}
        }
        #endif 
    }
}
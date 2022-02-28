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
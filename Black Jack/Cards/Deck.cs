#define DECK_TEST
namespace Black_Jack {
    public class Deck : CardList {
        public bool isEmpty;
        public Deck(){
            #if DECK_TEST
                System.Console.WriteLine("A new deck is being created");
            #endif
            // Create array of 24 copies of numbers between 1 and 9.
            for (var j = 1; j < 10; ++j){
                for (var i = 0; i < 24; ++i){
                    cardList.Add(j);
                }
            }
            //Add the 4*4*6=96 copies of 10 (for the cards 10, J, Q and K) to the array.
            cardList = cardList.Concat(Enumerable.Repeat(10, 96)).ToList();

            #if DECK_TEST
                Console.WriteLine("the new deck has {0} elements", cardList.Count);
            #endif

            //Shuffle Deck
            Random random = new Random();//TODO: possibly get better randomisation solution.
            cardList = cardList.OrderBy(x => random.Next()).ToList();

            #if DECK_TEST
            Console.WriteLine("\n Now all {0} numbers in random order:\n", cardList.Count);
                foreach (var i in cardList){Console.WriteLine(i);}
            #endif
        }    
            
        // Console.WriteLine("\n Now all {0} numbers in random order:\n", cardList.Count);
            // foreach (var i in cardList)
            // {
            //     Console.WriteLine(i);
            // }
            // //Shuffling the deck a second time:
            // cardList.OrderBy(x => random.Next());
            
            // Console.WriteLine("\n All {0} numbers after second shuffling:\n", cardList.Count);
            // foreach (var i in cardList)
            // {
            //     Console.WriteLine(i);
            // }

             //A, 2, 3, 4, 5, 6, 7, 8, 9, 10,  J,  Q,  K
            // int[] cardNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10};
                // int[] fullDeck = cardNumbers.Concat(cardNumbers).Concat(cardNumbers).Concat(cardNumbers).Concat(cardNumbers).ToArray();
                // for (var i = 0; i < 4; i++){ 
                //     fullDeck.Concat(cardNumbers);
                // }   
    }
}
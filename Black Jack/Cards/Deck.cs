#define DECK_TEST
namespace Black_Jack {
    public class Deck : CardList {
        public bool isEmpty;

        public CardList deckOf52CardsList = new CardList();
        public Deck(){
            #if DECK_TEST
                System.Console.WriteLine("A new deck is being created");
            #endif
            deckOf52CardsList.cardList.AddRange(new List<Card>{
                new Card(CardSymbol.Aces),
                new Card(CardSymbol.Two),
                new Card(CardSymbol.Three),
                new Card(CardSymbol.Four),
                new Card(CardSymbol.Five),
                new Card(CardSymbol.Six),
                new Card(CardSymbol.Seven),
                new Card(CardSymbol.Eight),
                new Card(CardSymbol.Nine),
                new Card(CardSymbol.Ten),
                new Card(CardSymbol.Jack),
                new Card(CardSymbol.Queen),
                new Card(CardSymbol.King)
            });

            #if DECK_TEST
                System.Console.WriteLine("\nA single set of 13 cards:\n");
                foreach (Card i in deckOf52CardsList.cardList){
                    System.Console.WriteLine("{0}",i.cardSymbol);
                }
                System.Console.WriteLine("\nEND OF LIST\n");
                System.Console.WriteLine("As cards, they become:");
                deckOf52CardsList.displayCardlist();

                
            #endif
            for (int i = 0; i < 24; i++){
            cardList = cardList.Concat(deckOf52CardsList.cardList).ToList();
            }
            
            // //Create array of 24 copies of numbers between 1 and 9.
            // for (var j = 1; j < 10; ++j){
            //     for (var i = 0; i < 24; ++i){
            //         Card newCard = new Card(j);
            //         cardList.Add(newCard);
            //         //cardList.Add(j);
            //     }
            // }
            // //Add the 4*4*6=96 copies of 10 (for the cards 10, J, Q and K) to the array.
            //cardList = cardList.Concat(Enumerable.Repeat(10, 96)).ToList();
            //cardList = cardList.Concat(Enumerable.Repeat(Card(10), 96)).ToList();

            #if DECK_TEST
                Console.WriteLine("the new deck has {0} elements", cardList.Count);
            #endif

            //Shuffle Deck
            Random random = new Random();//TODO: possibly get better randomisation solution.
            cardList = cardList.OrderBy(x => random.Next()).ToList();

            #if DECK_TEST
            Console.WriteLine("\n Now all {0} numbers in random order:\n", cardList.Count);
                foreach (var i in cardList){Console.WriteLine(i.cardSymbol);}
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
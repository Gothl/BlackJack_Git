#define DEALER_TEST
namespace Black_Jack {
    public class Dealer : Person {
        public Dealer(){
            #if DEALER_TEST
                System.Console.WriteLine("DEALER: A new Dealer i being created");
            #endif
                name="the dealer";
        }
        public int faceDownCardValue;


        /// <summary> Deal cards from deck to player. </summary>
        public void DealCards(Deck d, int n, Person p){//TODO: figure out if you want to use the n here.
            //Take card from deck (move it from Deck to Person P's hand. )
            #if DEALER_TEST
                System.Console.WriteLine("DEALER: Dealer.DealCards is entered");
            #endif
            p.hand.cardList.Add(d.cardList[0]);
            d.cardList.Remove(d.cardList[0]);

            #if DEALER_TEST
                System.Console.WriteLine("DEALER: {0} now has {1} cards in their hand, and there are {2} cards left in the deck.", p.name,  p.hand.cardList.Count, d.cardList.Count);
            #endif
            //
        }
    }
}
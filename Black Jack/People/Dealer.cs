//#define DEALER_TEST
namespace Black_Jack {
    public class Dealer : Person {
        public Dealer(){
            #if DEALER_TEST
                System.Console.WriteLine("DEALER: A new Dealer i being created");
            #endif
                name="the dealer";
                isDealer = true;
        }
        public Card faceDownCardValue = new Card(0);//cardValue set to 0 by deafult. Will be changed when dealer flips card.


        /// <summary> Deal cards from deck to player. </summary>
        public void DealCard(Deck d, Person p){
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
        public override HandState CheckHand(){
            //TODO: Add functionality that chooses what to do with any Aces/1s
            switch (hand.total){
                 case 21:
                    if (hand.cardList.Count() == 2){return HandState.BlackJack;} 
                    else{// (hand.cardList.Count() > 2)
                        return HandState.EqualTo21;
                    }                case > 21:
                    //End round and give winnings to remaining players.
                case < 17:
                    //Take another card
                    return HandState.Dealer_Below17;
                default:
                    return HandState.Below21;
            }
        }

        public  override ActionState ChooseAction(){
            if (CheckHand() is HandState.Dealer_Below17){return ActionState.Dealer_Hit;}
            if (CheckHand() is HandState.Below21){return ActionState.Dealer_Stay;}
            return ActionState.Next;

        }

    }
}
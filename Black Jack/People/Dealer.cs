//#define DEALER_TEST
namespace Black_Jack {
    public class Dealer : Person {
        public Dealer(){
            #if DEALER_TEST
                System.Console.WriteLine("DEALER: A new Dealer i being created");
            #endif
                name="the dealer";
                isDealer = true;
                bankroll = 1000000;
        }
        public Card faceDownCardValue = new Card(0);//cardValue set to 0 by deafult. Will be changed when dealer flips card.


        /// <summary> Deal cards from deck to player. </summary>
        public void DealCard(Deck deck, Person p){
            //Take card from deck (move it from Deck to Person P's hand. )
            #if DEALER_TEST
                System.Console.WriteLine("DEALER: Dealer.DealCards is entered");
            #endif
            p.hand.cardList.Add(deck.cardList[0]);
            deck.cardList.Remove(deck.cardList[0]);

            #if DEALER_TEST
                System.Console.WriteLine("DEALER: {0} now has {1} cards in their hand, and there are {2} cards left in the deck.", p.name,  p.hand.cardList.Count, d.cardList.Count);
            #endif
            //
        }


        public override HandState CheckHand(){
            //TODO: Add functionality that chooses what to do with any Aces/1s
            switch (hand.total){
                 case 21:
                    if (hand.cardList.Count() == 2){
                        System.Console.WriteLine("The dealer has Black Jack!");
                        return HandState.BlackJack;
                        } 
                    else{// (hand.cardList.Count() > 2)
                        System.Console.WriteLine("The dealer has 21!");
                        return HandState.EqualTo21;
                    }                
                case > 21:
                    System.Console.WriteLine("The dealer has gone bust!");
                    return HandState.Bust;
                    //End round and give winnings to remaining players.
                case < 17:
                    //Take another card
                    return HandState.Dealer_Below17;
                default:
                    return HandState.Below21;
            }
        }

        public void HandleAces(){
            
            //if 1 is ace
            //      then ace = 1  if 1 + 2 > 21
            //      and  ace = 11 if 1 + 2 < 22
            //    

            //if 2 is ace

            if ((hand.total+10) < 22){//if there's room for an added 10 in value, then convert ONE Aces
                if (hand.cardList[0].cardSymbol is CardSymbol.Ace && (((hand.cardList[1].cardValue)+11) < 22)){hand.cardList[0].cardValue = 11;}
                //else (if 1 is not ace, check 2 in the same manner)
                if (hand.cardList[1].cardSymbol is CardSymbol.Ace && (((hand.cardList[0].cardValue)+11) < 22)){hand.cardList[1].cardValue = 11;}    
            }
            //else convert none
            //return (false, 0);
            hand.CalculateTotal();
            System.Console.WriteLine("Dealer gave an Aces the value 11.");
        }



        public  override ActionState ChooseAction(){
            if (CheckHand() is HandState.Dealer_Below17){return ActionState.Dealer_Hit;}
            if (CheckHand() is HandState.Below21){return ActionState.Dealer_Stay;}
            return ActionState.Dealer_Stay;

        }

    }
}
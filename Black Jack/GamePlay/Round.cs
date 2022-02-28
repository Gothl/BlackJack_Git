#define ROUND_TEST
namespace Black_Jack {
    public class Round {
        //New list of people for the new round.
        public List<Person> peopleInRound = new List<Person>();

        //New shuffled deck for round.
        //public Deck d = new Deck();


        /// <summary> Add a person to the current round. </summary>
        public void AddPersonToRound(Person p) {
            #if ROUND_TEST
                System.Console.WriteLine("Round.AddPersonToRound is entered");
            #endif
            peopleInRound.Add(p);
        }


        /// <summary> Remove a person from the current round. </summary>
        public void RemovePersonFromRound(Person p) {
            #if ROUND_TEST
                System.Console.WriteLine("Round.RemovePersonFromRound is entered");
            #endif
            peopleInRound.Remove(p);}


        /// <summary> Compare the hands of different players. </summary>
        public void CompareHands(Person p1, Person p2){
            #if ROUND_TEST
                System.Console.WriteLine("Round.CompareHands is entered");
            #endif
        }


        /// <summary> Transfer the winnings from a round.</summary>
        public void TransferWinnings(){//Find some way to calculate winnings/determine them.
            #if ROUND_TEST
                System.Console.WriteLine("Round.TransferWinnings is entered");
            #endif
            foreach (Person p in peopleInRound) {
                //Account/Total
                p.bankroll += p.roundWinnings;
                p.roundWinnings = 0; p.bet = 0;
            }
        }
        /// <summary> Game play in round</summary>
        public Round(){
            Deck deck = new Deck();
            Dealer dealer = (Dealer)peopleInRound[1];
            Player p = (Player)peopleInRound[2];
            //Welcome to the round
        
            //place your bets (foreach) everyone except the dealer
            p.PlaceBet(); 

            //everyone (incl dealer gets one card)
            foreach (Person pers in peopleInRound){
                dealer.DealCard(deck, 1, pers);
            }

            //Everyone (excl. dealer gets one card)
            foreach (Person pers in peopleInRound){
                dealer.DealCard(deck, 1, pers);//TODO: NOT finished! Needs to skip dealer on this one!!!
            }
            //The dealer gets one card facing down (the dealer.faceDownCardValue is set)
            dealer.faceDownCardValue = deck.cardList[0]; deck.cardList.Remove(deck.cardList[0]); 

            //Display the terminal player's cards (and possibly the total?)
            System.Console.WriteLine("Here are the values of the cards in your hand:");//Check for A/1, and give option to change the value.
            p.hand.displayCardlist();

            //check each player for 21 --> the player wins 1½ times their bet from dealer and player is done for the round //TODO: understand, if dealer needs to have a fixed amount of money, or just infinite
            foreach (Person pers in peopleInRound){
                pers.CheckHand();
            }
            //check each player for above 21

            //else (if below 21) dealer asks for action (Hit or Stay) - no limit on how many hits a player can ask for in a turn.(keep asking)

            //After everyone have made their choice to stay, the dealer flips their card (adds it to their hand.cardList)

            //Dealers total now dictates whether they must take another card or not. (below 17 or not)

            //If dealer busts, every remaining player in the round wins twice their bet.

            //If the dealer DOESN'T bust, only players with totals bigger than the dealer win twice their bet AND everyone else loses their bets.

            //HOWEVER! Anyone with th esame total as the dealer, get to keep their bet. (this is a "Push")

            //The round then ends with any winnings being deposited the the players's bankroll.

        } 

    }
}
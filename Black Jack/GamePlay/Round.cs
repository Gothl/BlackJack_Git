#define ROUND_TEST
namespace Black_Jack {
    public class Round {
        //New list of people for the new round.
        public List<Person> peopleInRound = new List<Person>();
        //public List<Player> playersInRound = new List<Player>();

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
                System.Console.WriteLine("Round:TransferWinnings is entered");
            #endif
            foreach (Person p in peopleInRound) {
                //Account/Total
                p.bankroll += p.roundWinnings;
                p.roundWinnings = 0; p.bet = 0;
            }
        }

        /// <summary> Clear old list and populate with all players of the game</summary>
        public void MakeListOfPeopleInNewRound(List<Person> gamePeople){
            peopleInRound = gamePeople;
        }



        /// <summary> Gameplay in round</summary>
        public Round(List<Person> gamePeople){
            MakeListOfPeopleInNewRound(gamePeople);
            //playersInRound = peopleInRound.Skip(1).ToList();
            Deck deck = new Deck();
            // System.Console.WriteLine("number of items on the peopleInRoundList: {0}", peopleInRound.Count);
            Dealer dealer = (Dealer)peopleInRound[0];
            Player p = (Player)peopleInRound[1];
            //Welcome to the round
        
            //place your bets (foreach) everyone except the dealer
            p.PlaceBet(); 

            //everyone (incl dealer gets first card)
            System.Console.WriteLine("The dealer deals the first round of cards.");
            foreach (Person pers in peopleInRound){
                pers.hand.cardList.Clear();//clear hand of remaining cards from any previous round.
                dealer.DealCard(deck, pers);//add first card
            }

            System.Console.WriteLine("Here are the cards in your hand:");//TODO:Check for A/1, and give option to change the value.
            p.hand.displayCardlist();
            System.Console.WriteLine("Dealer's hand is:");
            dealer.hand.displayCardlist();

            //Everyone (excl. dealer gets second card)
            System.Console.WriteLine("The dealer deals the second round of cards.");
            foreach (Person pers in peopleInRound){
                if (!pers.isDealer){
                    dealer.DealCard(deck, pers);
                }
            }

            //The dealer gets one card facing down (the dealer.faceDownCardValue is set)
            dealer.faceDownCardValue = deck.cardList[0]; deck.cardList.Remove(deck.cardList[0]); 

            //Display the terminal player's cards (and possibly the total?)
            System.Console.WriteLine("Here are the cards in your hand:");//TODO:Check for A/1, and give option to change the value.
            p.hand.displayCardlist();

            System.Console.WriteLine("Dealer's hand is:");
            dealer.hand.displayCardlist();
            System.Console.WriteLine("+--------+");
            System.Console.WriteLine("|////////|");
            System.Console.WriteLine("|////////|");
            System.Console.WriteLine("|////////|");
            System.Console.WriteLine("|////////|");
            System.Console.WriteLine("+--------+");



            //OBS! Players cannot possibly have 21 on the first round (unless they choose that, whivh is just illogical, so...)
            //     So logically, the first step would be to ask whether a player wants another card, and THEN checking the cards.
            
            //Ask for action FROM player:
            while (p.isActive) {
                if (p.ChooseAction() is ActionState.Player_Hit){
                    // Player chooses hit:
                    dealer.DealCard(deck, p);//dealer deals one card to the player.
                }
                if (p.ChooseAction() is ActionState.Player_Stay){break;}
            }
                //For later use if more than one player implemented:
                // for (var i = 1; i <peopleInRound.Count; i++){//TODO: OBS! needs to start with players! THEN dealer.

                //     if (peopleInRound[i].ChooseAction() is ActionState.Player_Hit){
                //         //Player chooses hit:
                //         dealer.DealCard(deck, peopleInRound[i]);//dealer deals one card to player with index i.

            //     }
            //     if (peopleInRound[i].ChooseAction() is ActionState.Player_Stay){continue;}//Player i chooses to stay. next player's turnwe go to the next player.
                
                // if(pers.ChooseAction() is ActionState.Dealer_Hit){
                //     dealer.DealCard(deck, dealer);//Deal card, as dealer's total was below 17
                //     dealer.CheckHand();//Check the sum of the new hand.---
                // }

            

            //check each player for 21 --> the player wins 1½ times their bet from dealer and player is done for the round //TODO: understand, if dealer needs to have a fixed amount of money, or just infinite
            foreach (Person pers in peopleInRound){
                if (pers.CheckHand() == HandState.Player_Above21){//The currently player is BUST!

                }
                if (pers.CheckHand() == HandState.Dealer_Above21){//Dealer is BUST! Every remaining player wins twice their bet.

                }


                if (!pers.isDealer){

                }
                if (pers.isDealer){}
                pers.CheckHand();
            }

            //check each player for above 21

            //else (if below 21) dealer asks for action (Hit or Stay) - no limit on how many hits a player can ask for in a turn.(keep asking)

            //After everyone have made their choice to stay, the dealer flips their card (adds it to their hand.cardList)
            System.Console.WriteLine("Dealer flips over the second card, and their deck is now:");
            dealer.hand.cardList.Add(dealer.faceDownCardValue);
            dealer.hand.displayCardlist();
            System.Console.WriteLine("There are {0} cards in the dealer's hand, but this is the printed hand:", dealer.hand.cardList.Count);
            dealer.hand.displayCardlist();
            //Dealers total now dictates whether they must take another card or not. (below 17 or not)

            //If dealer busts, every remaining player in the round wins twice their bet.

            //If the dealer DOESN'T bust, only players with totals bigger than the dealer win twice their bet AND everyone else loses their bets.

            //HOWEVER! Anyone with th esame total as the dealer, get to keep their bet. (this is a "Push")

            //The round then ends with any winnings being deposited the the players's bankroll.
            TransferWinnings();
            // foreach (Person p in r.peopleInRound){ // <-- possibly move this to round class.
            //         if (!p.isActive) {r.RemovePersonFromRound(p);}
            //     }

        } 

    }
}
//#define ROUND_TEST
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


        /// <summary> Compare the player and dealer's hands </summary>
        public GameResult CompareHands(Player p, Dealer d){
            #if ROUND_TEST
                System.Console.WriteLine("Round.CompareHands is entered");
            #endif
            System.Console.WriteLine("player's hand state is {0}, while dealer's i {1}", p.hand.status, d.hand.status);
            switch (p.hand.status, d.hand.status){
                case (HandState.Bust       , _                      ): return GameResult.Player_Bust;
                case ( < HandState.Bust    , HandState.Bust         ): return GameResult.Dealer_Bust;// the < is used as Bust has the highest enumeration.
                case (HandState.BlackJack  , HandState.BlackJack    ): return GameResult.Push;
                case (HandState.EqualTo21  , HandState.BlackJack    ): return GameResult.Dealer_BlackJack;
                case (HandState.BlackJack  , < HandState.BlackJack  ): return GameResult.Player_BlackJack;//BlackJack has higher enumeration than any other from 21 to 2.
                case (< HandState.EqualTo21, < HandState.EqualTo21  ): if(p.hand.total == d.hand.total){return GameResult.Push;}
                                                                       if(p.hand.total <  d.hand.total){return GameResult.Dealer_Wins;}
                                                                       else {//if(p.hand.total >  d.hand.total){
                                                                           return GameResult.Player_Wins;
                                                                    }
                default:
                    return GameResult.Unknown;
            }

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
        public Round(List<Person> gamePeople){//TODO: more encapsulation, less wall of code here.
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
            dealer.faceDownCardValue.cardValue = deck.cardList[0].cardValue; deck.cardList.Remove(deck.cardList[0]); 

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



            //reset player action before each round
            p.action = ActionState.Player_Hit;

            //run loop until player chooses to stay
            while (!(p.action is ActionState.Player_Stay)){
                System.Console.WriteLine("This your hand now:");
                p.hand.displayCardlist();
                //Check for aces and possibly change their values
                p.CheckForAce();
                //Check the total of the hand (also depending on number of cards)
                p.hand.status = p.CheckHand();
                if (!(p.hand.status is HandState.Below21)){
                    break;
                }
                //Ask player if htey want to hit or stay
                p.action = p.ChooseAction();
                if (p.action is ActionState.Player_Hit){
                    //dealer deals player another card
                    dealer.DealCard(deck, p);
                }
            }


            //The dealer's turn
            System.Console.WriteLine("It is now the dealer's turn.");
            //After everyone have made their choice to stay, the dealer flips their card (adds it to their hand.cardList)
            System.Console.WriteLine("Dealer flips over the second card, and their deck is now:");
            dealer.hand.cardList.Add(dealer.faceDownCardValue);
            // dealer.hand.displayCardlist();
            // System.Console.WriteLine("There are {0} cards in the dealer's hand, but this is the printed hand:", dealer.hand.cardList.Count);
            // dealer.hand.displayCardlist();

            System.Console.WriteLine("The dealer's hand is:");
            dealer.hand.displayCardlist();
            //dealer's first ace (not any subsequent) counts as 11. Subsequent ones count as 1.
            dealer.HandleAces();
            //Check dealer's hand status and deal cards if prescribed
            dealer.hand.status = dealer.CheckHand();
            if (dealer.hand.status is HandState.Dealer_Below17){
                //Deal one card to themselves
                dealer.DealCard(deck, dealer);
                //Check dealer's hand status after any addition to the hand.
                dealer.hand.status = dealer.CheckHand();
            }


            GameResult roundResult = CompareHands(p, dealer);
            //If player busts, they loses their bet to the dealer
            if (roundResult is GameResult.Player_Bust){dealer.roundWinnings = p.bet; System.Console.WriteLine("You've gone Bust, and have lost this round. Your bet has been transfered to the dealer."); }

            //If dealer busts, every remaining player in the round wins twice their bet from dealer
            if (roundResult is GameResult.Dealer_Bust){dealer.bankroll-=p.bet*2; p.roundWinnings = p.bet*2; System.Console.WriteLine("The dealer went bust, so you won twice your bet from them."); }

            if (roundResult is GameResult.Dealer_Wins){dealer.roundWinnings = p.bet; System.Console.WriteLine("The dealer won. Your bet has been transfered to them."); }

            //check each player for Black Jack --> the player wins 3 times their bet from dealer
            if (roundResult is GameResult.Dealer_BlackJack){dealer.bankroll-=p.bet*3; p.roundWinnings = p.bet*3; System.Console.WriteLine("BLACK JACK! You got Black Jack and won 3 times you bet from the dealer. Your winnings will be transfer."); }

            //If dealer gets Black Jack, they win 3 times their bet from player
            if (roundResult is GameResult.Player_BlackJack){dealer.roundWinnings = p.bet*3; System.Console.WriteLine("The dealer got Black Jack and won 3 times your bet from you."); }

            //If the dealer DOESN'T bust, only players with totals bigger than the dealer win 4 times their bet AND everyone else loses their bets.
            if (roundResult is GameResult.Player_Wins){dealer.bankroll-=p.bet*4; p.roundWinnings = p.bet*4;System.Console.WriteLine("You won 4 times your bet from the dealer."); }

            //HOWEVER! Anyone with the same total as the dealer, get to keep their bet. (this is a "Push")
            if (roundResult is GameResult.Push){p.roundWinnings = p.bet; System.Console.WriteLine("You had the same total as the dealer, and therefore win your bet back."); }

            //The round then ends with any winnings being deposited the the players's bankroll.
            TransferWinnings();

        } 

    }
}
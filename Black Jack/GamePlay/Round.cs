#define ROUND_TEST
namespace Black_Jack {
    public class Round {
        //New list of people for the new round.
        public List<Person> peopleInRound = new List<Person>();

        //New shuffled deck for round.
        public Deck d = new Deck();


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


        /// <summary> Deposit gamling credits. </summary>
        public void TransferWinnings(){
            #if ROUND_TEST
                System.Console.WriteLine("Round.TransferWinnings is entered");
            #endif
            foreach (Person p in peopleInRound) {
                //Account/Total
                p.bankroll += p.roundWinnings;
                p.roundWinnings = 0; p.bet = 0;
            }
        }
    }
}
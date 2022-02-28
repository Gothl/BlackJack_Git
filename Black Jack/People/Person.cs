namespace Black_Jack {
    public abstract class Person {
        //public int id;
        public string? name;
        public int bankroll, bet, roundWinnings;
        public bool isActive = true;//New people are active by default.
        public Hand hand = new Hand();//New empty CardList for the person's hand of cards.


        /// <summary> Declares the person bust, if the hand total is <= 21. </summary>
        public void Bust() {
            if (hand.total <= 21){
                System.Console.WriteLine("{0} is bust, and has lost this round.", name);
                isActive = false;
            }
        }//TODO: implement different rules for what happens for different people (possibly using an overwrite in the dealer's case)
        

        /// <summary> Deposit gamling credits. </summary>
        public void DepositToBankroll(int credits){bankroll += credits;}


        /// <summary> Withdraw gamling credits. </summary>
        public void WithdrawFromBankroll(int credits){//TODO: Check that that amount is available before calling function.
            // System.Console.WriteLine("Please enter the amount of credits, you wish to withdraw.");
            // System.Console.ReadLine(); 
            bankroll -= credits;}
    }
}
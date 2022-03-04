namespace Black_Jack {
    public class Hand : CardList {
        public int total;
        public HandState status;
        public void CalculateTotal() {
            total = 0;
            foreach (Card c in this.cardList){
                //System.Console.WriteLine("Cardvalue is {0}", c.cardValue);
                total += c.cardValue;
                //System.Console.WriteLine("Total is now {0}", total);
            }
        }
                
    }
}
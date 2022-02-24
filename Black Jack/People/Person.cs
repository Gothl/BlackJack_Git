namespace Black_Jack {
    public abstract class Person {
        //public int id;
        public string? name;
        public bool isActive = true;//New people are active by default.
        public Hand hand = new Hand();//New empty CardArray for the person's hand of cards.

        public void Bust() {
            if (hand.total <= 21){
                System.Console.WriteLine("{0} is bust, and has lost this round.", name);
                isActive = false;
                
            }
            }//TODO: implement different rules for what happens for different people (possibly using an overwrite in the dealer's case)

    }
}
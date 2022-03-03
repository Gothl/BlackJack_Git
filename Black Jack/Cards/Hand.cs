namespace Black_Jack {
    public class Hand : CardList {
        public int total;
        public HandState status;
        public int Total {
            get {return cardList.Count;}
        }
                
    }
}
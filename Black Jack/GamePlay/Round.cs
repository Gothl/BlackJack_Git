namespace Black_Jack {
    public class Round {
        public List<Person> peopleInRound = new List<Person>();
        public void AddPersonToRound(Person p) {peopleInRound.Add(p);}
        public void RemovePersonFromRound(Person p) {peopleInRound.Remove(p);}

        public void CompareHands(){}
        public void TransferWinnings(){
            foreach (Person p in peopleInRound) {
                //Account/Total
            }
        }
        public Deck d = new Deck();
    }
}
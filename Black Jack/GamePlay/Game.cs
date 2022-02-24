namespace Black_Jack {
    public class Game{
        public static Dealer dealer = new Dealer();
        // public static NPC npc1 = new NPC();
        // public NPC npc2 = new NPC();
        //public static Player player = new Player("default name");//TODO: console.readline()

        public List<Person> PeopleInGame = new List<Person>{dealer};
        
        public void GetPlayerName(){
            string? alias = Console.ReadLine();
            Console.WriteLine(alias);
            //if (alias = null) //TODO: Add better check for empty string/NULL
            while (alias.Length == 0){
                Console.WriteLine("No name was entered. Please try again.");
                alias = Console.ReadLine();
            } 
            PeopleInGame.Add(new Player(alias));
        }
        public void RunGame(){
            //whie 
            Round r = new Round();//TODO: support for multiple rounds.
            System.Console.WriteLine("TEST: The deck is now generated:");
            r.d.TEST_PrintDeck();
            foreach (Person p in r.peopleInRound){
                if (!p.isActive) {r.RemovePersonFromRound(p);}
            }
        }
        
    }
}

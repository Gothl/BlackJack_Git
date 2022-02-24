namespace Black_Jack {
    public class CardArray {
        public int[] arr = {};
        public int GetNumberOfCards(){return arr.Length;}

        public void TEST_PrintDeck(){
            Console.WriteLine("\n Now all {0} numbers in random order:\n", this.arr.Length);
            foreach (var i in this.arr)
            {
                Console.WriteLine(i);
            }
        }
    }
}
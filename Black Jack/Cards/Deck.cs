namespace Black_Jack {
    public class Deck : CardArray {
        public bool isEmpty;
        public Deck(){
            // Create array of 24 copies of numbers between 1 and 9.
            //int[] arr = {};
            for (var j = 1; j < 10; ++j){
                for (var i = 0; i < 24; ++i){
                    arr = arr.Append(j).ToArray();
                }
            }
            //Add the 4*4*6=96 copies of 10 (for the cards 10, J, Q and K) to the array.
            arr = arr.Concat(Enumerable.Repeat(10, 96)).ToArray();


            // Testprint of all numbers/cards
            // Array.ForEach(arr, Console.WriteLine);
            // Testcount of all cards.
            // Console.WriteLine("the array has {0} elements",arr.Length);
            
            // for (var i = 1; i < arr.Length; i++)
            // arr[i] = i;

            //Shuffle Deck
            Random random = new Random();//TODO: possibly get better randomisation solution.
            arr = arr.OrderBy(x => random.Next()).ToArray();
        }    
            
        // Console.WriteLine("\n Now all {0} numbers in random order:\n", arr.Length);
            // foreach (var i in arr)
            // {
            //     Console.WriteLine(i);
            // }
            // //Shuffling the deck a second time:
            // arr = arr.OrderBy(x => random.Next()).ToArray();
            
            // Console.WriteLine("\n All {0} numbers after second shuffling:\n", arr.Length);
            // foreach (var i in arr)
            // {
            //     Console.WriteLine(i);
            // }

             //A, 2, 3, 4, 5, 6, 7, 8, 9, 10,  J,  Q,  K
            // int[] cardNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10};
                // int[] fullDeck = cardNumbers.Concat(cardNumbers).Concat(cardNumbers).Concat(cardNumbers).Concat(cardNumbers).ToArray();
                // for (var i = 0; i < 4; i++){ 
                //     fullDeck.Concat(cardNumbers);
                // }   
    }
}
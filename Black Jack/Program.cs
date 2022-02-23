namespace Black_Jack{
    class Program{
        static void Main(string[] args)
        {                       //A, 2, 3, 4, 5, 6, 7, 8, 9, 10,  J,  Q,  K
            // int[] cardNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10};
            // int[] fullDeck = cardNumbers.Concat(cardNumbers).Concat(cardNumbers).Concat(cardNumbers).Concat(cardNumbers).ToArray();
            // for (var i = 0; i < 4; i++){ 
            //     fullDeck.Concat(cardNumbers);
            // }
            
            // Create array of 24 copies of numbers between 1 and 9 and 4*4*6=96 copies of 10 (for the cards 10, J, Q and K)
            int[] fullDeck = {};
            for (var j = 1; j < 10; ++j){
                for (var i = 0; i < 24; ++i){
                    fullDeck = fullDeck.Append(j).ToArray();
                }
            }
            fullDeck = fullDeck.Concat(Enumerable.Repeat(10, 96)).ToArray();
            // Testprint of all numbers/cards
            Array.ForEach(fullDeck, Console.WriteLine);
            // Testcount of all cards.
            Console.WriteLine("the array has {0} elements",fullDeck.Length);
            
            // for (var i = 1; i < fullDeck.Length; i++)
            // fullDeck[i] = i;
            Random random = new Random();//TODO: possibly get better randomisation solution.
            fullDeck = fullDeck.OrderBy(x => random.Next()).ToArray();
            
            Console.WriteLine("\n Now all {0} numbers in random order:\n", fullDeck.Length);
            foreach (var i in fullDeck)
            {
                Console.WriteLine(i);
            }
            // //Shuffling the deck a second time:
            // fullDeck = fullDeck.OrderBy(x => random.Next()).ToArray();
            
            // Console.WriteLine("\n All {0} numbers after second shuffling:\n", fullDeck.Length);
            // foreach (var i in fullDeck)
            // {
            //     Console.WriteLine(i);
            // }
        }
    }
} 

// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
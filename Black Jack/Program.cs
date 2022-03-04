//#define MYTEST
namespace Black_Jack{
    internal class Program{
        public static Dictionary<CardSymbol, ValueAndString> cardDictionary = new Dictionary<CardSymbol, ValueAndString>();
        static void Main(string[] args){
            cardDictionary.Add(CardSymbol.Ace  , new ValueAndString(1 ,"A" ));
            cardDictionary.Add(CardSymbol.Two  , new ValueAndString(2 ,"2" ));
            cardDictionary.Add(CardSymbol.Three, new ValueAndString(3 ,"3" ));
            cardDictionary.Add(CardSymbol.Four , new ValueAndString(4 ,"4" ));
            cardDictionary.Add(CardSymbol.Five , new ValueAndString(5 ,"5" ));
            cardDictionary.Add(CardSymbol.Six  , new ValueAndString(6 ,"6" ));
            cardDictionary.Add(CardSymbol.Seven, new ValueAndString(7 ,"7" ));
            cardDictionary.Add(CardSymbol.Eight, new ValueAndString(8 ,"8" ));
            cardDictionary.Add(CardSymbol.Nine , new ValueAndString(9 ,"9" ));
            cardDictionary.Add(CardSymbol.Ten  , new ValueAndString(10,"10"));
            cardDictionary.Add(CardSymbol.Jack , new ValueAndString(10,"J" ));
            cardDictionary.Add(CardSymbol.Queen, new ValueAndString(10,"Q" ));
            cardDictionary.Add(CardSymbol.King , new ValueAndString(10,"K" ));


            #if MYTEST 
                System.Console.WriteLine("MYTEST MODE IN PROGRAM");
            #endif

            System.Console.WriteLine("\n+------------------------+\n| Welcome to Black Jack! |\n+------------------------+\n");
            System.Console.WriteLine("The rules are as follows:\n");
            System.Console.WriteLine("To start the game, please enter your name and press enter."); 
            Game game = new Game(); 
            game.SetUpPlayer();
            game.RunGame();    
        }
    }
}
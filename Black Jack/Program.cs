#define MYTEST
namespace Black_Jack{
    internal class Program{
        static void Main(string[] args){
            #if MYTEST 
                System.Console.WriteLine("MYTEST MODE IN PROGRAM");
            #endif
            System.Console.WriteLine("\n+------------------------+\n| Welcome to Black Jack! |\n+------------------------+\n");
            System.Console.WriteLine("The rules are as follows:\n");
            System.Console.WriteLine("To start the game, please enter you prefered name and press enter."); 
            Game game = new Game(); 
            game.GetPlayerName();        
        }
    }
}
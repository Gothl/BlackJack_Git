namespace Black_Jack{
    internal class Program{
        static void Main(string[] args){
            System.Console.WriteLine("Welcome to Black Jack.\n To start the game, please enter you prefered name and press enter.");  
            Game game = new Game(); 
            game.GetPlayerName();        
        }
    }
}
namespace Black_Jack{
    public enum HandState{
        Dealer_Below17,
        Below21,
        EqualTo21,
        BlackJack,
        Bust
    }

    public enum ActionState{
        Dealer_Hit,
        Dealer_Stay,
        Player_Hit,
        Player_Stay,
        Next
    }

    public enum GameResult{
        Player_Bust,
        Dealer_Bust,
        Push,
        Player_BlackJack,
        Dealer_BlackJack,
        Player_Wins,
        Dealer_Wins,
        Unknown

    }
}
namespace Black_Jack {
    public class NPC : Person {
        //might use this class in later implementation
        public NPC(){name="NPC"; isDealer = false;}//TODO: get better solution for numbering of NPC, in case there is more than one.
        public override HandState CheckHand(){throw new NotImplementedException();}

        public  override ActionState ChooseAction(){throw new NotImplementedException();}

    }
}
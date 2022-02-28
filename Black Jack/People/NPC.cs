namespace Black_Jack {
    public class NPC : Person {
        //might use this class in later implementation
        public NPC(){name="NPC";}//TODO: get better solution for numbering of NPC, in case there is more than one.
        public override HandState CheckHand(){throw new NotImplementedException();}
    }
}
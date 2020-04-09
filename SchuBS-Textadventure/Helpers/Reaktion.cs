using SchuBS_Textadventure.Objects;

namespace SchuBS_Textadventure.Helpers
{
    public class Reaktion
    {
        public BaseObject Ziel { get; set; }
        public int LP { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string ItemName { get; set; }
        public int Schaden { get; set; }
        public bool IsDead { get; set; }

        public Reaktion Copy()
        {
            return new Reaktion
            {
                Ziel = Ziel,
                LP = LP,
                Text1 = Text1,
                Text2 = Text2,
                Text3 = Text3,
                Schaden = Schaden,
                IsDead = IsDead
            };
        }
    }
}

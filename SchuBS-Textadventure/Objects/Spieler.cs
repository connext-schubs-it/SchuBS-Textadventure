using SchuBS_Textadventure.Objects;

namespace SchuBS_IT_2020
{
    public class Spieler : BaseObject
    {
        public Klasse Klasse { get; set; } = Klasse.GetByKlassenTyp(KlassenTyp.Keine);
        public int Level { get; set; }
        public string[] Inventar { get; set; }
        public State state = State.kampf;

        public enum State
        {
            kampf
        }
    }
}

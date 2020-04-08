using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchuBS_Textadventure.Objects
{
    public class Spieler : BaseObject
    {
        public Klasse Klasse { get; set; } = Klasse.GetByKlassenTyp(KlassenTyp.Keine);
        public int Level { get; set; }
        public State state = State.kampf;

        public enum State
        {
            kampf
        }
        public IList<Item> Inventar { get; } = new ObservableCollection<Item>();
    }
}

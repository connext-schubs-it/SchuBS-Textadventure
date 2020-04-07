using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchuBS_Textadventure.Objects
{
    public class Spieler
    {
        public string Name { get; set; }
        public Klasse Klasse { get; set; } = Klasse.GetByKlassenTyp(KlassenTyp.Keine);
        public int Lebenspunkte { get; set; }
        public int Level { get; set; }
        public IList<Item> Inventar { get; } = new ObservableCollection<Item>();
    }
}

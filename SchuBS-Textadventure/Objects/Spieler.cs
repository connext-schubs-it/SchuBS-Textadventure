using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchuBS_Textadventure.Objects
{
    public class Spieler : BaseObject
    {
        private Klasse klasse = Klasse.GetByKlassenTyp(KlassenTyp.Keine);

        public Spieler() : base(0, "") { }

        public Klasse Klasse
        {
            get => klasse;
            set
            {
                klasse = value;
                if (Lebenspunkte < Klasse.Lebenspunkte)
                {
                    MaxLebenspunkte = Klasse.Lebenspunkte;
                    Lebenspunkte = Klasse.Lebenspunkte;
                }
            }
        }

        public List<Previous> Level { get; set; } = new List<Previous>();
        public IList<Item> Inventar { get; } = new ObservableCollection<Item>();

        public bool HatItem(string name) => Inventar.Contains(new Item(name));

        public Item HoleItem(string name) => Inventar.FirstOrDefault(item => item.Name == name);

        public bool EntferneItem(string name) => Inventar.Remove(new Item(name));

        public void FuegeItemHinzu(Item item) => Inventar.Add(item);

        public void FuegeLevelHinzu(Previous previous) => Level.Add(previous);

        public bool HatLevel(Previous previous) => Level.Contains(previous);
    }
}

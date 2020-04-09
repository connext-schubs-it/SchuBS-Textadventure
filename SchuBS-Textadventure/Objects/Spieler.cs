using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchuBS_Textadventure.Objects
{
    public class Spieler : BaseObject
    {
        public Klasse Klasse { get; set; } = Klasse.GetByKlassenTyp(KlassenTyp.Keine);
        public int Level { get; set; }
        public IList<Item> Inventar { get; } = new ObservableCollection<Item>();

        public bool HatItem(string name) => Inventar.Contains(new Item(name));

        public Item HoleItem(string name) => Inventar.FirstOrDefault(item => item.Name == name);

        public bool EntferneItem(string name) => Inventar.Remove(new Item(name));

        public void FuegeItemHinzu(Item item) => Inventar.Add(item);
    }
}

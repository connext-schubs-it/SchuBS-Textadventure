using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SchuBS_Textadventure.Objects
{
    public class Spieler : BaseObject
    {
        public Spieler() : base(0, "") { }

        public Klasse Klasse
        {
            get => (Klasse)GetValue(KlasseProperty);
            set
            {
                SetValue(KlasseProperty, value);
                if (Lebenspunkte < Klasse.Lebenspunkte)
                {
                    MaxLebenspunkte = Klasse.Lebenspunkte;
                    Lebenspunkte = Klasse.Lebenspunkte;
                }
            }
        }

        public static readonly DependencyProperty KlasseProperty =
            DependencyProperty.Register("Klasse", typeof(Klasse), typeof(Spieler), new PropertyMetadata(Klasse.GetByKlassenTyp(KlassenTyp.Keine)));

        public List<Previous> Level { get; } = new List<Previous>();
        public IList<Item> Inventar { get; } = new ObservableCollection<Item>();

        public bool HatItem(string name) => Inventar.Contains(new Item(name));

        public Item HoleItem(string name) => Inventar.FirstOrDefault(item => item.Name == name);

        public bool EntferneItem(string name) => Inventar.Remove(new Item(name));

        public void FuegeItemHinzu(Item item) => Inventar.Add(item);

        public void FuegeLevelHinzu(Previous previous) => Level.Add(previous);

        public bool HatLevel(Previous previous) => Level.Contains(previous);
    }
}

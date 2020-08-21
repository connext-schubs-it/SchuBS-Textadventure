using System.Collections.Generic;
using System.Windows;

namespace SchuBS_Textadventure.Objects
{
    public class Spieler : SpielerBase
    {
        public Spieler(Klasse defaultKlasse)
        {
            Klasse = defaultKlasse;
        }

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

        // Using a DependencyProperty as the backing store for MyProperty. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KlasseProperty =
            DependencyProperty.Register("Klasse", typeof(Klasse), typeof(Spieler), new PropertyMetadata(Klasse.GetByKlassenTyp(KlassenTyp.Keine)));

        public List<Previous> Level { get; } = new List<Previous>();

        public void FuegeLevelHinzu(Previous previous) => Level.Add(previous);

        public bool HatLevel(Previous previous) => Level.Contains(previous);
    }
}

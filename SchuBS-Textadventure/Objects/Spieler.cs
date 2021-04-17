using System.Collections.Generic;
using System.Windows;

namespace SchuBS_Textadventure.Objects
{
    public class Spieler : SpielerBase
    {
        /// <summary>
        /// Standard ist <see cref="KlassenTyp.Keine"/>.
        /// </summary>
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
            DependencyProperty.Register(nameof(Klasse), typeof(Klasse), typeof(Spieler), new PropertyMetadata(Klasse.GetByKlassenTyp(KlassenTyp.Keine)));

        public List<Level> Level { get; } = new();

        public void FuegeLevelHinzu(Level previous) => Level.Add(previous);

        public bool HatLevel(Level previous) => Level.Contains(previous);
    }
}

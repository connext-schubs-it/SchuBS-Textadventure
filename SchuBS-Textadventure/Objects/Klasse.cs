using System;
using System.Collections.Generic;

namespace SchuBS_Textadventure.Objects
{
    public enum KlassenTyp
    {
        Keine

        // weitere Klassen
    }

    public class Klasse : IKlasse
    {
        private static Dictionary<KlassenTyp, string> KlassenNamen { get; } = new Dictionary<KlassenTyp, string>
        {
            { KlassenTyp.Keine,                 "wagemutiger Abenteurer" }

            // weitere Klassen
        };

        public Klasse(int staerke, int verteidigung, int geschicklichkeit, int magie, int mana, int lebenspunkte = 100)
        {
            Lebenspunkte = (lebenspunkte + staerke + verteidigung) / 2;
            Staerke = staerke;
            Verteidigung = verteidigung;
            Geschicklichkeit = geschicklichkeit;
            Magie = magie;
            Mana = mana;
        }

        public int Lebenspunkte { get; set; }
        public int Staerke { get; set; }
        public int Verteidigung { get; set; }
        public int Geschicklichkeit { get; set; }
        public int Magie { get; set; }
        public int Mana { get; set; }

        public KlassenTyp KlassenTyp { get; set; }

        public static Klasse GetByKlassenTyp(KlassenTyp typ)
        {
            Klasse neueKlasse;
            switch (typ)
            {
                case KlassenTyp.Keine:
                    neueKlasse = new Klasse(5, 5, 5, 0, 0, 30);
                    break;

                // hier können weitere Klassen folgen

                default:
                    throw new ArgumentException();
            }

            neueKlasse.KlassenTyp = typ;
            return neueKlasse;
        }

        public override string ToString() => KlassenNamen[KlassenTyp];
    }
}

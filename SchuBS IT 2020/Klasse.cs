using System;

namespace SchuBS_IT_2020
{
    public enum KlassenTyp
    {
        Krieger = 1,
        Waldläufer,
        Magier,
        Assassine,
    }

    public class Klasse
    {
        public Klasse(int staerke, int verteidigung, int geschicklichkeit, int magie, int mana, int lebenspunkte = 100)
        {
            Lebenspunkte = (lebenspunkte + staerke + verteidigung) / 2 ;
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
                case KlassenTyp.Krieger:
                    neueKlasse = new Klasse(20, 20, 5, 2, 3);
                    break;
                case KlassenTyp.Waldläufer:
                    neueKlasse = new Klasse(10, 8, 20, 6, 6);
                    break;
                case KlassenTyp.Magier:
                    neueKlasse = new Klasse(3, 5, 7, 20, 15);
                    break;
                case KlassenTyp.Assassine:
                    neueKlasse = new Klasse(17, 5, 25, 1, 2);
                    break;
                default:
                    throw new ArgumentException();
            }

            neueKlasse.KlassenTyp = typ;
            return neueKlasse;
        }
    }
}

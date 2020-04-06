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
        public Klasse(int staerke, int verteidigung, int geschicklichkeit, int magie, int mana)
        {
            Staerke = staerke;
            Verteidigung = verteidigung;
            Geschicklichkeit = geschicklichkeit;
            Magie = magie;
            Mana = mana;
        }

        public int Staerke { get; set; }
        public int Verteidigung { get; set; }
        public int Geschicklichkeit { get; set; }
        public int Magie { get; set; }
        public int Mana { get; set; }

        public KlassenTyp KlassenTyp { get; set; }

        public static Klasse GetByKlassenTyp(KlassenTyp typ)
        {
            switch (typ)
            {
                case KlassenTyp.Krieger:
                    return new Klasse(20, 20, 5, 2, 3);
                case KlassenTyp.Waldläufer:
                    return new Klasse(10, 8, 20, 6, 6);
                case KlassenTyp.Magier:
                    return new Klasse(3, 5, 7, 20, 15);
                case KlassenTyp.Assassine:
                    return new Klasse(17, 5, 25, 1, 2);
                default:
                    throw new ArgumentException();
            }
        }
    }
}

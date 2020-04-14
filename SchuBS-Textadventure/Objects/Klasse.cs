﻿using System;
using System.Collections.Generic;

namespace SchuBS_Textadventure.Objects
{
    public enum KlassenTyp
    {
        Keine = 0,
        Krieger = 1,
        Waldlaeufer,
        Magier,
        Assassine,
    }

    public class Klasse : IKlasse
    {
        private static Dictionary<KlassenTyp, string> KlassenNamen { get; } = new Dictionary<KlassenTyp, string>
        {
            { KlassenTyp.Keine,                 "wagemutiger Abenteurer" },
            { KlassenTyp.Krieger,               "Krieger" },
            { KlassenTyp.Waldlaeufer,           "Waldläufer" },
            { KlassenTyp.Magier,                "Magier" },
            { KlassenTyp.Assassine,             "Assassine" },
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
                case KlassenTyp.Krieger:
                    neueKlasse = new Klasse(30, 30, 8, 2, 30);
                    break;
                case KlassenTyp.Waldlaeufer:
                    neueKlasse = new Klasse(10, 12, 22, 6, 50);
                    break;
                case KlassenTyp.Magier:
                    neueKlasse = new Klasse(3, 5, 7, 25, 60);
                    break;
                case KlassenTyp.Assassine:
                    neueKlasse = new Klasse(38, 10, 25, 2, 25);
                    break;
                case KlassenTyp.Keine:
                    neueKlasse = new Klasse(5, 5, 5, 0, 0, 30);
                    break;
                default:
                    throw new ArgumentException();
            }

            neueKlasse.KlassenTyp = typ;
            return neueKlasse;
        }

        public override string ToString() => KlassenNamen[KlassenTyp];
    }
}

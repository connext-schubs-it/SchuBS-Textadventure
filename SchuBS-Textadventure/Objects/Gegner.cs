using System.Collections.Generic;

using SchuBS_Textadventure.KampfHelper;

namespace SchuBS_Textadventure.Objects
{
    public enum GegnerTyp
    {
        FeuerdracheStark,
        Ungeheuer,
        Kobolde,
        KoboldAnfuehrer,
        FeuerdracheSchwach
    }

    public class Gegner : GegnerBase
    {
        public Gegner(int maxLebenspunkte, string name) : base(maxLebenspunkte, name)
        {
            TodesText = $"{Name} wurde besiegt!";
        }

        public int Staerke { get; set; }

        public int Verteidigung { get; set; }

        public string Bild { get; set; }

        public GegnerTyp Typ { get; set; }

        public static Gegner GetByTyp(GegnerTyp typ)
        {
            Gegner gegner;
            switch (typ)
            {
                case GegnerTyp.FeuerdracheStark:
                    gegner = new Gegner(100, "Feuerdrache")
                    {
                        Bild = "leer500.png",
                        Staerke = 20,
                        Verteidigung = 10,
                        Reaktionen = new List<Reaktion>()
                        {
                            new Reaktion(lp: 90, "Ha das war ja gar nichts!"),
                            new Reaktion(lp: 60, "Gar nicht mal schlecht!"),
                            new Reaktion(lp: 30, "Ouch!"),
                            new Reaktion(lp: 10, "Aufhören!"),
                        }
                    };
                    break;

                case GegnerTyp.Ungeheuer:
                    gegner = new Gegner(90, "Ungeheuer")
                    {
                        Bild = "tiefsee_ungeheuer.png",
                        Staerke = 16,
                        Verteidigung = 12,
                        Reaktionen = new List<Reaktion>()
                        {
                            new Reaktion(lp: 90, "Ha das war ja gar nichts!"),
                            new Reaktion(lp: 60, "Gar nicht mal schlecht!"),
                            new Reaktion(lp: 30, "Ouch!"),
                            new Reaktion(lp: 10, "Aufhören!"),
                        },
                        ItemReaktionen = new List<Reaktion>()
                        {
                            new Reaktion(itemName: "Nunchakus", schaden: 50, "Oh Nein du bist in Besitz der mächtigen Nunchakus! Hab erbarmen!", "Gnade!")
                        }
                    };
                    break;

                case GegnerTyp.Kobolde:
                    gegner = new Gegner(70, "Kobolde")
                    {
                        Bild = "kobold_handlanger_new.png",
                        Staerke = 6,
                        Verteidigung = 6,
                        TodesText = "Die Kobolde wurden besiegt, aber es ist noch nicht zu ende...",
                    };
                    break;

                case GegnerTyp.KoboldAnfuehrer:
                    gegner = new Gegner(80, "KoboldAnführer")
                    {
                        Bild = "kobold_anfuehrer.png",
                        Staerke = 8,
                        Verteidigung = 8,
                    };
                    break;

                case GegnerTyp.FeuerdracheSchwach:
                    gegner = new Gegner(50, "Feuerdrache")
                    {
                        Bild = "leer500.png",
                        Staerke = 15,
                        Verteidigung = 15,
                    };
                    break;

                default:
                    return null;
            }

            gegner.Typ = typ;
            return gegner;
        }
    }
}

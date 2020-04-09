using System.Collections.Generic;

using SchuBS_Textadventure.Helpers;

namespace SchuBS_Textadventure.Objects
{
    public enum GegnerTyp
    {
        Feuerdrache,
        Ungeheuer,
        Kobolde,
        KoboldAnfuehrer,
    }

    public class Gegner : BaseObject
    {
        public Gegner(int maxLebenspunkte, string name) : base(maxLebenspunkte, name) { ItemReaktionen = new List<Reaktion>(); }

        public int Staerke { get; set; }
        public int Verteidigung { get; set; }

        public string Bild { get; set; }

        public GegnerTyp Typ { get; set; }

        public List<Reaktion> ItemReaktionen { get; set; }

        public static Gegner GetByTyp(GegnerTyp typ)
        {
            Gegner gegner;
            switch (typ)
            {
                case GegnerTyp.Feuerdrache:
                    gegner = new Gegner(100, "Feuerdrache")
                    {
                        Bild = "tiefsee_ungeheuer.png",
                        Staerke = 10,
                        Verteidigung = 10,
                        Reaktionen = new List<Reaktion>()
                        {
                            new Reaktion() { LP = 90, Text1 = "Ha das war ja gar nichts!" },
                            new Reaktion() { LP = 60, Text1 = "Gar nicht mal schlecht!" },
                            new Reaktion() { LP = 30, Text1 = "Ouch!" },
                            new Reaktion() { LP = 10, Text1 = "Aufhören!" }
                        }
                    };
                    break;

                case GegnerTyp.Ungeheuer:
                    gegner = new Gegner(100, "Ungeheuer")
                    {
                        Bild = "tiefsee_ungeheuer.png",
                        Staerke = 1,
                        Verteidigung = 0,
                        Reaktionen = new List<Reaktion>()
                        {
                            new Reaktion() { LP = 90, Text1 = "Ha das war ja gar nichts!" },
                            new Reaktion() { LP = 60, Text1 = "Gar nicht mal schlecht!" },
                            new Reaktion() { LP = 30, Text1 = "Ouch!" },
                            new Reaktion() { LP = 10, Text1 = "Aufhören!" }
                        },
                        ItemReaktionen = new List<Reaktion>()
                        {
                            new Reaktion() { ItemName = "Nunchakus", Schaden = 50, Text1 = "Oh Nein du bist in Besitz der mächtigen Nunchakus! Hab erbarmen!", Text2 = "Gnade!"}
                        }
                    };
                    break;

                case GegnerTyp.Kobolde:
                    gegner = new Gegner(70, "Kobolde")
                    {
                        Bild = "kobold_handlanger_new.png",
                        Staerke = 4,
                        Verteidigung = 3,
                    };
                    break;

                case GegnerTyp.KoboldAnfuehrer:
                    gegner = new Gegner(80, "KoboldAnführer")
                    {
                        Bild = "kobold_anfuehrer.png",
                        Staerke = 6,
                        Verteidigung = 3,
                    };
                    break;

                default:
                    return null;
            }

            gegner.Typ = typ;
            return gegner;
        }

        internal Reaktion GetReaktionAufItem(Item item)
        {
            foreach (Reaktion reakt in ItemReaktionen)
            {
                if (reakt.ItemName.Equals(item.Name))
                {
                    return reakt;
                }

            }
            return null;
        }
    }
}

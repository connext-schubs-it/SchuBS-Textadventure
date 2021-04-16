using System.Collections.Generic;

using SchuBS_Textadventure.KampfHelper;

namespace SchuBS_Textadventure.Objects
{
    public enum GegnerTyp
    {
        Kobolde
        // weitere Gegner
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
            Gegner gegner = typ switch
            {
                case GegnerTyp.Kobolde:
                    gegner = new Gegner(70, "Kobolde")
                    {
                        Bild = "kobold_handlanger_new.png",
                        Staerke = 6,
                        Verteidigung = 6,
                        TodesText = "Die Kobolde wurden besiegt, aber es ist noch nicht zu ende...",
                    };
                    break;

                // hier können weitere Gegner folgen

                default:
                    return null;
            }

            if (gegner != null)
                gegner.Typ = typ;

            return gegner;
        }
    }
}

using SchuBS_Textadventure.Helpers;

using System.Collections.Generic;

namespace SchuBS_Textadventure.Objects
{
    public abstract class BaseObject
    {
        public List<Reaktion> Reaktionen { get; set; } = new List<Reaktion>();
        public List<string> Spezial { get; set; } = new List<string>();
        public string Name { get; set; }
        public int Lebenspunkte { get; set; }

        public Reaktion GetReaktion(int lp, string specialItem, int schaden)
        {
            Reaktion currentMin = new Reaktion() { LP = int.MaxValue };

            foreach (Reaktion item in Reaktionen)
            {
                if (item.LP < currentMin.LP && lp <= item.LP)
                    currentMin = item;
            }

            Reaktion rkt = currentMin.Copy();
            Reaktionen.Remove(currentMin);

            if (!specialItem.Equals(""))
                currentMin.SpecialText = GetSpecialText(specialItem);

            rkt.Von = this;
            rkt.Schaden = schaden;

            return rkt;
        }

        private string GetSpecialText(string specialItem)
        {
            foreach (string line in Spezial)
            {
                string[] splitted = line.Split(':');
                if (splitted[0].Equals(specialItem))
                    return splitted[1];
            }
            return "";
        }

        public Reaktion ErhalteSchaden(int schaden, string item)
        {
            Lebenspunkte -= schaden;
            Reaktion reaktion;

            switch(this)
            {
                case Gegner gegner:
                    reaktion = GetReaktion(Lebenspunkte, item, schaden);
                    break;
                case Spieler spieler:
                    reaktion = new Reaktion()
                    {
                        Von = this,
                        LP = Lebenspunkte,
                        Schaden = schaden
                    };
                    break;
                default:
                    reaktion = new Reaktion()
                    {
                        Von = new Spieler()
                        {
                            Name = "Spieler",
                            Lebenspunkte = 100
                        },
                        LP = Lebenspunkte,
                        Schaden = schaden
                    };
                    break;
            }

            return reaktion;
        }
    }
}

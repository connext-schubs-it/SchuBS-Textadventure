using SchuBS_IT_2020;
using SchuBS_Textadventure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Reaktion reaktion = null;

            if (this.GetType() == typeof(Gegner))
            {
                reaktion = GetReaktion(Lebenspunkte, item, schaden);
            }
            else
            {
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
            }

            return reaktion;
        }
    }
}

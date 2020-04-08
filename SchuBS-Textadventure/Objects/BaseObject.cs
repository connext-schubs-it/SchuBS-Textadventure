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
        public List<Reaktion> reaktionen { get; set; }
        public List<string> spezial { get; set; }
        public string Name { get; set; }
        public int Lebenspunkte { get; set; }

        public Reaktion GetReaktion(int lp, string specialItem, int schaden)
        {
            Reaktion currentMin = new Reaktion() { LP = int.MaxValue };

            foreach (Reaktion item in reaktionen)
            {
                if (item.LP < currentMin.LP && lp <= item.LP)
                    currentMin = item;
            }

            Reaktion rkt = currentMin.Copy();
            reaktionen.Remove(currentMin);

            if (!specialItem.Equals(""))
                currentMin.specialText = GetSpecialText(specialItem);

            rkt.von = this;
            rkt.schaden = schaden;

            return rkt;
        }

        private string GetSpecialText(string specialItem)
        {
            foreach (string line in spezial)
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
                reaktion = this.GetReaktion(Lebenspunkte, item, schaden);
            else
                reaktion = new Reaktion() { von = new Spieler() { Name = "Spieler", Lebenspunkte = 100 }, LP = Lebenspunkte, schaden = schaden };

            return reaktion;
        }
    }
}

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

        public Reaktion GetReaktion(int lp, string specialItem, string name, int schaden)
        {
            Reaktion currentMin = null;

            foreach (Reaktion item in reaktionen)
            {
                if (currentMin == null || item.lp < currentMin.lp && lp <= item.lp)
                    currentMin = item;
            }

            if (!specialItem.Equals(""))
                currentMin.specialText = GetSpecialText(specialItem);

            currentMin.name = name;
            currentMin.schaden = schaden;

            return currentMin;
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
            Reaktion reaktion = new Reaktion();
            if (this.GetType() == typeof(Gegner))
                reaktion = this.GetReaktion(Lebenspunkte, item, Name, schaden);
            else
                reaktion = new Reaktion() { lp = Lebenspunkte, name = "Du", schaden = schaden };

            return reaktion;
        }
    }
}

using SchuBS_Textadventure.Helpers;

using System.Collections.Generic;
using System.Windows;

namespace SchuBS_Textadventure.Objects
{
    public abstract class BaseObject : DependencyObject
    {
        public List<Reaktion> Reaktionen { get; set; } = new List<Reaktion>();
        public List<string> Spezial { get; set; } = new List<string>();
        public string Name { get; set; }

        public int MaxLebenspunkte { get; protected set; }

        public int Lebenspunkte
        {
            get => (int)GetValue(LebenspunkteProperty);
            set => SetValue(LebenspunkteProperty, value);
        }

        // Using a DependencyProperty as the backing store for LebensPunkte.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LebenspunkteProperty =
            DependencyProperty.Register("Lebenspunkte", typeof(int), typeof(BaseObject), new PropertyMetadata(0));

        protected BaseObject(int maxLebenspunkte, string name)
        {
            MaxLebenspunkte = Lebenspunkte = maxLebenspunkte;
            Name = name;
        }

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

            rkt.Ziel = this;
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
                        Ziel = this,
                        LP = Lebenspunkte,
                        Schaden = schaden
                    };
                    break;
                default:
                    reaktion = new Reaktion()
                    {
                        Ziel = new Spieler()
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

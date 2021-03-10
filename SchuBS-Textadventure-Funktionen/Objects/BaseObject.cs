using SchuBS_Textadventure.KampfHelper;

using System;
using System.Collections.Generic;
using System.Windows;

namespace SchuBS_Textadventure.Objects
{
    /// <summary>
    /// Dient als Basisklasse für bestimmte Klassen im Textadventure, z.B. Spieler und Gegner.
    /// </summary>
    public abstract class BaseObject : DependencyObject
    {
        /// <summary>
        /// Eine List mit Reaktionen des Objektes.
        /// </summary>
        public List<Reaktion> Reaktionen { get; set; } = new();

        private List<string> Spezial { get; set; } = new();

        /// <summary>
        /// Der Name des Objektes.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Die Maximalen Lebenspunkte.
        /// </summary>
        public int MaxLebenspunkte { get; protected set; }

        /// <summary>
        /// Die aktuellen Lebenspunkte des Objektes.
        /// </summary>
        public int Lebenspunkte
        {
            get => (int)GetValue(LebenspunkteProperty);
            set => SetValue(LebenspunkteProperty, Math.Max(value, 0));
        }

        /// Using a DependencyProperty as the backing store for LebensPunkte.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LebenspunkteProperty =
            DependencyProperty.Register("Lebenspunkte", typeof(int), typeof(BaseObject), new PropertyMetadata(0));

        /// <summary>
        /// Standard-Konstruktor
        /// </summary>
        /// <param name="maxLebenspunkte"></param>
        /// <param name="name"></param>
        protected BaseObject(int maxLebenspunkte, string name)
        {
            MaxLebenspunkte = Lebenspunkte = maxLebenspunkte;
            Name = name;
        }

        internal Reaktion GetReaktion(int lp, int schaden)
        {
            Reaktion currentMin = new() { LP = int.MaxValue };

            foreach (Reaktion reaktion in Reaktionen)
            {
                if (reaktion.LP < currentMin.LP && lp <= reaktion.LP)
                    currentMin = reaktion;
            }

            Reaktion rkt = currentMin.Clone();
            Reaktionen.Remove(currentMin);

            rkt.Ziel = this;
            rkt.Schaden = schaden;

            return rkt;
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="specialItem"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Das Objekt erhält schaden, und gibt eine Reaktion zurück.
        /// </summary>
        /// <param name="schaden">Die höhe des schadens, den das Objekt erhalten soll.</param>
        /// <returns></returns>
        public Reaktion ErhalteSchaden(int schaden)
        {
            Lebenspunkte -= schaden;
            Reaktion reaktion = this switch
            {
                GegnerBase _ => GetReaktion(Lebenspunkte, schaden),
                SpielerBase _ => new Reaktion()
                {
                    Ziel = this,
                    LP = Lebenspunkte,
                    Schaden = schaden
                },
                _ => new Reaktion()
                {
                    Ziel = null,
                    LP = Lebenspunkte,
                    Schaden = schaden
                },
            };
            return reaktion;
        }
    }
}

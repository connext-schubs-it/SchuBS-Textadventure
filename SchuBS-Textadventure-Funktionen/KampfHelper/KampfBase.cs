using SchuBS_Textadventure.Objects;

using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace SchuBS_Textadventure.KampfHelper
{
    /// <summary>
    /// Die basis Klasse für einen Kampf. Stellt verschiedene Funktionalitäten bereit.
    /// </summary>
    public abstract class KampfBase
    {
        private GegnerBase Gegner { get; set; }
        private SpielerBase Spieler { get; set; }

        /// <summary>
        /// Gibt an, ob der Kampf zuende ist.
        /// </summary>
        public bool IstZuende { get; set; } = false;

        private Zug LetzteAktionVon { get; set; } = Zug.Spieler;

        /// <summary>
        /// Ein Kampf zwischen Spieler und gegner.
        /// </summary>
        /// <param name="spieler"></param>
        /// <param name="gegner"></param>
        protected KampfBase(SpielerBase spieler, GegnerBase gegner)
        {
            Spieler = spieler;
            Gegner = gegner;
        }

        /// <summary>
        /// Das <see cref="Item"/>, dass gerade benutzt wird.
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// Eine Liste von <see cref="string"/>s, die am Ende einer Runde ausgegeben werden.
        /// </summary>
        protected List<string> Ausgabe { get; } = new List<string>();

        private enum Zug
        {
            Spieler,
            Gegner
        }

        /// <summary>
        /// Führt eine Aktion aus.
        /// </summary>
        public void Aktion()
        {
            if (LetzteAktionVon == Zug.Spieler)
            {
                LetzteAktionVon = Zug.Gegner;

                foreach (Button button in TextadventureHelper.ButtonsAktionen)
                {
                    button.IsEnabled = true;
                }
            }
            else
            {
                LetzteAktionVon = Zug.Spieler;
                foreach (Button button in TextadventureHelper.ButtonsAktionen)
                {
                    button.IsEnabled = false;
                }

                AktionAusführen(KampfAktionsTyp.GegnerAngriff);
                Ausgabe.Add("Was wirst du tun?");
                SchreibeAusgabe();
            }
        }

        /// <summary>
        /// Führt eine Aktion des entsprechenden <see cref="KampfAktionsTyp"/>s aus.
        /// </summary>
        /// <param name="typ">Der Typ der Aktion.</param>
        public void AktionAusführen(KampfAktionsTyp typ)
        {
            Reaktion reaktion = null;

            switch (typ)
            {
                case KampfAktionsTyp.SpielerAngriff:
                    reaktion = SchadenAusteilenAngriff();
                    break;
                case KampfAktionsTyp.SpielerMagie:
                    reaktion = SchadenAusteilenMagie();
                    break;
                case KampfAktionsTyp.SpielerItem:
                    reaktion = ItemBenutzen();
                    break;
                case KampfAktionsTyp.GegnerAngriff:
                    reaktion = SchadenErhalten();
                    break;
                case KampfAktionsTyp.GegnerSpezial:
                    reaktion = SpezialAktionAusführen();
                    break;
            }

            Ausgabe.AddRange(reaktion.ReaktionAusgabe(typ, Gegner));
            if (reaktion != null && Spieler.Lebenspunkte > 0 && Gegner.Lebenspunkte > 0)
            {
                Aktion();
            }
            else
            {
                if (Gegner.Lebenspunkte <= 0)
                    Ausgabe.Add(Gegner.TodesText);

                SchreibeAusgabe();
                IstZuende = true;
            }
        }

        /// <summary>
        /// Schreibt den Text aus <see cref="Ausgabe"/> in die ausgabe Textbox.
        /// </summary>
        public void SchreibeAusgabe()
        {
            TextadventureHelper.WriteText(Ausgabe.ToArray());
            Ausgabe.Clear();
        }

        private Reaktion SchadenErhalten()
        {
            int schaden = SchadenBerechnen(KampfAktionsTyp.GegnerAngriff);
            return Spieler.ErhalteSchaden(schaden);
        }

        private Reaktion ItemBenutzen()
        {
            Reaktion reaktion = Gegner.GetReaktionAufItem(Item);

            if (reaktion is null)
            {
                reaktion = new Reaktion($"{Item.Name} hat keine Wirkung auf {Gegner.Name}");
            }
            else
            {
                Gegner.Lebenspunkte -= reaktion.Schaden;
            }

            Item = null;

            return reaktion;
        }

        private Reaktion SchadenAusteilenMagie()
        {
            int schaden = SchadenBerechnen(KampfAktionsTyp.SpielerMagie);
            return Gegner.ErhalteSchaden(schaden);
        }

        private Reaktion SchadenAusteilenAngriff()
        {
            int schaden = SchadenBerechnen(KampfAktionsTyp.SpielerAngriff);
            return Gegner.ErhalteSchaden(schaden);
        }

        private int SchadenBerechnen(KampfAktionsTyp typ)
        {
            int schaden = 10;
            switch (typ)
            {
                case KampfAktionsTyp.SpielerAngriff:
                    schaden = BerechneSchadenNormal();
                    break;
                case KampfAktionsTyp.SpielerMagie:
                    schaden = BerechneSchadenMagie();
                    break;
                case KampfAktionsTyp.GegnerAngriff:
                    schaden = BerechneSchadenGegnerAngriff();
                    break;
            }

            return Math.Max(0, schaden);
        }

        /// <summary>
        /// Berechnet den Schaden für einen Angriff des Gegners.
        /// </summary>
        /// <returns>Den Schaden der zugefügt werden soll.</returns>
        public abstract int BerechneSchadenGegnerAngriff();

        /// <summary>
        /// Berechnet den Schaden für einen normalen Angriff des Spieler.
        /// </summary>
        /// <returns>Den Schaden der zugefügt werden soll.</returns>
        public abstract int BerechneSchadenNormal();

        /// <summary>
        /// Berechnet den Schaden für einen Magie-Angriff des Spieler.
        /// </summary>
        /// <returns>Den Schaden der zugefügt werden soll.</returns>
        public abstract int BerechneSchadenMagie();

        /// <summary>
        /// Berechnet den Schaden für einen spizial Angriff des Gegners.
        /// </summary>
        /// <returns>Den Schaden der zugefügt werden soll.</returns>
        public abstract Reaktion SpezialAktionAusführen();
    }
}

using SchuBS_Textadventure.Objects;

using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace SchuBS_Textadventure.Helpers
{
    public class Kampf
    {
        public Gegner Gegner { get; set; }
        public Spieler Spieler { get; set; }
        public bool IstZuende { get; set; } = false;
        public Zug LetzteAktionVon { get; set; } = Zug.Spieler;
        public Textadventure Adventure { get; set; }
        public Item Item { get; set; }

        private List<string> Ausgabe { get; } = new List<string>();

        public enum Zug
        {
            Spieler,
            Gegner
        }

        public enum AktionsTyp
        {
            SpielerAngriff,
            SpielerMagie,
            SpielerItem,
            GegnerAngriff,
            GegnerSpezial
        }

        public Kampf(Spieler spieler, Gegner gegner, Umgebung umgebung, Textadventure adventure)
        {
            Gegner = gegner;
            Spieler = spieler;
            Adventure = adventure;

            adventure.SetButtonsText("Angriff", "Magie", "Item benutzen");
        }

        public void Aktion()
        {
            if (LetzteAktionVon == Zug.Spieler)
            {
                LetzteAktionVon = Zug.Gegner;

                foreach (Button button in Adventure.ButtonsAktionen)
                {
                    button.IsEnabled = true;
                }

                if (Spieler.Klasse.Magie <= 0)
                {
                    Adventure.ButtonsAktionen[1].IsEnabled = false;
                }
            }
            else
            {
                LetzteAktionVon = Zug.Spieler;
                foreach (Button button in Adventure.ButtonsAktionen)
                {
                    button.IsEnabled = false;
                }

                AktionAusführen(AktionsTyp.GegnerAngriff);
                Ausgabe.Add("Was wirst du tun?");
                SchreibeAusgabe();
            }
        }

        private void SchreibeAusgabe()
        {
            Adventure.WriteText(Ausgabe.ToArray());
            Ausgabe.Clear();
        }

        public void AktionAusführen(AktionsTyp typ)
        {
            Reaktion reaktion = null;

            switch (typ)
            {
                case AktionsTyp.SpielerAngriff:
                    reaktion = SchadenAusteilenAngriff();
                    break;
                case AktionsTyp.SpielerMagie:
                    reaktion = SchadenAusteilenMagie();
                    break;
                case AktionsTyp.SpielerItem:
                    reaktion = ItemBenutzen();
                    break;
                case AktionsTyp.GegnerAngriff:
                    reaktion = SchadenErhalten();
                    break;
                case AktionsTyp.GegnerSpezial:
                    reaktion = SpezialAktionAusführen();
                    break;
            }

            Ausgabe.AddRange(AusgabeHelper.AusgabeReaktion(reaktion, typ, Gegner));
            if (reaktion != null && Spieler.Lebenspunkte > 0 && Gegner.Lebenspunkte > 0)
            {
                Aktion();
            }
            else
            {
                SchreibeAusgabe();
                IstZuende = true;
            }
        }

        private Reaktion SchadenErhalten()
        {
            int schaden = SchadenBerechnen(AktionsTyp.GegnerAngriff);
            return Spieler.ErhalteSchaden(schaden, "");
        }

        private Reaktion ItemBenutzen()
        {
            Reaktion reaktion = Gegner.GetReaktionAufItem(Item);

            if (reaktion == null)
            {
                reaktion = new Reaktion();
                reaktion.Text1 = $"{Item.Name} hat keine Wirkung auf {Gegner.Name}";
            }
            else
                Gegner.Lebenspunkte -= reaktion.Schaden;

            return reaktion;
        }

        private Reaktion SchadenAusteilenMagie()
        {
            int schaden = SchadenBerechnen(AktionsTyp.SpielerMagie);
            return Gegner.ErhalteSchaden(schaden, "");
        }

        public Reaktion SchadenAusteilenAngriff()
        {
            int schaden = SchadenBerechnen(AktionsTyp.SpielerAngriff);
            return Gegner.ErhalteSchaden(schaden, "");
        }

        public int SchadenBerechnen(AktionsTyp typ)
        {
            int schaden = 10;
            switch (typ)
            {
                case AktionsTyp.SpielerAngriff:
                    schaden = BerechneSchadenNormal();
                    break;
                case AktionsTyp.SpielerMagie:
                    schaden = BerechneSchadenMagie();
                    break;
                case AktionsTyp.GegnerAngriff:
                    schaden = BerechneSchadenGegnerAngriff();
                    break;
            }

            return Math.Max(0, schaden);
        }

        private int BerechneSchadenGegnerAngriff()
        {
            return Math.Max(1, Gegner.Staerke - Spieler.Klasse.Verteidigung);
        }

        private int BerechneSchadenNormal()
        {
            return Spieler.Klasse.Staerke - Gegner.Verteidigung;
        }

        private int BerechneSchadenMagie()
        {
            return Spieler.Klasse.Magie - Gegner.Verteidigung;
        }

        public Reaktion SpezialAktionAusführen()
        {
            return null;
        }

        public void Button1Angriff()
        {
            Ausgabe.Add("Du greifst an...");
            AktionAusführen(AktionsTyp.SpielerAngriff);
        }

        public void Button2Magie()
        {
            Ausgabe.Add("Du wirkst Magie...");
            AktionAusführen(AktionsTyp.SpielerMagie);
        }

        public void Button3Item(Item item)
        {
            Item = item;
            Ausgabe.Add("Du nutzt einen Gegenstand...");
            AktionAusführen(AktionsTyp.SpielerItem);
        }
    }
}

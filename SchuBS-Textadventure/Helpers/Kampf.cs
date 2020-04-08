using SchuBS_IT_2020;
using SchuBS_Textadventure.Objects;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuBS_Textadventure.Helpers
{
    public class Kampf
    {
        public Gegner Gegner { get; set; }
        public Spieler Spieler { get; set; }
        public bool Ausgang { get; set; }
        public Zug AnDerReihe { get; set; } = Zug.spieler;
        public Textadventure Adventure { get; set; }

        public enum Zug
        {
            spieler,
            gegner
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
            if (AnDerReihe == Zug.spieler)
            {
                AnDerReihe = Zug.gegner;
                Adventure.Button1.IsEnabled = true;
                Adventure.Button2.IsEnabled = true;
                Adventure.Button3.IsEnabled = true;
            }
            else
            {
                AnDerReihe = Zug.spieler;
                Adventure.Button1.IsEnabled = false;
                Adventure.Button2.IsEnabled = false;
                Adventure.Button3.IsEnabled = false;
                AktionAusführen(AktionsTyp.GegnerAngriff);
                Adventure.WriteText("Was wirst du tun?\r\n");
            }
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

            AusgabeHelper.AusgabeReaktion(Adventure, reaktion, typ, Gegner);
            if (reaktion.Von.Lebenspunkte > 0)
                Aktion();
        }

        private Reaktion SchadenErhalten()
        {
            int schaden = SchadenBerechnen(AktionsTyp.GegnerAngriff);
            return Spieler.ErhalteSchaden(schaden, "");
        }

        private Reaktion ItemBenutzen()
        {
            return null;
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
            switch(typ)
            {
                case AktionsTyp.SpielerAngriff:
                    return BerechneSchadenNormal();
                case AktionsTyp.SpielerMagie:
                    return BerechneSchadenMagie();
                case AktionsTyp.GegnerAngriff:
                    return BerechneSchadenGegnerAngriff();
            }
            return 15;
        }

        private int BerechneSchadenGegnerAngriff()
        {
            return Gegner.Staerke - Spieler.Klasse.Verteidigung;
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

        private void Button1_ClickAngriff(object sender, RoutedEventArgs e)
        {
            Adventure.WriteText("Du greifst an...\r\n");
            AktionAusführen(AktionsTyp.SpielerAngriff);
        }

        private void Button2_ClickMagie(object sender, RoutedEventArgs e)
        {
            Adventure.WriteText("Du wirkst Magie...\r\n");
            AktionAusführen(AktionsTyp.SpielerMagie);
        }

        private void Button3_ClickItem(object sender, RoutedEventArgs e)
        {
            Adventure.WriteText("Du nutzt einen Gegenstand...\r\n");
            AktionAusführen(AktionsTyp.SpielerItem);
        }
    }
}

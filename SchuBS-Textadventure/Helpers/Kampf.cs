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
    class Kampf
    {
        public Gegner gegner { get; set; }
        public Spieler spieler { get; set; }
        public bool ausgang { get; set; }
        public Zug anDerReihe = Zug.spieler;
        public Textadventure adventure;

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
            this.gegner = gegner;
            this.spieler = spieler;
            this.adventure = adventure;

            adventure.Button1.Content = "Angriff";
            adventure.Button2.Content = "Magie";
            adventure.Button3.Content = "Item benutzen";

            adventure.Button1.Click += Button1_ClickAngriff;
            adventure.Button2.Click += Button2_ClickMagie;
            adventure.Button3.Click += Button3_ClickItem;
        }

        public void Aktion()
        {
            if (anDerReihe == Zug.spieler)
            {
                anDerReihe = Zug.gegner;
                adventure.Button1.IsEnabled = true;
                adventure.Button2.IsEnabled = true;
                adventure.Button3.IsEnabled = true;
            }
            else
            {
                anDerReihe = Zug.spieler;
                adventure.Button1.IsEnabled = false;
                adventure.Button2.IsEnabled = false;
                adventure.Button3.IsEnabled = false;
                AktionAusführen(AktionsTyp.GegnerAngriff);
            }
        }

        public void AktionAusführen(AktionsTyp typ)
        {
            Reaktion reaktion = null;

            switch (typ)
            {
                case AktionsTyp.SpielerAngriff:
                    reaktion = SchadenAusteilen();
                    AusgabeHelper.AusgabeSpielerAktion(adventure, reaktion, false);
                    Aktion();
                    break;
                case AktionsTyp.SpielerMagie:
                    reaktion = MagieBenutzen();
                    break;
                case AktionsTyp.SpielerItem:
                    reaktion = ItemBenutzen();
                    break;
                case AktionsTyp.GegnerAngriff:
                    reaktion = SchadenErhalten();
                    AusgabeHelper.AusgabeGegnerAktion(adventure, reaktion, false, gegner);
                    Aktion();
                    break;
                case AktionsTyp.GegnerSpezial:
                    reaktion = SpezialAktionAusführen();
                    break;
            }
        }

        private Reaktion ItemBenutzen()
        {
            throw new NotImplementedException();
        }

        private Reaktion MagieBenutzen()
        {
            throw new NotImplementedException();
        }

        public Reaktion SchadenAusteilen()
        {
            int schaden = SchadenBerechnen();

            return gegner.ErhalteSchaden(schaden, "");

        }

        public Reaktion SchadenErhalten()
        {
            int schaden = SchadenBerechnen();
            return spieler.ErhalteSchaden(schaden, "");
        }

        public int SchadenBerechnen()
        {
            return 15;
        }

        public Reaktion SpezialAktionAusführen()
        {
            return null;
        }

        public string AktionsAusgabe(Reaktion reaktion)
        {
            string AusgabeText = $"{reaktion.name} hat {reaktion.schaden} Schaden erhalten!";
            AusgabeText += $"\r\n{reaktion.text}\r\n";
            return AusgabeText;
        }

        private void Button1_ClickAngriff(object sender, RoutedEventArgs e)
        {
            adventure.WriteText("Du greifst an...\r\n");
            AktionAusführen(AktionsTyp.SpielerAngriff);
        }

        private void Button2_ClickMagie(object sender, RoutedEventArgs e)
        {
            adventure.WriteText("Du wirkst Magie...\r\n");
            AktionAusführen(AktionsTyp.SpielerMagie);
        }

        private void Button3_ClickItem(object sender, RoutedEventArgs e)
        {
            adventure.WriteText("Du nutzt einen Gegenstand...\r\n");
            AktionAusführen(AktionsTyp.SpielerItem);
        }
    }
}

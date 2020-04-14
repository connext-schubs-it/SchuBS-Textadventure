using SchuBS_Textadventure.Objects;

using System;

namespace SchuBS_Textadventure.KampfHelper
{
    public class Kampf : KampfBase
    {
        public Textadventure Adventure { get; set; }

        private Gegner Gegner { get; set; }

        private Spieler Spieler { get; set; }

        public Kampf(Spieler spieler, Gegner gegner, Textadventure adventure) : base(spieler, gegner)
        {
            Gegner = gegner;
            Spieler = spieler;
            Adventure = adventure;

            TextadventureHelper.SetButtonsText("Angriff", "Magie", "Item benutzen");

            if (Spieler.Klasse.Magie <= 0)
            {
                TextadventureHelper.ButtonsAktionen[1].IsEnabled = false;
            }
        }

        public void Button1Angriff()
        {
            Ausgabe.Add("Du greifst an...");
            AktionAusführen(KampfAktionsTyp.SpielerAngriff);
        }

        public void Button2Magie()
        {
            Ausgabe.Add("Du wirkst Magie...");
            AktionAusführen(KampfAktionsTyp.SpielerMagie);
        }

        public void Button3Item(Item item)
        {
            Item = item;
            Ausgabe.Add("Du nutzt einen Gegenstand...");
            AktionAusführen(KampfAktionsTyp.SpielerItem);
        }

        public override int BerechneSchadenGegnerAngriff()
        {
            return Math.Max(1, Gegner.Staerke - (Spieler.Klasse.Verteidigung / 2));
        }

        public override int BerechneSchadenNormal()
        {
            return (Spieler.Klasse.Staerke + (Spieler.Klasse.Geschicklichkeit / 2)) - (Gegner.Verteidigung / 2);
        }

        public override int BerechneSchadenMagie()
        {
            return (Spieler.Klasse.Magie + (Spieler.Klasse.Mana / 2)) - (Gegner.Verteidigung / 2);
        }

        public override Reaktion SpezialAktionAusführen()
        {
            return null;
        }
    }
}

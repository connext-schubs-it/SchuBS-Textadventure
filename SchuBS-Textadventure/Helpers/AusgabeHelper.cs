using SchuBS_Textadventure.Objects;
using System;
using System.Collections.Generic;

namespace SchuBS_Textadventure.Helpers
{
    public static class AusgabeHelper
    {
        public static List<string> AusgabeReaktion(Reaktion reaktion, Kampf.AktionsTyp typ, Gegner gegner)
        {
            List<string> ausgabe;
            switch (typ)
            {
                case Kampf.AktionsTyp.SpielerAngriff:
                case Kampf.AktionsTyp.SpielerMagie:
                    ausgabe = AusgabeSpielerAktion(reaktion);
                    break;
                case Kampf.AktionsTyp.GegnerAngriff:
                    ausgabe = AusgabeGegnerAktion(reaktion, gegner);
                    break;
                case Kampf.AktionsTyp.SpielerItem:
                    ausgabe = AusgabeSpielerItem(reaktion, gegner);
                    break;
                default:
                    ausgabe = new List<string>();
                    break;
            }

            return ausgabe;
        }

        private static List<string> AusgabeSpielerItem(Reaktion reaktion, Gegner gegner)
        {
            List<string> ausgabe = new List<string>();
            if (reaktion.Text1 != null)
                ausgabe.Add($"{gegner.Name}: {reaktion.Text1}");
            if (reaktion.Text2 != null)
                ausgabe.Add($"{gegner.Name}: {reaktion.Text2}");
            if (reaktion.Schaden != 0)
                ausgabe.Add($"{gegner.Name} hat {reaktion.Schaden} Schaden erhalten.");
            if (gegner.Lebenspunkte <= 0)
            {
                ausgabe.Add($"{gegner.Name} wurde besiegt!");
            }

            return ausgabe;
        }

        public static List<string> AusgabeSpielerAktion(Reaktion reaktion)
        {
            List<string> ausgabe = new List<string>();
            if (reaktion.Text1 == null)
            {
                ausgabe.Add($"{reaktion.Ziel.Name} hat {reaktion.Schaden} Schaden erhalten.");
            }
            else
            {
                ausgabe.Add($"{reaktion.Ziel.Name} hat {reaktion.Schaden} Schaden erhalten.");
                ausgabe.Add($"{reaktion.Ziel.Name}: {reaktion.Text1}");
            }

            if (reaktion.Ziel.Lebenspunkte <= 0)
            {
                ausgabe.Add($"{reaktion.Ziel.Name} wurde besiegt!");
            }

            return ausgabe;
        }

        public static List<string> AusgabeGegnerAktion(Reaktion reaktion, Gegner gegner)
        {
            List<string> ausgabe = new List<string>();
            ausgabe.Add($"{gegner.Name} greift dich an...");
            ausgabe.Add($"Du hast {reaktion.Schaden} Schaden erhalten.\r\n");

            if (reaktion.Ziel.Lebenspunkte <= 0)
            {
                ausgabe.Add("Du wurdest besiegt!");
            }

            return ausgabe;
        }
    }
}

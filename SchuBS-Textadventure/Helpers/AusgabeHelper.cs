using SchuBS_Textadventure.Objects;

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
                default:
                    ausgabe = new List<string>();
                    break;
            }

            return ausgabe;
        }

        public static List<string> AusgabeSpielerAktion(Reaktion reaktion)
        {
            List<string> ausgabe = new List<string>();
            if (reaktion.Text == null)
            {
                ausgabe.Add($"{reaktion.Von.Name} hat {reaktion.Schaden} Schaden erhalten.");
            }
            else
            {
                ausgabe.Add($"{reaktion.Von.Name} hat {reaktion.Schaden} Schaden erhalten.");
                ausgabe.Add($"{reaktion.Von.Name}: {reaktion.Text}");
            }

            if (reaktion.Von.Lebenspunkte <= 0)
            {
                ausgabe.Add($"{reaktion.Von.Name} wurde besiegt!");
            }

            return ausgabe;
        }

        public static List<string> AusgabeGegnerAktion(Reaktion reaktion, Gegner gegner)
        {
            List<string> ausgabe = new List<string>();
            ausgabe.Add($"{gegner.Name} greift dich an...");
            ausgabe.Add($"Du hast {reaktion.Schaden} Schaden erhalten.\r\n");

            if (reaktion.Von.Lebenspunkte <= 0)
            {
                ausgabe.Add("Du wurdest besiegt!");
            }

            return ausgabe;
        }
    }
}

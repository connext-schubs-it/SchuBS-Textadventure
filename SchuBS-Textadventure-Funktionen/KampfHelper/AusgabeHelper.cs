using SchuBS_Textadventure.Objects;

using System.Collections.Generic;
using System.Linq;

namespace SchuBS_Textadventure.KampfHelper
{
    internal static class AusgabeHelper
    {
        public static List<string> AusgabeReaktion(Reaktion reaktion, KampfAktionsTyp typ, GegnerBase gegner)
        {
            List<string> ausgabe;
            switch (typ)
            {
                case KampfAktionsTyp.SpielerAngriff:
                case KampfAktionsTyp.SpielerMagie:
                    ausgabe = AusgabeSpielerAktion(reaktion);
                    break;
                case KampfAktionsTyp.GegnerAngriff:
                    ausgabe = AusgabeGegnerAktion(reaktion, gegner);
                    break;
                case KampfAktionsTyp.SpielerItem:
                    ausgabe = AusgabeSpielerItem(reaktion, gegner);
                    break;
                default:
                    ausgabe = new List<string>();
                    break;
            }

            return ausgabe;
        }

        private static List<string> AusgabeSpielerItem(Reaktion reaktion, GegnerBase gegner)
        {
            List<string> ausgabe = GetReaktionTexte(reaktion, gegner);

            if (reaktion.Schaden != 0)
                ausgabe.Add($"{gegner.Name} hat {reaktion.Schaden} Schaden erhalten.");

            if (gegner.Lebenspunkte <= 0)
            {
                ausgabe.Add($"{gegner.Name} wurde besiegt!");
            }

            return ausgabe;
        }

        private static List<string> GetReaktionTexte(Reaktion reaktion, BaseObject sprecher = null)
        {
            if (reaktion.Texte != null)
            {
                return GetTextFuerSprecher(sprecher?.Name, reaktion.Texte);
            }
            else
            {
                return new List<string>();
            }
        }

        public static List<string> GetTextFuerSprecher(string sprecher, params string[] texte)
        {
            List<string> ausgabe = new List<string>();
            ausgabe.Add($"{sprecher}:");
            ausgabe.AddRange(texte.Select(zeile => "\t" + zeile));
            return ausgabe;
        }

        private static List<string> AusgabeSpielerAktion(Reaktion reaktion)
        {
            List<string> ausgabe = new List<string>();
            if (reaktion.Texte == null)
            {
                ausgabe.Add($"{reaktion.Ziel.Name} hat {reaktion.Schaden} Schaden erhalten.");
            }
            else
            {
                ausgabe.Add($"{reaktion.Ziel.Name} hat {reaktion.Schaden} Schaden erhalten.");
                ausgabe.AddRange(GetReaktionTexte(reaktion));
            }

            if (reaktion.Ziel.Lebenspunkte <= 0)
            {
                ausgabe.Add($"{reaktion.Ziel.Name} wurde besiegt!");
            }

            return ausgabe;
        }

        private static List<string> AusgabeGegnerAktion(Reaktion reaktion, GegnerBase gegner)
        {
            List<string> ausgabe = new List<string>
            {
                $"{gegner.Name} greift dich an...",
                $"Du hast {reaktion.Schaden} Schaden erhalten.\r\n"
            };

            if (reaktion.Ziel != null && reaktion.Ziel.Lebenspunkte <= 0)
            {
                ausgabe.Add("Du wurdest besiegt!");
            }

            return ausgabe;
        }
    }
}

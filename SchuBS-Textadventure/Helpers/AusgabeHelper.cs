﻿using SchuBS_IT_2020;
using SchuBS_Textadventure.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuBS_Textadventure.Helpers
{
    public static class AusgabeHelper
    {
        public static void AusgabeReaktion(Textadventure adventure, Reaktion reaktion, Kampf.AktionsTyp typ, Gegner gegner)
        {
            switch (typ)
            {
                case Kampf.AktionsTyp.SpielerAngriff:
                case Kampf.AktionsTyp.SpielerMagie:
                    AusgabeSpielerAktion(adventure, reaktion);
                    break;
                case Kampf.AktionsTyp.GegnerAngriff:
                    AusgabeGegnerAktion(adventure, reaktion, gegner);
                    break;
            }
        }

        public static void AusgabeSpielerAktion(Textadventure adventure, Reaktion reaktion)
        {
            if (reaktion.text == null)
                adventure.WriteText($"{reaktion.von.Name} hat {reaktion.schaden} Schaden erhalten.\r\n");
            else
                adventure.WriteText($"{reaktion.von.Name} hat {reaktion.schaden} Schaden erhalten.\r\n{reaktion.von.Name}: {reaktion.text}\r\n");

            if (reaktion.von.Lebenspunkte <= 0)
                adventure.WriteText($"{reaktion.von.Name} wurde besiegt!");
        }

        public static void AusgabeGegnerAktion(Textadventure adventure, Reaktion reaktion, Gegner gegner)
        {
            adventure.WriteText($"{gegner.Name} greift dich an..."+"\r\n"+ $"Du hast {reaktion.schaden} Schaden erhalten.\r\n");

            if (reaktion.von.Lebenspunkte <= 0)
            {
                adventure.WriteText("Du wurdest besiegt!");
            }
        }
    }
}

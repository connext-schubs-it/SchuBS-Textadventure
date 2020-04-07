using SchuBS_IT_2020;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuBS_Textadventure.Helpers
{
    public static class AusgabeHelper
    {
        public static void AusgabeSpielerAktion(Textadventure adventure, Reaktion reaktion, bool isOver)
        {
            adventure.WriteText($"{reaktion.name} hat {reaktion.schaden} Schaden erhalten.\r\n");

            if (isOver)
                adventure.WriteText($"{reaktion.name} wurde besiegt!");

        }

        public static void AusgabeGegnerAktion(Textadventure adventure, Reaktion reaktion, bool isOver, Gegner gegner)
        {
            adventure.WriteText($"{gegner.Name} greift dich an..."+"\r\n"+ $"Du hast {reaktion.schaden} Schaden erhalten.\r\n");

            if (isOver)
            {
                adventure.WriteText("Du wurdest besiegt!");
            }
        }
    }
}

using SchuBS_Textadventure.Objects;

namespace SchuBS_Textadventure.KampfHelper
{
    /// <summary>
    /// Stellt eine Reaktion auf ein Ereignis im Kampf da.
    /// </summary>
    public class Reaktion
    {
        /// <summary>
        /// Erzeugt eine <see cref="Reaktion"/> mit Text.
        /// </summary>
        /// <param name="texte"></param>
        public Reaktion(params string[] texte)
        {
            Texte = texte;
        }

        /// <summary>
        /// Erzeugt eine <see cref="Reaktion"/>, die ausgefürt werden soll, wenn die LP unter die angegebenen <paramref name="lp"/> fallen.
        /// </summary>
        /// <param name="lp"></param>
        /// <param name="texte"></param>
        public Reaktion(int lp, params string[] texte) : this (texte)
        {
            LP = lp;
        }

        /// <summary>
        /// Erzeugt eine <see cref="Reaktion"/>, die ausgeführt werden soll, wenn ein bestimmtes <see cref="Item"/> verwendet wurde.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="schaden">Der Schaden, der durch die Verwendung des <see cref="Item"/>s ausgeteilt werden soll.</param>
        /// <param name="texte"></param>
        public Reaktion(string itemName, int schaden, params string[] texte) : this (texte)
        {
            ItemName = itemName;
            Schaden = schaden;
        }

        /// <summary>
        /// Das Objekt, dass diese <see cref="Reaktion"/> besitzt.
        /// </summary>
        public BaseObject Ziel { get; set; }

        /// <summary>
        /// Die Lebenspunkte, bei der die <see cref="Reaktion"/> ausgeführt werden soll.
        /// </summary>
        public int LP { get; set; }

        /// <summary>
        /// Der Text, der beim auslösen dieser <see cref="Reaktion"/> gesagt werden soll.
        /// </summary>
        public string[] Texte { get; set; }

        /// <summary>
        /// Der Name des Verwendeten Items.
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Der zugefügt schaden.
        /// </summary>
        public int Schaden { get; set; }

        /// <summary>
        /// Erstellt eine Kopie des Objektes.
        /// </summary>
        /// <returns>Eine Kopie.</returns>
        public Reaktion Clone()
        {
            return new Reaktion
            {
                Ziel = Ziel,
                LP = LP,
                Texte = Texte,
                Schaden = Schaden,
            };
        }
    }
}

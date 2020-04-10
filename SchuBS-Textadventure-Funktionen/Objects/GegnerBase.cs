using SchuBS_Textadventure.KampfHelper;

using System.Collections.Generic;

namespace SchuBS_Textadventure.Objects
{
    public abstract class GegnerBase : BaseObject
    {
        public GegnerBase(int maxLebenspunkte, string name) : base(maxLebenspunkte, name) { }

        /// <summary>
        /// Die Reaktionen auf bestimmte Items.
        /// </summary>
        public List<Reaktion> ItemReaktionen { get; set; } = new List<Reaktion>();

        /// <summary>
        /// Gibt die Reaktion auf das <paramref name="item"/> zurück.
        /// </summary>
        /// <param name="item">Das verwendete <see cref="Item"/>.</param>
        /// <returns></returns>
        public Reaktion GetReaktionAufItem(Item item)
        {
            return ItemReaktionen.Find(reaktion => reaktion.ItemName == item.Name);
        }
    }
}

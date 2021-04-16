using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchuBS_Textadventure.Objects
{
    /// <summary>
    /// Die Basisklasse des Spielers. Stellt funktionalitäten für ein Inventar bereit.
    /// </summary>
    public abstract class SpielerBase : BaseObject
    {
        /// <summary>
        /// Standard-Konstruktor
        /// </summary>
        public SpielerBase() : base(0, "") { }

        /// <summary>
        /// Das Inventar des Spielers
        /// </summary>
        public IList<Item> Inventar { get; } = new ObservableCollection<Item>();

        /// <summary>
        /// Überprüft, ob der Spieler ein <see cref="Item"/> mit diesem Name hat.
        /// </summary>
        /// <param name="name">Der Name des <see cref="Item"/>s, der geprüft werden soll.</param>
        /// <returns><see langword="true"/>, wenn er das <see cref="Item"/> mit dem <paramref name="name"/>n hat, ansonsten <see langword="false"/></returns>
        public bool HatItem(string name) => Inventar.Contains(new Item(name));

        /// <summary>
        /// Gibt ein <see cref="Item"/> mit dem <paramref name="name"/>n zurück.<br/>
        /// Hat der Spieler das <see cref="Item"/> nicht, wird <see langword="null"/> zurück gegeben.
        /// </summary>
        /// <param name="name">der Name des <see cref="Item"/>s.</param>
        /// <returns></returns>
        public Item HoleItem(string name) => Inventar.FirstOrDefault(item => item.Name == name);

        /// <summary>
        /// Entfernt das <see cref="Item"/> mit den <paramref name="name"/>n aus dem Inventar des Spielers, wenn er dieses hat.
        /// </summary>
        /// <param name="name">Der Name des <see cref="Item"/>s.</param>
        /// <returns></returns>
        public bool EntferneItem(string name) => Inventar.Remove(new Item(name));

        /// <summary>
        /// Fügt das <see cref="Item"/> zu Inventar des Spielers hinzu.
        /// <code>FuegeItemHinzu(new Item("Itemname", "bild"));</code>
        /// </summary>
        /// <param name="item"></param>
        public void FuegeItemHinzu(Item item) => Inventar.Add(item);
    }
}

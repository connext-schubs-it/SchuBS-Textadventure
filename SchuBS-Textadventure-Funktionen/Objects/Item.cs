using System;
using System.Windows.Media.Imaging;

namespace SchuBS_Textadventure.Objects
{
    /// <summary>
    /// Ein Item, dass der Spieler im Inventar haben kann um es an verschiedenen Stellen zu benutzen.
    /// </summary>
    public class Item : IEquatable<Item>
    {
        /// <summary>
        /// Erstell ein neues <see cref="Item"/> mit name und bild.
        /// </summary>
        /// <param name="name">Der Name des Items.</param>
        /// <param name="bildName">Der Name des Bildes, dass das Item haben soll.</param>
        public Item(string name, string bildName = null)
        {
            Name = name;
            Bild = TextadventureHelper.GetBild(bildName);
        }

        /// <summary>
        /// Der Name des Items. Dieser sollte eindeutig sein.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Das Bild des Items. Dieses wird im Inventar angezeigt.
        /// </summary>
        public BitmapImage Bild { get; set; }

        /// <summary>
        /// Überprüft, ob die Namen des <see cref="Item"/>s übereinstimmen.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Item other) => other.Name == Name;

        /// <summary>
        /// Gibt den Namen des <see cref="Item"/>s zurück.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name;
    }
}

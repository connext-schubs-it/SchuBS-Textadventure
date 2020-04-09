using System;
using System.Windows.Media.Imaging;

namespace SchuBS_Textadventure.Objects
{
    public class Item : IEquatable<Item>
    {
        public Item(string name, BitmapImage bild = null)
        {
            Name = name;
            Bild = bild;
        }

        public string Name { get; set; }

        public BitmapImage Bild { get; set; }

        public bool Equals(Item other) => other.Name == Name;

        public override string ToString() => Name;
    }
}

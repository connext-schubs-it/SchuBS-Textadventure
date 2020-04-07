using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SchuBS_Textadventure.Objects
{
    public class Item
    {
        public Item(string name, BitmapImage bild)
        {
            Name = name;
            Bild = bild;
        }

        public string Name { get; set; }

        public BitmapImage Bild { get; set; }

        public override string ToString() => Name;
    }
}

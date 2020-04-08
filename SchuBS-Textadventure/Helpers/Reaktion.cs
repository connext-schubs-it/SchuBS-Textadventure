using SchuBS_Textadventure.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuBS_Textadventure.Helpers
{
    public class Reaktion
    {
        public BaseObject von { get; set; }
        public int LP { get; set; }
        public string text { get; set; }
        public bool showImage { get; set; }
        public string specialText { get; set; }
        public int schaden { get; set; }
        public bool isDead { get; set; }

        public Reaktion Copy()
        {
            Reaktion reaktion = new Reaktion();

            reaktion.von = this.von;
            reaktion.LP = this.LP;
            reaktion.text = this.text;
            reaktion.showImage = this.showImage;
            reaktion.specialText = this.specialText;
            reaktion.schaden = this.schaden;
            reaktion.isDead = this.isDead;

            return reaktion;
        }
    }
}

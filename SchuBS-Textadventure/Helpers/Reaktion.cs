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
        public BaseObject Von { get; set; }
        public int LP { get; set; }
        public string Text { get; set; }
        public bool ShowImage { get; set; }
        public string SpecialText { get; set; }
        public int Schaden { get; set; }
        public bool IsDead { get; set; }

        public Reaktion Copy()
        {
            return new Reaktion
            {
                Von = Von,
                LP = LP,
                Text = Text,
                ShowImage = ShowImage,
                SpecialText = SpecialText,
                Schaden = Schaden,
                IsDead = IsDead
            };
        }
    }
}

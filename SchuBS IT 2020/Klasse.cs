using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuBS_IT_2020
{
    public class Klasse
    {
        int _staerke;
        int _verteidigung;
        int _geschicklichkeit;
        int _magie;
        int _mana;

        public Klasse(int staerke, int verteidigung, int geschicklichkeit, int magie, int mana)
        {
            Staerke = staerke;
            Verteidigung = verteidigung;
            Geschicklichkeit = geschicklichkeit;
            Magie = magie;
            Mana = mana;
        }

        public int Staerke { get => _staerke; set => _staerke = value; }
        public int Verteidigung { get => _verteidigung; set => _verteidigung = value; }
        public int Geschicklichkeit { get => _geschicklichkeit; set => _geschicklichkeit = value; }
        public int Magie { get => _magie; set => _magie = value; }
        public int Mana { get => _mana; set => _mana = value; }
    }    
}

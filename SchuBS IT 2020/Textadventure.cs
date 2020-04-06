using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchuBS_IT_2020
{
    public partial class Textadventure : Form
    {
        #region Variablen

        public static Random Zufallsgenerator = new Random();

        public static float TextSpeed = 1f;
        public const int backButtonIndex = -1;

        public static string[] DefaultButtonText = new string[]
        {
            "Button 1",
            "Button 2",
            "Button 3",
        };

        #endregion

        public Textadventure()
        {
            InitializeComponent();
            WriteText("Seid gegrüßt, Held!",
                        "Willkommen in der Welt von * Weltname * !",
                        "*Beispieltext *: In dieser Welt durchlauft Ihr ein einzigartiges Abenteuer voller Mythen und Geheimnisse, Menschen und Monstern, Zauber und Flüche.",
                        "Die Länder dieser Welt verbergen viele Schätze, doch gebt Acht! Auf euren Wegen erwarten euch viele Gefahren und Herausforderungen...");
        }

        #region Funktionen

        public void SetButtonsText(params string[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                SetButtonText(i + 1, text[i]);
            }
        }

        public void SetButtonText(int buttonNumber, string text)
        {
            GetButtonFromNumber(buttonNumber).Text = text ?? DefaultButtonText[buttonNumber];
        }

        public Button GetButtonFromNumber(int number)
        {
            switch (number)
            {
                case backButtonIndex: return buttonZurueck;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                default: throw new IndexOutOfRangeException();
            }
        }

        public void WriteText(params string[] lines)
        {
            richTextBoxHauptText.Text += string.Join(Environment.NewLine, lines);
        }

        #endregion
    }
}

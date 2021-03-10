using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SchuBS_Textadventure.MyControls
{
    /// <summary>
    /// Eine Textbox, die den Text langsam Zeichen für Zeichen aufbaut.
    /// </summary>
    public class SlowTextBox : TextBox
    {
        private const int CharInterval = 10;
        private readonly DispatcherTimer Timer = new();

        private IEnumerator<char> textEnumerator = null;
        private float textSpeed = 1f;

        /// <summary>
        /// Gibt an, ob die Textbox gerade noch schreibt.
        /// </summary>
        public bool IsWriting => Timer.IsEnabled;

        /// <summary>
        /// Die geschwindigkeit, mit der die <see cref="SlowTextBox"/> schreibt.<br/>
        /// Der standard Wert ist 1.
        /// </summary>
        public float TextSpeed
        {
            get => textSpeed;
            set
            {
                textSpeed = value;
                Timer.Interval = TimeSpan.FromMilliseconds((int)(CharInterval / textSpeed));
            }
        }

        /// <summary>
        /// Der Standard-Konstuktor der <see cref="SlowTextBox"/>.
        /// </summary>
        public SlowTextBox()
        {
            Timer.Interval  = TimeSpan.FromMilliseconds(CharInterval);
            Timer.IsEnabled = false;
            Timer.Tick     += (s, e) =>
            {
                if (textEnumerator?.MoveNext() ?? false)
                {
                    base.AppendText(textEnumerator.Current.ToString());
                    ScrollToEnd();
                }
                else
                {
                    Timer.IsEnabled = false;
                }
            };
        }

        /// <summary>
        /// Setzt den angezeigten Text. Der vorherige Text wird entfernt.
        /// </summary>
        /// <param name="text"></param>
        public void SetText(string text)
        {
            Clear();
            AppendText(text);
        }

        /// <summary>
        /// Zusätzlich den <see cref="textEnumerator"/> zurücksetzen.
        /// </summary>
        public new void Clear()
        {
            textEnumerator = null;
            base.Clear();
        }

        /// <summary>
        /// Fügt den <paramref name="text"/> an. Der vorherige Text bleibt bestehen und wird, fals nötig, sofort zuende geschrieben.
        /// </summary>
        /// <param name="text"></param>
        public new void AppendText(string text)
        {
            if (textEnumerator != null)
            {
                Timer.IsEnabled = false;
                while (textEnumerator.MoveNext())
                {
                    base.AppendText(textEnumerator.Current.ToString());
                }
            }
            textEnumerator = text.GetEnumerator();
            Timer.IsEnabled = true;
        }
    }
}

using System.Collections.Generic;
using System.Windows.Forms;

namespace SchuBS_IT_2020.MyControls
{
    public class SlowRichTextBox : RichTextBox
    {
        private const int CharInterval = 45;
        private readonly Timer Timer = new Timer();

        private IEnumerator<char> text = null;
        private static float textSpeed = 1f;

        public bool IsWriting => Timer.Enabled;

        public float TextSpeed
        {
            get => textSpeed;
            set
            {
                textSpeed = value;
                Timer.Interval = (int)(CharInterval / textSpeed);
            }
        }

        public SlowRichTextBox()
        {
            Timer.Interval = CharInterval;
            Timer.Enabled = false;
            Timer.Tick += (s, e) =>
            {
                if (text?.MoveNext() ?? false)
                {
                    base.Text += text.Current;
                }
                else
                {
                    Timer.Enabled = false;
                }
            };
        }

        public new void AppendText(string text)
        {
            this.text = text.GetEnumerator();
            Timer.Enabled = true;
        }
    }
}

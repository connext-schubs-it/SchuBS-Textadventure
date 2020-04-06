using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchuBS_IT_2020.MyControls
{
    class SlowRichTextBox : RichTextBox
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        IEnumerator<char> text = null;

        public SlowRichTextBox()
        {
            timer.Interval = 45;
            timer.Enabled = false; 
            timer.Tick += (s, e) => {
                base.Text += text.Current;
                timer.Interval = 45;
                timer.Enabled = text.MoveNext();
            };
        }

        public override string Text
        {
            set
            {
                text = value.GetEnumerator();
                timer.Enabled = text.MoveNext();
            }
        }
    }
}

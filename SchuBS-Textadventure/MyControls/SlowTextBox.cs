﻿using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SchuBS_Textadventure.MyControls
{
    public class SlowTextBox : TextBox
    {
        private const int CharInterval = 15;
        private readonly DispatcherTimer Timer = new DispatcherTimer();

        private IEnumerator<char> text = null;
        private float textSpeed = 1f;

        public bool IsWriting => Timer.IsEnabled;

        public float TextSpeed
        {
            get => textSpeed;
            set
            {
                textSpeed = value;
                Timer.Interval = TimeSpan.FromMilliseconds((int)(CharInterval / textSpeed));
            }
        }

        public SlowTextBox()
        {
            Timer.Interval = TimeSpan.FromMilliseconds(CharInterval);
            Timer.IsEnabled = false;
            Timer.Tick += (s, e) =>
            {
                if (text?.MoveNext() ?? false)
                {
                    Text += text.Current;
                    ScrollToEnd();
                }
                else
                {
                    Timer.IsEnabled = false;
                }
            };
        }

        public void SetText(string text)
        {
            Text = string.Empty;
            this.text = null;
            AppendText(text);
        }

        public new void AppendText(string text)
        {
            if (this.text != null)
            {
                Timer.IsEnabled = false;
                while (this.text.MoveNext())
                {
                    Text += this.text.Current;
                }
            }
            this.text = text.GetEnumerator();
            Timer.IsEnabled = true;
        }
    }
}

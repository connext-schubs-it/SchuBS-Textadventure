using System;

namespace SchuBS_Textadventure.Objects
{
    public sealed class AdventureAction
    {
        public string Text { get; }
        public Func<bool> ContinueWith { get; }

        public AdventureAction(string text, Func<bool> continueWith)
        {
            Text         = text;
            ContinueWith = continueWith;
        }

        public static implicit operator AdventureAction((string Text, Action ContinueWith) value) =>
            new(value.Text, () =>
            {
                value.ContinueWith();
                return true;
            });

        public static implicit operator AdventureAction((string Text, Func<bool> ContinueWith) value) =>
            new(value.Text, value.ContinueWith);
    }
}

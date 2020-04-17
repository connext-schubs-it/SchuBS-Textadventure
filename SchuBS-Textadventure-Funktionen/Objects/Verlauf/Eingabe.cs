namespace SchuBS_Textadventure.Objects.Verlauf
{
    /// <summary>
    /// Eine Eingabe des Spielers.
    /// </summary>
    public class Eingabe
    {
        public Eingabe(string text)
        {
            Text = text;
        }

        internal readonly string Text;

        public override string ToString() => Text;
    }
}

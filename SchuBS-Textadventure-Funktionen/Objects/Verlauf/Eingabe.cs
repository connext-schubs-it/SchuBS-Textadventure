namespace SchuBS_Textadventure.Objects.Verlauf
{
    /// <summary>
    /// Eine Eingabe des Spielers.
    /// </summary>
    public class Eingabe
    {
        /// <summary>
        /// Standard-Konstruktor
        /// </summary>
        /// <param name="text"></param>
        public Eingabe(string text)
        {
            Text = text;
        }

        internal readonly string Text;

        /// <inheritdoc/>
        public override string ToString() => Text;
    }
}

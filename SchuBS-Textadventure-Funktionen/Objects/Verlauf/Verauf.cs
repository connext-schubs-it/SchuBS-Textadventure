using System.Collections.ObjectModel;

namespace SchuBS_Textadventure.Objects.Verlauf
{
    /// <summary>
    /// Speichert den Verlauf des Spiels.
    /// </summary>
    public class Verauf
    {
        /// <summary>
        /// Speichert die Verlaufsobjekte.
        /// </summary>
        internal ObservableCollection<object> VerlaufItems { get; } = new();

        /// <summary>
        /// Fügt einen Block zum Verlauf hinzu. <br/>
        /// Für mögliche Typen siehe <see cref="Verlauf"/>.
        /// Für alle anderen Typen wird <see cref="object.ToString"/> verwendet.
        /// </summary>
        /// <param name="zeile"></param>
        public void AppendBlock(object zeile = null) => VerlaufItems.Add(zeile);
    }
}

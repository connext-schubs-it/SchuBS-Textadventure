namespace SchuBS_Textadventure.Objects
{
    /// <summary>
    /// Enthält grundlegene Eigenschaften einer Klasse.
    /// </summary>
    public interface IKlasse
    {
        /// <summary>
        /// Wie gut kann der Held mit verschieden Objekten umgehen oder wie gut kann er ausweichen?
        /// </summary>
        int Geschicklichkeit { get; set; }

        /// <summary>
        /// Wie viele Leben hat der Held aktuell?
        /// </summary>
        int Lebenspunkte { get; set; }

        /// <summary>
        /// Wie gut ist der Held mit den magischen Künsten vertraut?
        /// </summary>
        int Magie { get; set; }

        /// <summary>
        /// Wie viel Mana hat der Held aktuell, um seine Zauber zu wirken?
        /// </summary>
        int Mana { get; set; }

        /// <summary>
        /// Wie stark ist der Held körperlich?
        /// </summary>
        int Staerke { get; set; }

        /// <summary>
        /// Wie gut ist die Verteidigung / Rüstung des Helden?
        /// </summary>
        int Verteidigung { get; set; }
    }
}
namespace SchuBS_Textadventure.KampfHelper
{
    /// <summary>
    /// Aktionstypen einer Aktion im Kampf
    /// </summary>
    public enum KampfAktionsTyp
    {
        /// <summary>
        /// Der Spieler greift normal an.
        /// </summary>
        SpielerAngriff,
        /// <summary>
        /// Der Spieler benutzt Magie.
        /// </summary>
        SpielerMagie,
        /// <summary>
        /// Der Spieler benutzt ein Item.
        /// </summary>
        SpielerItem,
        /// <summary>
        /// Der Gegener Greift an.
        /// </summary>
        GegnerAngriff,
        /// <summary>
        /// Der Gegner führ eine Spezialaktion aus.
        /// </summary>
        GegnerSpezial
    }
}

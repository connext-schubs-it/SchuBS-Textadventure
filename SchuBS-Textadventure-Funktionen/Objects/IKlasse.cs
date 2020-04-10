namespace SchuBS_Textadventure.Objects
{
    /// <summary>
    /// Enthält grundlegene Eigenschaften eine Klasse.
    /// </summary>
    public interface IKlasse
    {
        int Geschicklichkeit { get; set; }
        int Lebenspunkte { get; set; }
        int Magie { get; set; }
        int Mana { get; set; }
        int Staerke { get; set; }
        int Verteidigung { get; set; }
    }
}
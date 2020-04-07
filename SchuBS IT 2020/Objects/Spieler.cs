namespace SchuBS_IT_2020
{
    public class Spieler
    {
        public string Name { get; set; }
        public Klasse Klasse { get; set; } = Klasse.GetByKlassenTyp(KlassenTyp.Keine);
    }
}

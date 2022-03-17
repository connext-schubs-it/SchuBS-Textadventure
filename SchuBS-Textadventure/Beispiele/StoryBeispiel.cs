using SchuBS_Textadventure.Objects;
using System.Windows;

using static SchuBS_Textadventure.TextadventureHelper;

namespace SchuBS_Textadventure
{
    public partial class Textadventure : Window
    {
        public void StartBeispiel()
        {
            SetzeHintergrundBild("landschaft_1.jpg");
            SetzePersonenBild();
            WriteText("Seid gegrüßt, Held!",
                "Willkommen in der Welt von ##Weltname##!",
                "In dieser Welt durchläufst du ein einzigartiges Abenteuer voller Mythen und Geheimnisse, Menschen und Monster, Zauber und Flüche. Und ganz viele Kürbisse. ",
                "Die Länder von Cucurbita beherbergen viele Schätze, doch gib Acht! Auf deinen Wegen erwarten dich viele Gefahren und Herausforderungen. Entscheide weise, denn jede Entscheidung könnte deine letzte sein...  ",
                "Du erwachst.",
                "Du spürst, dass du auf hartem Boden liegst.",
                "Du fühlst keinen Schmerz, alles scheint wie immer. Trotzdem kannst du dich an nichts mehr erinnern…");

            SetActions((Text: "Augen öffnen", ContinueWith: NameErfragen), (Text: "Augen geschlossen lassen", ContinueWith: EndeAugenGeschlossen));
        }

        private void NameErfragen()
        {
            WriteText(
                "Du öffnest deine Augen. Das helle Sonnenlicht blendet dich für einen Moment. Es scheint ein sonniger Vormittag im frühen Sommer zu sein. Du liegst auf einem staubigen Feldweg. In der Umgebung gibt es nicht viel zu sehen. Grüne Flächen, vereinzelte Felder und der Feldweg, der bis an den Horizont zu führen scheint.",
                "Da regt sich etwas in der Ferne. Eine Gestalt befindet sich auf dem Weg und bewegt sich in eure Richtung, zuerst langsam, dann schneller, als sie dich bemerkt.",
                "Nun steht ein fremder Mann vor dir.",
                "“Ein Mittagsschlaf, hier in der prallen Sonne? Recht ungewöhnlich für diese Gegend. Fast schon verdächtig... ",
                "Verrätst du mir deinen Namen?”");
            EingabefeldNutzen(NameEingabe);
        }

        private bool NameEingabe()
        {
            AktuellerHeld.Name = EingabeText;
            BerufungErfragen();

            return true;
        }

        private void EndeAugenGeschlossen()
        {
            SetzeHintergrundBild("feldweg_deathscreen.png");
            WriteText("So schnell wie dein Abenteuer anfing, so schnell ist es auch zu Ende. " +
                "Du hast dich entschieden, deinem Schicksal zu entkommen. Dein ungestillter Durst nach Abenteuern führt zum unweigerlichen Ende.");
            SpielZuende();
        }

        private void BerufungErfragen()
        {
            WriteText(
                "“Naja, jemand mit deinem Namen kann gar nicht feindlich gesinnt sein! Freut mich dich kennenzulernen, ##SpielerName##!",
                "Ich bin Thoron, der Wanderer, erster seines Namens, Sprenger der Ketten und Vater der Kürbisse. Aber du darfst mich ruhig Thoron nennen.",
                "Was führt dich in unsere Lande, ##SpielerName##?”");
            SetActions(("Ich bin beruflich hier.", BerufErfragen), ("Pure Abenteuerlust.", ZielErfragen));
        }

        private void BerufErfragen()
        {
            SetzeHintergrundBild("klassenvorschau.png");
            WriteText("“Beruflich also? Was ist denn dein Beruf?”",
                "(Mögliche Eingaben: Krieger, Waldläufer, Magier, Assassine. Entscheide weise!) ");
            EingabefeldNutzen(BerufEingabe);
        }

        private bool BerufEingabe()
        {
            switch (EingabeText.ToLower())
            {
                case "krieger":
                    AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Krieger);
                    break;
                case "kriegerin":
                    AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Krieger);
                    break;
                case "waldläuferin":
                    AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Waldlaeufer);
                    break;
                case "waldläufer":
                    AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Waldlaeufer);
                    break;
                case "magierin":
                    AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Magier);
                    break;
                case "magier":
                    AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Magier);
                    break;
                case "assassine":
                    AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Assassine);
                    break;
                default:
                    WriteText("Diesen Beruf kenne ich nicht. Kannst du ihn nochmal wiederholen?", "");
                    return false;
            }

            ZielErfragen();

            return true;
        }

        private void ZielErfragen()
        {
            WrapPanelStats.Visibility = Visibility.Visible;
            WriteText("“Ein ##SpielerKlasse##! Spannend.",
                "Dann wünsche ich dir viel Erfolg auf deinem Weg.",
                "Hier hast du eine Münze. Gebrauche sie klug. Sie wird sich bestimmt noch als hilfreich erweisen.",
                "Eine Frage noch, ##SpielerName##. Welches Begehren wird dich auf deinem Weg leiten?”");
            AktuellerHeld.FuegeItemHinzu(new Item("Münze", "muenze.png"));
            SetActions(("Macht.", MachtStart), ("Reichtum.", EisKaufen));
        }
    }
}

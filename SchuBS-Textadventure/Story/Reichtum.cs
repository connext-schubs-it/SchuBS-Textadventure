using System.Linq;
using SchuBS_IT_2020;
using SchuBS_Textadventure.Objects;

namespace SchuBS_Textadventure
{
    public partial class Textadventure
    {
        private void EisKaufen()
        {
            SetzeHintergrundBild("berg_mit_eiswagen.png");
            WriteText("Reichtum! Ein ##SpielerKlasse## ganz nach meinem Geschmack! Es gibt Gerüchte, dass sich auf dem Berg da drüben ein riesiger Schatz befindet, behütet von einer wilden Bestie.",
                "Wenn ich du wäre, würde ich dem ganzen mal nachgehen. Aber wenn jemand fragt, den Tipp hast du nicht von mir. Der Weg führt durch den Steinbogen da vorne. Ich bin dann mal weg. Tschüssi!",
                "Thoron verschwindet im nächsten Gebüsch und wird nie wieder gesehen", "", 
                "Du gehst zielsicher durch den Steinbogen. Der erste Schritt Richtung Reichtum ist getan.",
                " Einige Minuten später siehst du am Wegesrand einen bunten Verkaufsstand. Die exzentrische, pinkhaarige Verkäuferin preist lautstark Eis an.",
                "'Das beste Eis in Kürbistan! Kürbiseis! Nur heute für den kleinen, kleinen Preis von einer Münze! Wenn Sie jetzt anhalten und sofort bestellen, gibt es einen Messerblock kostenlos dazu!'",
                "Du bist die einzige Person auf der Straße und fühlst dich angesprochen.",
                "Möchtest du ein Eis kaufen, oder ignorierst du diese süße Versuchung?");
            SetButtonsText("Ich nehme ein Kürbiseis!", "Weitergehen, Keinen Augenkontakt aufnehmen!");
            previous = Previous.EisKaufen;
        }

        private void Taube(bool eisGekauft)
        {
            SetzeHintergrundBild("taube_mit_nunchakus.png");
            if (eisGekauft)
            {
                WriteText("Das Kürbiseis ist gar nicht mal so gut. Was für eine Abzocke! Aber der Messerblock könnte noch von Nutzen sein. Ist ganz schön schwer, das Ding.",
                    "Du gehst weiter die Straße entlang.",
                    "Von weitem kannst du schon den Berg erspähen. Auf einmal springt dir eine dicke, türkise Taube in den Weg. Im Schnabel trägt sie ein paar Nunchucks, die sie drohend in deine Richtung schwenkt. Ihr tiefes Gurren geht durch Mark und Bein.");
               
                var muenze = AktuellerHeld.Inventar.FirstOrDefault(x => x.Name == "Münze");
                AktuellerHeld.Inventar.Remove(muenze);
                AktuellerHeld.Inventar.Add(new Item("Messerblock", GetBild("messerblock.png")));
            }
            else
            {
                WriteText("obwohl so ein Eis echt lecker wäre...",
                    "Du gehst weiter die Straße entlang.",
                    "Von weitem kannst du schon den Berg erspähen. Auf einmal springt dir eine dicke, türkise Taube in den Weg. Im Schnabel trägt sie ein paar Nunchucks, die sie drohend in deine Richtung schwenkt.Ihr tiefes Gurren geht durch Mark und Bein.");
            }
            SetButtonsText("Im Gebüsch Deckung suchen", "Die Taube mit einem beherzten Karatekick in die nächste Böschung befördern.");
            previous = Previous.Taube;
        }

        private void DeckungSuchen()
        {
            WriteText("Mit einem Hechtsprung rettest du dich ins Gebüsch und kriechst weiter. Die Taube scheint nicht hinterherzukommen.");
            SetButtonsText("weiter");
            previous = Previous.DeckungSuchen;
        }

        private void TaubeTreten()
        {
            WriteText("Die Taube fliegt wie ein Fußball durch die Luft und landet mit traurigem Gurren im Wald. Das sollte sich erstmal erledigt haben! Die Nunchucks nimmst du an dich",
                "Die Nunchucks nimmst du an dich.");
            AktuellerHeld.Inventar.Add(new Item("Nunchucks", GetBild("nunchakus.png")));
            SetButtonsText("weiter");
            previous = Previous.TaubeTreten;
        }

        private void BrueckenZoll()
        {
            bool muenze = AktuellerHeld.Inventar.FirstOrDefault(x => x.Name == "Münze") != null;
            if (muenze)
            {
                WriteText("Du gehst weiter auf dem Weg.",
                    "Vor dir liegt eine Brücke. In einem kleinen Häuschen sitzt ein Zollbeamter.",
                    "Das Passieren dieser  kürbistanischen Staatsbrücke ist kostenpflichtig. Das wären für sie ... mal sehen ... Brückenpauschale plus Bearbeitungsgebühr minus Feiertagsrabatt plus Mittagszuschlag ... 3 im Sinn ... eine Münze.",
                    "");
            }
            else
            {
                WriteText("Du gehst weiter auf dem Weg.",
                    "Vor dir liegt eine Brücke. In einem kleinen Häuschen sitzt ein Zollbeamter.",
                    "Das Passieren dieser kürbistanischen Staatsbrücke ist kostenpflichtig. Das wären für sie ... mal sehen ... Brückenpauschale plus Bearbeitungsgebühr minus Feiertagsrabatt plus Mittagszuschlag ... 3 im Sinn ... eine Münze.",
                    "");
            }
        }
    }
}
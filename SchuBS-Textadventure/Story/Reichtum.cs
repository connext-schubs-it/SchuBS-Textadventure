using SchuBS_Textadventure.Objects;

namespace SchuBS_Textadventure
{
    public partial class Textadventure
    {
        private void EisKaufen()
        {
            SetzeHintergrundBild("berg_mit_eiswagen.png");
            WriteText("“Reichtum! Ein ##SpielerKlasse## ganz nach meinem Geschmack! Es gibt Gerüchte, dass sich auf dem Berg da drüben ein riesiger Schatz befindet, behütet von einer wilden Bestie.",
                "Wenn ich du wäre, würde ich dem ganzen mal nachgehen. Aber wenn jemand fragt, den Tipp hast du nicht von mir. Der Weg führt durch den Steinbogen da vorne. Ich bin dann mal weg. Tschüssi!”",
                "Thoron verschwindet im nächsten Gebüsch und wird nie wieder gesehen", "",
                "Du gehst zielsicher durch den Steinbogen. Der erste Schritt Richtung Reichtum ist getan.",
                " Einige Minuten später siehst du am Wegesrand einen bunten Verkaufsstand. Die exzentrische, pinkhaarige Verkäuferin preist lautstark Eis an.",
                "“Das beste Eis in Kürbistan! Kürbiseis! Nur heute für den kleinen, kleinen Preis von einer Münze! Wenn Sie jetzt anhalten und sofort bestellen, gibt es einen Messerblock kostenlos dazu!”",
                "Du bist die einzige Person auf der Straße und fühlst dich angesprochen.",
                "Möchtest du ein Eis kaufen, oder ignorierst du diese süße Versuchung?");
            SetButtonsText("“Ich nehme ein Kürbiseis!”", "Weitergehen, Keinen Augenkontakt aufnehmen!");
            previous = Previous.EisKaufen;
        }

        private void EisGekauft()
        {
            WriteText("Das Kürbiseis ist gar nicht mal so gut. Was für eine Abzocke! Aber der Messerblock könnte noch von Nutzen sein. Ist ganz schön schwer, das Ding.");

            AktuellerHeld.EntferneItem("Münze");
            AktuellerHeld.FuegeItemHinzu(new Item("Messerblock", GetBild("messerblock.png")));
            SetButtonsText("weiter");
            previous = Previous.EisGekauft;
        }

        private void EisNichtGekauft()
        {
            WriteText("obwohl so ein Eis echt lecker wäre...");
            SetButtonsText("weiter");
            previous = Previous.EisNichtGekauft;
        }

        private void Taube()
        {
            SetzeHintergrundBild("taube_mit_nunchakus.png");
            WriteText("Du gehst weiter die Straße entlang.",
                "Von weitem kannst du schon den Berg erspähen. Auf einmal springt dir eine dicke, türkise Taube in den Weg. Im Schnabel trägt sie ein paar Nunchucks, die sie drohend in deine Richtung schwenkt.Ihr tiefes Gurren geht durch Mark und Bein.");
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
            AktuellerHeld.FuegeItemHinzu(new Item("Nunchucks", GetBild("nunchakus.png")));
            SetButtonsText("weiter");
            previous = Previous.TaubeTreten;
        }

        private void BrueckenZoll()
        {
            WriteText("Du gehst weiter auf dem Weg.",
                "Vor dir liegt eine Brücke. In einem kleinen Häuschen sitzt ein Zollbeamter.",
                "“Das Passieren dieser kürbistanischen Staatsbrücke ist kostenpflichtig. Das wären für sie ... mal sehen ... Brückenpauschale plus Bearbeitungsgebühr minus Feiertagsrabatt plus Mittagszuschlag ... 3 im Sinn ... eine Münze.”");

            bool muenze = AktuellerHeld.HatItem("Münze");
            if (muenze)
            {
                SetButtonsText("“Klar, kein Problem.”", "“Das ist ja Wucher! Ich suche mir einen anderen Weg!”");
                previous = Previous.BrueckenZollMuenzeVorhanden;
            }
            else
            {
                SetButtonsText("“Dann muss ich mir wohl einen anderen Weg suchen.”");
                previous = Previous.BrueckenZollMuenzeNichtVorhanden;
            }
        }

        private void WegZurTiefseegrotte()
        {
            WriteText("Der einzige weitere Weg führt durch den dunklen Wald.",
                "Du bist nun tief im Wald. Deine Orientierung ist im Eimer. Na toll.",
                "Blindlings stoplerst du durch das Unterholz, aber der Wald wird immer dichter.",
                "Schließlich ist es so dunkel, dass du dich nur noch tastend fortbewegen kannst. Immer wieder hörst du es knacken, wenn du mal wieder über einen Ast gerobbt bist.",
                "Doch plötzlich hörst du ein ganz lautes Knacken, gefolgt von einem Knirschen und urplötzlich verliertst du den Boden unter dem Körper. Du fällst und fällst und machst dich auf den Aufprall gefasst.",
                "Dieser gestaltet sich anders als erwartet. Deine Füße tauchen zuerst ein. Kühles Nass.",
                "Du scheinst in einer Unterwassergrotte gelandet zu sein!");
            SetButtonsText("weiter");
            previous = Previous.WegZurTiefseegrotte;

        }

        private void RaetselMauer()
        {
            AktuellerHeld.EntferneItem("Münze");
            WriteText("Du passierst die Brücke und gehst munter weiter. Fast stößt du dir den Kopf, als die Straße abrupt vor einer hohen Wand endet. Links und rechts ist kein Ende der Mauer in Sicht.",
                "Als du prüfend an die Wand klopfst, erscheint folgender Text:",
                "“Wanderer hab Acht: Ginget Ihr in eine Hütte, derer Bewohner drei und verließen zwei Bewohner das Bauwerk, während durch die Hinterpforte fünf Menschen einträten, wie viele habt Ihr?", "",
                "Eins? Fünf? Vierunddreißig? Acht? Kürbis?”",
                "(Gib deine Antwort unten ein");
            EingabefeldNutzen();
            previous = Previous.RaetselMauer;
        }

        private void Raetsel2()
        {
            WriteText("Selbstsicher sprichst du das Passwort und läufst auf die Wand zu. Klatsch! Krach! Du liegst am Boden. Als du dir den Kopf reibst, erscheint ein neuer Text auf der Wand",
                "“Idiot! Normalerweise wäre es aus mit dir, aber du bist unterhaltsam. Ich gebe dir noch eine Gelegenheit.",
                "Wanderer hab Acht: Ginget Ihr in eine Hütte, derer Bewohner drei und verließen zwei Bewohner das Bauwerk, während durch die Hinterpforte fünf Menschen einträten, wie viel habt Ihr?",
                "Blau? Donald J Trumpkin? Eierkarton? Acht? Thoron?”",
                "(Gib deine Antwort unten ein)");
            EingabefeldNutzen();
            previous = Previous.Raetsel2;
        }

        private void Windstoß()
        {
            WriteText("Ein orkanartiger Windstoß erfasst dich. Du wirbelst durch die Luft und siehst schon dein ganzes Leben an deinem inneren Augen vorbeifliegen. Mit einem harten Aufprall landest du auf dem Boden.",
                "[-Gesundheit]");
            SetButtonsText("weiter");
            AktuellerHeld.Lebenspunkte = AktuellerHeld.Lebenspunkte - 5;
            previous = Previous.Windstoß;
        }

        private void Weggabelung()
        {
            WriteText("Mit lautem scharren pellt sich wie von Geisterhand ein Torbogen aus der Wand. Du trittst hindurch.",
                "Du gehst weiter und lässt die Wand hinter dir. Nun bemerkst du zum ersten Mal, wie viele Tiere hier leben. Kaninchen hoppeln umher, Vögel zwitschern, Wildschweine suhlen sich im Dreck, Sumpfpichler picheln vor sich hin. Idyllisch!",
                "Der Weg wird steiler und mühsamer, Allgäuer Latschenkiefern säumen den Wegesrand. Im Hintergrund hörst du einen Bergmann jodeln. Du hast den Fuß des Berges erreicht.",
                "An einer Weggabelung stehen zwei Schilder.",
                "Das Schild “Sicherer Tod” zeigt nach links. Das andere “Zuckerwatte” zeigt nach rechts.",
                "Welchen Weg schlägst du ein?");
            SetButtonsText("Sicherer Tod.", "Zuckerwatte.");
            previous = Previous.Weggabelung;
        }

        private void Aufzug()
        {
            WriteText("Der Weg führt um die Ecke. Da steht ein Aufzug herum. Mitten in der Natur! Du gehst hinein. Im Aufzug steht bereits ein Troll, den du mit einem leisen “Mahlzeit” und so wenig Augenkontakt wie möglich begrüßt.",
                "Du drückst auf den Knopf “Zum Schatz” und quetscht dich neben den riesigen Troll.",
                "Der Aufzug setzt sich in Bewegung und im Hintergrund spielt leise “Old Town Road”. Peinliches Schweigen.",
                "Auf der Etage “Kinderfresser” verlässt der Troll mit einem grunzenden Abschied und einem kurzen Lupfen seines Hutes den Aufzug. Du atmest durch.",
                "Mit einem “Pling” öffnet sich die Tür auf der Etage 'Schatz' und vor dir leuchtet der größte Schatz, den man sich nur vorstellen kann. Freudig stürzt du dich auf das Gold!");
            SetButtonsText("weiter");
            previous = Previous.Aufzug;
        }

        private void Fußweg()
        {
            WriteText("Das Schild war eine glatte Lüge! Du schleppst dich die gänzlich zuckerwattefreie Treppe hoch und bist damit etliche Stunden zugange.",
                "Zu Beginn zählst du noch die Stufen, um hinterher mit der schieren Anzahl angeben zu können, aber bei 84.287 fallen dir die Augen zu und du fällst einige Meter zurück. Dabei vergisst du deine Zählung. So ein Mist ab auch!",
                "Völlig abgekämpft erreichst du nach gefühlten Ewigkeiten den Gipfel. Links von dir steht ein Aufzug. Hättest du doch den anderen Weg genommen!",
                "Aber dann bricht ein Funkeln durch die schweren Lider. Mit müden Augen erspähst du den Schatz. Eine Wunderpracht! Du träumst bereits davon, wie Dagobert Duck in Talern zu schwimmen!",
                "Mit Freudentränen, die dein Gesicht herunterströmen, gehst du langsam auf den Geoldberg zu.");
            SetButtonsText("weiter");
            AktuellerHeld.Lebenspunkte = AktuellerHeld.Lebenspunkte - 5;
            previous = Previous.Fußweg;
        }
    }
}
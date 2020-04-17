using SchuBS_Textadventure.Objects;

using static SchuBS_Textadventure.TextadventureHelper;

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
                "Einige Minuten später siehst du am Wegesrand einen bunten Verkaufsstand. Die exzentrische, pinkhaarige Verkäuferin preist lautstark Eis an.",
                "“Das beste Eis in Kürbistan! Kürbiseis! Nur heute für den kleinen, kleinen Preis von einer Münze! Wenn Sie jetzt anhalten und sofort bestellen, gibt es einen Messerblock kostenlos dazu!”",
                "Du bist die einzige Person auf der Straße und fühlst dich angesprochen.",
                "Möchtest du ein Eis kaufen, oder ignorierst du diese süße Versuchung?");
            SetButtonsText("“Ich nehme ein Kürbiseis!”", "Weitergehen, Keinen Augenkontakt aufnehmen!");
            previous = Previous.EisKaufen;
        }

        private void EisGekauft()
        {
            WriteText("Das Kürbiseis ist gar nicht mal so gut. Was für eine Abzocke!",
                "Aber der Messerblock könnte noch von Nutzen sein. Ist ganz schön schwer, das Ding.");

            AktuellerHeld.EntferneItem("Münze");
            AktuellerHeld.FuegeItemHinzu(new Item("Messerblock", "messerblock.png"));
            SetButtonsText("weiter");
            previous = Previous.EisGekauft;
        }

        private void EisNichtGekauft()
        {
            WriteText("Obwohl so ein Eis echt lecker wäre...");
            SetButtonsText("weiter");
            previous = Previous.EisNichtGekauft;
        }

        private void Taube()
        {
            SetzeHintergrundBild("taube_mit_nunchakus.png");
            WriteText("Du gehst weiter die Straße entlang.",
                "Von weitem kannst du schon den Berg erspähen. Auf einmal springt dir eine dicke, türkise Taube in den Weg. Im Schnabel trägt sie ein paar Nunchakus, die sie drohend in deine Richtung schwenkt. Ihr tiefes Gurren geht durch Mark und Bein.");
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
            WriteText("Die Taube fliegt wie ein Fußball durch die Luft und landet mit traurigem Gurren im Wald. Das sollte sich erstmal erledigt haben! Die Nunchakus nimmst du an dich",
                "Die Nunchakus nimmst du an dich.");
            AktuellerHeld.FuegeItemHinzu(new Item("Nunchakus", "nunchakus.png"));
            SetButtonsText("weiter");
            previous = Previous.TaubeTreten;
        }

        private void BrueckenZoll()
        {
            SetzeHintergrundBild("bruecke_mit_zollamt.png");
            WriteText("Du gehst weiter auf dem Weg.",
                "Vor dir liegt eine Brücke. In einem kleinen Häuschen sitzt ein Zollbeamter.",
                "“Das Passieren dieser kürbistanischen Staatsbrücke ist kostenpflichtig. Das wären für sie...",
                "mal sehen ... Brückenpauschale plus Bearbeitungsgebühr...",
                "minus Feiertagsrabatt plus Mittagszuschlag...",
                "3 im Sinn ... eine Münze.”")  ;

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
            SetzeHintergrundBild("dunkler_wald.jpg");
            WriteText("Der einzige weitere Weg führt durch den dunklen Wald.",
                "Du bist nun tief im Wald. Deine Orientierung ist im Eimer. Na toll.",
                "Blindlings stoplerst du durch das Unterholz, aber der Wald wird immer dichter.");
            SetButtonsText("rechts abbiegen", "links abbiegen");
            previous = Previous.WegZurTiefseegrotte;
        }

        private void ZurueckAufStraße()
        {
            WriteText("Du entschließt dich, alle Vorsicht fallen zu lassen und läufst mit zugekniffenen Augen durch die Gegend. " +
                "Merkwürdigerweise bleibt dein Kopf bei diesem Unterfangen heile. " +
                "Als du wieder eine Straße unter deinen Füßen spürst, öffnest du deine Augen wieder.");
            SetButtonsText("Weiter");
            previous = Previous.ZurueckAufStraße;
        }

        private void RaetselMauer()
        {
            SetzeHintergrundBild("weg_wand.png");
            AktuellerHeld.EntferneItem("Münze");
            WriteText("Du gehst munter weiter. Fast stößt du dir den Kopf, als die Straße abrupt vor einer hohen Wand endet. Links und rechts ist kein Ende der Mauer in Sicht.",
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
            WriteText("Ein orkanartiger Windstoß erfasst dich. Du wirbelst durch die Luft und siehst schon dein ganzes Leben an deinem inneren Augen vorbeifliegen. Mit einem harten Aufprall landest du auf dem Boden.");
            SetButtonsText("weiter");
            AktuellerHeld.Lebenspunkte = AktuellerHeld.Lebenspunkte - 5;
            previous = Previous.Windstoß;
        }

        private void Weggabelung()
        {
            SetzeHintergrundBild("fuss_des_berges.jpg");
            WriteText("Mit lautem scharren pellt sich wie von Geisterhand ein Torbogen aus der Wand. Du trittst hindurch.",
                "Du gehst weiter und lässt die Wand hinter dir. Nun bemerkst du zum ersten Mal, wie viele Tiere hier leben. Kaninchen hoppeln umher, Vögel zwitschern, Wildschweine suhlen sich im Dreck, Sumpfpichler picheln vor sich hin. Idyllisch!",
                "Der Weg wird steiler und mühsamer, Allgäuer Latschenkiefern säumen den Wegesrand. Im Hintergrund hörst du einen Bergmann jodeln. Du hast den Fuß des Berges erreicht.",
                "An einer Weggabelung stehen zwei Schilder.",
                "Das Schild “Sicherer Tod” zeigt nach links. Das andere Schild “Zuckerwatte” zeigt nach rechts.",
                "Welchen Weg schlägst du ein?");
            SetButtonsText("Sicherer Tod.", "Zuckerwatte.");
            previous = Previous.Weggabelung;
        }

        private void Aufzug()
        {
            SetzeHintergrundBild("natur_aufzug.png");
            WriteText("Der Weg führt um die Ecke. Da steht ein Aufzug herum. Mitten in der Natur! Du gehst hinein. Im Aufzug steht bereits ein Troll, den du mit einem leisen “Mahlzeit” und so wenig Augenkontakt wie möglich begrüßt.",
                "Du drückst auf den Knopf “Zum Schatz” und quetscht dich neben den riesigen Troll.",
                "Der Aufzug setzt sich in Bewegung und im Hintergrund spielt leise “Old Town Road”. Peinliches Schweigen.",
                "Auf der Etage “Kinderfresser” verlässt der Troll mit einem grunzenden Abschied und einem kurzen Lupfen seines Hutes den Aufzug. Du atmest durch.",
                "Mit einem “Pling” öffnet sich die Tür auf der Etage 'Schatz' und vor dir leuchtet der größte Schatz, den man sich nur vorstellen kann. Freudig stürzt du dich auf das Gold!");
            SetButtonsText("weiter");
            AktuellerHeld.FuegeLevelHinzu(Previous.Aufzug);
            previous = Previous.Aufzug;
        }

        private void Fußweg()
        {
            WriteText("Das Schild war eine glatte Lüge! Du schleppst dich die gänzlich zuckerwattefreie Treppe hoch und bist damit etliche Stunden zugange.",
                "Zu Beginn zählst du noch die Stufen, um hinterher mit der schieren Anzahl angeben zu können, aber bei 84.287 fallen dir die Augen zu und du fällst einige Meter zurück. Dabei vergisst du deine Zählung. So ein Mist ab auch!",
                "Völlig abgekämpft erreichst du nach gefühlten Ewigkeiten den Gipfel. Links von dir steht ein Aufzug. Hättest du doch den anderen Weg genommen!",
                "Aber dann bricht ein Funkeln durch die schweren Lider. Mit müden Augen erspähst du den Schatz. Eine Wunderpracht! Du träumst bereits davon, wie Dagobert Duck in Talern zu schwimmen!",
                "Mit Freudentränen, die dein Gesicht herunterströmen, gehst du langsam auf den Goldberg zu.");
            SetButtonsText("weiter");
            AktuellerHeld.Lebenspunkte = AktuellerHeld.Lebenspunkte - 5;
            AktuellerHeld.FuegeLevelHinzu(Previous.Fußweg);
            previous = Previous.Fußweg;
        }

        private void JoshkaBegegnen()
        {
            SetzeHintergrundBild("drachenhoehle.png");
            WriteText("Du hörst ein lautes Schnaufen hinter dir. Noch bevor du dich umdrehen kannst, wirst du auch schon meterweit in Richtung des Goldberges geschleudert.",
                "Deine Gier nach Gold hat dich genau ins Nest des Drachen Joshka geführt. Der Drache speit Feuer im Anblick deiner winzigen Statur und wird wild.",
                "Das Feuer verfehlt dich knapp und du stellst dich dem Ungetüm entgegen. Dies ist der entscheidende Moment. Ein Entkommen ist unmöglich.",
                "Wirst du dich dem Monster stellen und für ein paar Goldstücke dein Leben riskieren? Oder lässt du dich auf ein Tauschgeschäft ein?");
            if (AktuellerHeld.HatItem("Messerblock") || AktuellerHeld.HatItem("Nunchakus"))
            {
                SetButtonsText("Kämpfen!", "Tauschgeschäft");
            }
            else
            {
                SetButtonsText("Kämpfen!");
            }
            previous = Previous.JoshkaBegegnen;
        }

        private void Tauschgeschaeft()
        {
            WriteText("Was möchtest du zum Tausch anbieten?",
                      "(Gib deine Antwort unten ein)");
            EingabefeldNutzen();
            previous = Previous.Tauschgeschaeft;
        }

        private void TauschNunchakus()
        {
            SetzeHintergrundBild("drachenhoehle_phase2.png");
            WriteText("Der Drache findet deine asiatischen Kampfstöckchen ziemlich mager. Mit einem Klauenschnippen werden deine Nunchakus bis nach Kürbistan befördert. Der Drache wird noch zorniger und speit Feuer gen Himmel.",
                "Der Himmel wird blutrot. Joshka ist gewillt, dich nun völlig zu erledigen. Er zieht alle Register und breitet seine gewaltigen Flügel aus. Der letzte Kampf beginnt...");
            AktuellerHeld.EntferneItem("Nunchakus");
            SetButtonsText("weiter");
            previous = Previous.TauschNunchakus;
        }

        private void TauschMesserblock()
        {
            SetzeHintergrundBild("drachenhoehle.png");
            WriteText("Die Augen des Drachen funkeln im Angesicht der scharfen Messer. Er erinnert sich an eine längst vergangene Zeit zurück, als er noch keine Klauen hatte und sein Opfer mit frisch geschliffenen Küchenmessern bearbeiten musste.",
                "Alte Erinnerungen quellen empor. Der Drache denkt zurück an seine alte Jugendliebe, das Leben auf der Farm und schwelgt abwesend vor sich hin.",
                "Du Fuchs, du nutzt natürlich die Gelegenheit und stopfst dir die Taschen mit unzähligen Golddublonen voll. Zeit, abzuhauen.",
                "Du kehrst dem Drachen den Rücken zu und erfüllst dir endlich deinen lang gehegten Traum. Ein Pony.");
            SetButtonsText("weiter");
            previous = Previous.TauschMesserblock;
        }

        #region Kampf
        private void KampfFeuerdracheSchwach()
        {
            SetzeHintergrundBild("drachenhoehle.png");
            StarteKampf(GegnerTyp.FeuerdracheSchwach);
            SetzePersonenBild("Leer500.png");

            previous = Previous.FeuerdracheSchwachKaempfen;
        }

        private void KampfSchwachBeendet()
        {
            SetzeHintergrundBild("drachenhoehle_phase2.png");
            WriteText("Der Drache ist beeindruckt von deinen Ninjafähigkeiten. Noch nie hat er jemanden getroffen, der so erbittert mit ihm gekämpft hat.",
                "Er kann jedoch nicht einknicken. Dies ist nicht sein Gold, es ist nur geliehen. Joshka ist gewillt dich nun völlig zu erledigen.",
                "Er zieht alle Register und breitet seine gewaltigen Flügel aus. Der letzte Kampf beginnt...");
            SetButtonsText("Zum nächsten Kampf");
            previous = Previous.FeuerdracheSchwachBesiegt;
        }

        private void KampfFeuerdracheStark()
        {
            StarteKampf(GegnerTyp.FeuerdracheStark);
            previous = Previous.FeuerdracheStarkKaempfen;
        }
        #endregion

        #region Enden
        private void EndeThemenpark()
        {
            SetzeHintergrundBild("deathscreen_villa.png");
            if (AktuellerHeld.HatLevel(Previous.Fußweg))
            {
                WriteText("Du machst dich mit deinen neu erlangten Reichtümern auf den Weg nach Hause.", "",
                    "Ein Jahr später. Die Eröffnung deines eigenen Themenparks. Besonders stolz bist du auf die Achterbahn, die durch einen ausgestopften Drachen führt.",
                    "Die Bürger von Kürberlin sind in Scharen angekommen und haben dir Unmengen an Geld und Kürbissen gegeben, nur um dieses neue Highlight im Königreich zu bewundern. Davon werden sie noch ihren Kindern erzählen!",
                    "Außerdem hast du, nach deinem Treppenmartyrium beim Drachenkampf geschworen, nie wieder auch nur eine Stufe zu erklimmen. Deine Leibwächter tragen dich im Sonnenuntergangslicht zu deiner Villa.",
                    "Das Leben ist schön!");
            }
            else if (AktuellerHeld.HatLevel(Previous.Aufzug))
            {
                WriteText("Du machst dich mit deinen neu erlangten Reichtümern auf den Weg nach Hause.", "",
                    "Ein Jahr später. Die Eröffnung deines eigenen Themenparks. Besonders stolz bist du auf die Achterbahn, die durch einen ausgestopften Drachen führt.",
                    "Die Bürger von Kürberlin sind in Scharen angekommen und haben dir Unmengen an Geld und Kürbissen gegeben, nur um dieses neue Highlight im Königreich zu bewundern. Davon werden sie noch ihren Kindern erzählen!",
                    "Du gehst Richtung Sonnenuntergang deiner Villa entgegen.",
                    "Das Leben ist schön!");
            }
            SpielZuende();
        }

        private void TodKampf()
        {
            SetzeHintergrundBild("you_died_lol.png");
            WriteText("Du fällst getroffen, wie in Zeitlupe, zu Boden. Oh grausames Schicksal! Oh schlimmer Tod! Es ist dein endgültiges Ende, welches dein Dasein beendet.",
                "So hat du es nicht gewollt, aber dem Schicksal kann man nicht auf ewig entfliehen.",
                "Du durchläufst im Bruckteil einer Sekunde alle fünf Phasen der Trauer nach Kübler-Ross und endlich akzeptierst du dein Dahinscheiden. Adieu, schnöde Welt!");
        }
        #endregion
    }
}
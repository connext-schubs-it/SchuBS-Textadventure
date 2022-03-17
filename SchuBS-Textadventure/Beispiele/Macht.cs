using SchuBS_Textadventure.Objects;

using System.Collections.Generic;

using static SchuBS_Textadventure.TextadventureHelper;

namespace SchuBS_Textadventure
{
    public partial class Textadventure
    {
        public void MachtStart()
        {
            SetzeHintergrundBild("landschaft_1.jpg");
            WriteText("“Schön zu hören.",
                "An der Grenze dieses Landes existiert ein Königreich, welches ausschließlich von Kürbisbauern bevölkert wird.",
                "Es ist ein sehr armes Land, aber die Ernte ist reich und die Menschen gütig. Und die Halloweenpartys sind der Hammer.",
                "Dein Kürbiskopf hätte sicherlich gute Chancen auf den Königstitel.",
                "Um zum Königreich Kürbistan zu gelangen, könntest du über die Kaffeebohnenplantage oder über die Tiefseegrotte reisen.",
                "Wie entscheidest du dich?”");

            SetActions(("Kaffeebohnenplantage", KaffeBohnenplantage), ("Tiefseegrotte", TiefseegrotteFragen));
        }

        public void TiefseegrotteFragen()
        {
            SetzeHintergrundBild("landschaft_1.jpg");
            WriteText("“Bist du dir da sicher? Ich habe gehört in der Tiefseegrotte soll es seltsame Wesen geben.”");

            SetActions(("Ich habe doch keine Angst vor seltsamen Wesen einer Tiefseegrotte! Ab zum See!", TiefseegrotteSchwimmen),
                ("Dann gehe ich doch lieber über die Kaffeebohnenplantage!", KaffeBohnenplantage));
        }

        public void TiefseegrotteSchwimmen()
        {
            SetzeHintergrundBild("tiefseegrotte.png");
            WriteText("Du schwimmst angespannt und höchst aufmerksam durch die Tiefseegrotte. Hinter einer Ecke taucht eine Abzweigung auf.",
                      "Der Linke Weg ist tief dunkel und du kannst nicht erkennen, wie es dort weiter gehen könnte. Aber geradeaus wird es heller.",
                      "Dein Kopf sagt dir: Schwimm geradeaus weiter. Aber wie entscheidet dein Bauch?");

            SetActions(("Den linken Weg nehmen!", TiefseegrotteLinksSchwimmen), ("Geradeaus weiterschwimmen!", TiefseegrotteBegegnungUngeheuer));
        }

        public void TiefseegrotteLinksSchwimmen()
        {
            SetzeHintergrundBild("tiefseegrotte.png");

            WriteText("Todesmutig und entgegen deines Kopfes biegst du links ab. Du musst immer weiter in die Tiefe tauchen um vorwärts zu kommen und es wird immer dunkler.",
                      "Doch plötzlich spürst du einen Strudel. Du denkst jetzt ist alles vorbei.",
                      "Doch entgegen deiner Erwartungen bringt dich der Strudel an die Wasseroberfläche. Du schaffst es zum Ufer und kletterst an Land.",
                      "Du entdeckst einen Weg.",
                      "Der Weg führt dich vorbei an einem Kürbisacker zu einem kleinen Dorf…");

            SetActions(("Weiter", KaffeBohnenplantageIstMachtWichtig));
        }

        public void TiefseegrotteBegegnungUngeheuer()
        {
            SetzePersonenBild("tiefsee_ungeheuer.png");

            WriteText("Du schwimmst ein ganzes Stück immer geradeaus.",
                      "Es wird immer heller und als du denkst, du hat die Grotte schon fast verlassen, steht dir plötzlich ein Ungeheuer im Weg.",
                      "Es sieht sehr groß und mächtig aus.",
                      "Möchtest du gegen das Ungeheuer kämpfen oder versuchen, dich an dem Ungeheuer vorbei zu mogeln?");

            SetActions(("Kämpfen!", TiefseegrotteUngeheuerKaempfen), ("Vorbeimogeln.", TiefseegrotteVorbeimogeln));
        }

        public void TiefseegrotteUngeheuerKaempfen()
        {
            WriteText($"Ungeheuer fordert dich zum Kampf!", "Was wirst du tun?!");
            StarteKampf(GegnerTyp.Ungeheuer, TiefseegrotteUngeheuerBesiegt);
        }

        public void TiefseegrotteUngeheuerBesiegt()
        {
            EntferneGegner();
            WriteText("Du hast das Ungeheuer besiegt und kannst ungehindert deinen Weg fortsetzen.",
                      "Der Weg bis zur Wasseroberfläche ist tatsächlich nicht mehr weit und dir gelingt es an Land zu klettern.");
            SetActions(("weiter", KueberlinAnkunft));
        }

        public void TiefseegrotteVorbeimogeln()
        {
            WriteText("Du versteckst dich hinter einem Felsvorsprung und imitierst das Gackern eines Huhnes.",
                      "“Versuch locker zu bleiben”, sagst du dir immer wieder.",
                      "Das Ungeheuer kriecht hungrig auf dich zu und hinterlässt eine Spur aus Sabber auf seinem Weg.",
                      "Du gerätst in Panik, du hast seine Größe unterschätzt. Vielleicht war das nicht die klügste Entscheidung. Aber was wirst du tun?");

            SetActions(("Panisch versuchen, um das Monster herum zu rennen!", TiefseegrotteVorbeimogeldTod),
                ("Versuchen, eine erwachsene Konversation zu führen", TiefseegrotteKonversation));
        }

        public void TiefseegrotteVorbeimogeldTod()
        {
            SetzeHintergrundBild("you_died_lol.png");

            WriteText("Kreischend und mit wild schlackernden Armen rennst du auf das Ungeheuer zu. Das Ungetüm ist eingeschüchtert und wirkt ängstlich.",
                      "Wieso schreist du so laut?! Es zieht seinen Kopf ein und winselt um Gnade, was du aber aufgrund der Panik nicht wahrnimmst.",
                      "Du läufst in Schlangenlinien um das Ungeheuer, doch rutschst anmutig auf der Sabberspur aus.",
                      "Du stößt dir den Kopf und alles wird schwarz.");

            SpielZuende();
        }

        public void TiefseegrotteKonversation()
        {
            EingabefeldNutzen(TiefseegrotteKonversationEingabe);

            List<string> text = new()
            {
                "Du atmest tief durch und trittst vor das Ungeheuer. Deine Knie sind weich, doch du stehst erhobenen Hauptes und fragst das Monster nach dem Grund seines Zorns.",
                "Bittere, riesige Tränen kullern an den scharfen Fangzähnen des Ungeheuers vorbei. Es gibt unverständliche Grunzlaute von sich und versucht, dir etwas mitzuteilen.",
                "Aber was kann das nur sein? Du beschließt, konsequent darauf zu antworten und sagst:…",
                "(Gib die die Zahl der Antwort in das Textfeld ein).",
                "Mögliche Antworten:",
                "(1) Hör auf zu flennen.",
                "(2) Mir hat auch mal jemand das Herz gebrochen.",
                "(3) Ein paar Kilogramm weniger könntest du schon vertragen.",
                "(4) Hör mal, ich habe wirklich keine Zeit dafür."
            };

            if (AktuellerHeld.Klasse.KlassenTyp == KlassenTyp.Magier)
            {
                text.Add("(5) I SHALL PASS!");
            }

            WriteText(text);

            //BEI 1 UND 3 SOLL DER SPIELER STERBEN-> TiefseegrotteFalscheAntwort
            //BEI 2,4 UND 5 SOLL DER SPIELER ITEM ,,EIER" ERHALTEN-> TiefseegrotteRichtigeAntwort
        }

        public bool TiefseegrotteKonversationEingabe()
        {
            int zahl = EingabeZahl;
            if (zahl == 5 && AktuellerHeld.Klasse.KlassenTyp != KlassenTyp.Magier)
            {
                zahl = -1;
            }

            switch (zahl)
            {
                case 1:
                case 3:
                    TiefseegrotteFalscheAntwort();
                    break;

                case 2:
                case 4:
                case 5:
                    TiefseegrotteRichtigeAntwort();
                    break;

                default:
                    const string AntwortGibtEsNicht = "Diese Antwortmöglichkeit gibt es nicht.";
                    if (!TextBoxHauptText.Text.EndsWith(AntwortGibtEsNicht))
                    {
                        AppendText("", AntwortGibtEsNicht);
                    }
                    return false;
            }

            return true;
        }

        public void TiefseegrotteFalscheAntwort()
        {
            //BEI 1 UND 3 SOLL DER SPIELER STERBEN

            SetzeHintergrundBild("you_died_lol.png");
            WriteText("Das Ungeheuer wird wütend und schlägt wild um sich. Du hättest seine Gefühle nicht verletzen sollen.",
                      "So ein Mist aber auch.");

            SpielZuende();
        }

        public void TiefseegrotteRichtigeAntwort()
        {
            //BEI 2,4,5 GIBT ES DAS ITEM EIER UND ES GEHT WEITER

            AktuellerHeld.FuegeItemHinzu(new Item("Ei", "ei.png"));

            WriteText("Das Ungeheuer streckt seine Zunge raus und überreicht dir eine Packung Eier.",
                      "Es tritt zur Seite und salutiert, während du stolz, aber auch ziemlich verwundert zum Ausgang der Grotte schreitest.");

            SetActions(("Weiter", KaffeBohnenplantageIstMachtWichtig));
        }

        public void KaffeBohnenplantage()
        {
            SetzeHintergrundBild("kaffeebohnenplantage.jpg");
            WriteText("Du verabschiedest dich und schlenderst ganz gemütlich über die Kaffeebohnenplantage.",
                "Du siehst einen Baum, in dessen Schatten du erstmal eine kleine Pause einlegst.",
                "Abenteuer sind schließlich anstrengend.",
                "Im Halbschlaf kommst du ins Grübeln: Ist dir Macht wirklich so wichtig? ");

            SetActions(("Ja klar. Und ich liebe Kürbisse!", KaffeBohnenplantageIstMachtWichtig),
                ("Was will ich denn mit Macht, wenn ich auch reich sein könnte?", EisKaufenMitMuenze));
        }

        public void KaffeBohnenplantageIstMachtWichtig()
        {
            SetzeHintergrundBild("kuerberlin_mit_kuerbispalast.png");
            SetzePersonenBild("kobold_punks_new.png");
            WriteText("Der Weg führt dich vorbei an einem Kürbisacker zu einem kleinen Dorf … ",
                "Dir bietet sich ein grandioser Ausblick. Das Dorf Kürberlin liegt vor dir.",
                "Abenteuerlust steigt in dir auf als du das Dorf betrittst, doch du spürst, dass etwas anders ist. ",
                "Unheil liegt in der Luft.",
                "Kein einziger Dorfbewohner ist zu sehen und zu allem Übel kommen drei sehr furchteinflößende Kobold-Punks auf dich zu. ",
                "“Wir sind die Kobold-Punks, wir sind hier um die Menschen aufzumischen, und du bist der nächste!” ",
                "Was wirst du tun? ");

            bool eier = AktuellerHeld.HatItem("Ei");
            if (eier)
            {
                SetActions(("Um Gnade flehen ", KaffeBohnenplantageGnadeFlehen),
                    ("Kämpfen!", KaempfenKaffeeGegenKobolde),
                    ("Mit Eiern werfen ", KaffeBohnenplantageMitEiernWerfen));
            }
            else
            {
                SetActions(("Um Gnade flehen ", KaffeBohnenplantageGnadeFlehen),
                    ("Kämpfen!", KaempfenKaffeeGegenKobolde));
            }
        }

        public void KaffeBohnenplantageGeschenkeAbweisen()
        {
            SetzeHintergrundBild("kaffeebohnenplantage.jpg");
            WriteText("Wie undankbar.  ",
                "Die gütigen Bewohner des Königreichs wollen dir ihr letztes Hab und Kürbistum anbieten und du lehnst ab. ",
                "Schäm dich.",
                "Den Bürgern gefällt deine Einstellung ganz und gar nicht. ",
                "Sie schmeißen dich umgehend aus der Stadt und sagen dir, dass du nie wieder ihr Land betreten sollst. ",
                "Wie gut, dass anscheinend alle hier an Amnesie leiden.");
            SetActions(("Weiter", KaffeBohnenplantageMitEiernWerfen));
        }

        public void KaffeBohnenplantageGeschenkeAnnehmen()
        {
            SetzeHintergrundBild("kaffeebohnenplantage.jpg");
            WriteText("Nachdem du die gütigen Geschenke empfängst und auf direktem Weg zum Kürbispalast bist, strecken dir auch schon die ersten ihre leeren Hände entgegen.  ",
                "Das sind schließlich Händler, die vom Kürbishandel leben.  ",
                "Wie? ",
                "Das wusstest du nicht? ",
                "Wie willst du dann ihr König werden?! Du beschließt....  ");
            SetActions(("...das Weite zu suchen!", KaffeBohnenplantageWeiteSuchen),
                ("...dich deiner Verantwortung zu stellen.", KaffeBohnenplantageVerantwortungStellen));
        }

        public void KaffeBohnenplantageVerantwortungStellen()
        {
            SetzeHintergrundBild("kaffeebohnenplantage.jpg");
            WriteText("Du stellst dich deinem Schicksal und erklärst den Bewohner deine missliche Lage.",
                "Nun wirst du bis ans Ende aller Tage deine Schulden auf den Kürbisackern von Kürbistan arbeiten.",
                "Du wirst nicht reich und auch nicht mächtig, jedoch gibt es von nun an jeden Morgen Kürbisbrot.",
                "Vielleicht gewöhnst du dich eines Tages daran.",
                "Außer...");

            bool muenze = AktuellerHeld.HatItem("Münze");
            if (muenze)
            {
                SetActions(("...du verwendest mehr Salz", KaffeBohnenplantageSalzverwenden),
                    ("...du gönnst dir mal ein richtiges Steak.  ", KaffeBohnenplantageSteak));
                AktuellerHeld.EntferneItem("Münze");
            }
            else
            {
                SetActions(("...du verwendest mehr Salz", KaffeBohnenplantageSalzverwenden));
            }
        }

        public void KaffeBohnenplantageSteak()
        {
            SetzeHintergrundBild("food_truck_deathscreen.png");
            WriteText("Außerhalb der Stadt steht ein Food-Truck \"Food-to-Goat.\"",
                "Dein alter Kumpel Jürgen bedient dich heute. ",
                "Er empfiehlt dir direkt ein Stück seines besten Fantasy-Ziegenfleisches, welches er für dich sofort auf den Grill schmeißt.",
                "Dieses Steak ist mehr als du dir jemals erträumen konntest.",
                "Die saftige Konsistenz, der ausfüllende Duft, der dir in die Nase steigt, die goldig braune Farbe dieses anmutigen Stückes köstlichen Fleisches.",
                "Jürgen gefällt dein Sinn für Geschmack. Er bietet dir einen Arbeitsplatz in seinem Food-truck an, den du selbstverständlich gerne annimmst.",
                "Mit brutzelndem Fleischduft in der Nase macht das Schulden abarbeiten viel mehr Spaß.",
                "Schönes Leben noch.");
            SpielZuende();
        }

        public void KaffeBohnenplantageSalzverwenden()
        {
            SetzeHintergrundBild("kaffeebohnenplantage.jpg");
            WriteText("Mmmhhhhh, das schmeckt. Gar nicht übel.",
                "Reicht dir eine Prise Salz für den Rest deines Lebens?",
                "Nein?!",
                "Das muss es aber.",
                "Schönes Leben noch.");
            SpielZuende();
        }

        public void KaffeBohnenplantageWeiteSuchen()
        {
            SetzeHintergrundBild("kaffeebohnenplantage.jpg");
            WriteText("Du fliehst vor dem wütenden Mob, diese sind aber ziemlich flink für ihre magere Statur. Schließlich sind in Kürbissen Vitamine und Ballaststoffe vertreten.   ",
                "Du lässt die getragenen Kürbisse aufgrund der kritischen Situation fallen und entkommst den zornigen Bewohnern. ",
                "Diese bleiben zurück und singen Klagelieder für die am Boden zerschellten Kürbisse. ",
                "Trauerstimmung macht sich breit. Aber nicht für dich, denn du stehst nun unmittelbar vor dem Kürbispalast. ",
                "Nachdem du eingelassen wurdest, wirst du auch schon direkt in den Thronsaal geleitet. Jetzt steht dir und dem Königstitel nichts mehr im Wege. ",
                "Außer dem einzigen anderen Anwärter: Donald J. Trumpkin. ",
                "Der erbitterte Wahlkampf beginnt. Donald J. Trumpkin weiß worauf es ankommt. Er verspricht dem Volk die Aufrüstung der Kürbisgrenzen und Sanktionen für das benachbarte Rübanien. ",
                "Er hat gute Chancen. Aber du weißt, was die Bewohner wirklich wollen. ",
                "Sie wollen....");
            bool eier = AktuellerHeld.HatItem("Ei");
            if (eier)
            {
                SetActions(("...mehr Kürbisse ", KaffeBohnenmehrKuerbisse), ("...Eier", KaffeBohnenWollenEier));
            }
            else
            {
                SetActions(("...mehr Kürbisse ", KaffeBohnenmehrKuerbisse));
            }
        }

        //----------------------------------------------------------------Kuerberlin
        public void KueberlinAnkunft()
        {
            SetzeHintergrundBild("kuerberlin_mit_kuerbispalast.png");
            SetzePersonenBild("kobold_punks_new.png");
            WriteText("Der Weg führt dich vorbei an einem Kürbisacker zu einem kleinen Dorf … ",
                "Dir bietet sich ein grandioser Ausblick. Das Dorf Kürberlin liegt vor dir.",
                "Abenteuerlust steigt in dir auf als du das Dorf betrittst, doch du spürst, dass etwas anders ist. ",
                "Unheil liegt in der Luft.",
                "Kein einziger Dorfbewohner ist zu sehen und zu allem Übel kommen drei sehr furchteinflößende Kobold-Punks auf dich zu. ",
                "“Wir sind die Kobold-Punks, wir sind hier um die Menschen aufzumischen, und du bist der nächste!” ",
                "Was wirst du tun? ");
            bool eier = AktuellerHeld.HatItem("Ei");
            if (eier)
            {
                SetActions(("Um Gnade flehen ", KaffeBohnenplantageGnadeFlehen),
                    ("Kämpfen!", KaempfenKaffeeGegenKobolde),
                    ("Mit Eiern werfen ", () => { }));
            }
            else
            {
                SetActions(("Um Gnade flehen ", KaffeBohnenplantageGnadeFlehen),
                    ("Kämpfen!", KaempfenKaffeeGegenKobolde));
            }
        }

        public void KuerberlinGnadeFlehen()
        {
            SetzePersonenBild("kobold_punks.png");

            WriteText("Du bittest um Verzeihung und versuchst, die finsteren Gestalten durch Selbstmitleid von ihren Machenschaften abzubringen.",
                      "“Kannste knicken”, schnauft der Anführer der Kobold-Punks. Der Kampf beginnt.");

            SetActions(("Weiter", KuerberlinKoboldKampf));
        }

        public void KaffeBohnenmehrKuerbisse()
        {
            SetzeHintergrundBild("kuerbisfelder_koenig_deathscreen.png");
            WriteText("Das Kürbisreich verlangt nach noch mehr Kürbis! So etwas hätte ich nicht für möglich gehalten. Aber es stimmt.",
                "Donald J. Trumpkin verspricht dem Volk eine Kürbisflotte, woraufhin du mit Kürbisversicherungen konterst. ",
                "Argument nach Argument, Versprechen nach Versprechen, Stunden vergehen bis sich der hohe Rat berät und den Sieger bekannt gibt: Euch beide! Ihr habt gleich viele Stimmen und seid somit beide König.",
                "Als dir die Kürbiskrone aufgesetzt wird, erkennt der Pöbel den dreisten Kürbisdieb von neulich wieder. ",
                "Das ist nicht weiter schlimm. ",
                "Dann regierst du einfach von den Kürbisfeldern weiter, auf denen du deine Schulden abarbeitest.",
                " Kein König war seinem Volk je so nahe. ");
            SetActions();
        }
        public void KaffeBohnenWollenEier()
        {
            SetzeHintergrundBild("koenig_deathscreen_new.png");
            WriteText("Dir fallen beim besten Willen keine Argumente ein und so beschließt du dich dazu, nichtssagend eine Schachtel Eier emporzuhalten.",
                "Stillschweigen setzt ein, das Volk wirkt schockiert. ",
                "Es hat so etwas schließlich noch nie gesehen. ",
                "Aus Mythen und Legenden hat es von einem Nahrungsmittel gehört, welches keinen Gramm Kürbis enthalten soll. ",
                "Nie hätten sie es für möglich gehalten so etwas wunderschönes jemals zu Gesicht zu bekommen. ",
                "Dem sekundenlangen Schweigen folgt ein Jubeln der Masse.",
                "Die Stimmen sind eindeutig, du bist ihr neuer König. ");
            SetActions();
        }


        public void KuerberlinEier()
        {
            SetzePersonenBild("kobold_punks.png");

            WriteText("Du zückst die Packung Eier und wirfst drauf los. Noch bevor die Kobold-Punks reagieren können, fliegen ihnen auch schon Eier um die übergroßen Ohren.",
                      "Eier sind ihre größte Schwachstelle. Niemand wusste das, du aber schon. Gut gemacht.");

            SetActions(("Weiter", KuerberlinKoboldKampf));

            AktuellerHeld.EntferneItem("Ei");
        }

        public void KuerberlinKoboldKampf()
        {
            KaempfenKaffeeGegenKobolde();
        }

        public void KuerberlinKampfGewonnen()
        {
            EntferneGegner();

            SetzePersonenBild("kobold_punks_new.png");

            WriteText("Du bist der Sieger, ein Gewinner. Die Kobold-Punks ziehen mit geknickten Mienen von dannen.",
                      "Sie konnten dir nichts entgegensetzen und denken nun über eine Umschulung nach.");

            SetActions(("Weiter", KuerbistanAnkunft));
        }

        public void KuerberlinKampfVerloren()
        {
            SetzeHintergrundBild("blaues_auge_deathscreen.png");

            WriteText("Du wurdest aufgemischt. Lass den Kopf nicht hängen. Selbstverständlich kannst du es nochmal versuchen. Am Anfang des Spiels.");

            SpielZuende();
        }

        public void KuerbistanAnkunft()
        {
            SetzeHintergrundBild("kuerberlin_mit_kuerbispalast.png");
            SetzePersonenBild();

            WriteText("Das Königreich Kürbistan liegt vor dir. Kürbisfelder soweit das Auge reicht.",
                      "Die örtlichen Bewohner empfangen dich wehenden Flaggen und reichen dir Kürbisse in allen Farben und Formen.",
                      "Die Menschen strecken dir mehr Kürbisse entgegen als du jemals tragen könntest. Weiß ja schließlich niemand, dass du im Grunde gar keine Kürbisse magst.",
                      "Aber du nimmst die gütigen Geschenke entgegen. Oder etwa nicht?");

            SetActions(("Geschenke annehmen", KuerbistanGeschenkeAnnehmen), ("Geschenke abweisen", KuerbistanGeschenkeAblehnen));
        }

        public void KuerbistanGeschenkeAnnehmen()
        {
            SetzeHintergrundBild("kuerbispalast.jpg");

            WriteText("Nachdem du die gütigen Geschenke empfängst und auf direktem Weg zum Kürbispalast bist, strecken dir auch schon die ersten ihre leeren Hände entgegen.",
                      "Das sind schließlich Händler, die vom Kürbishandel leben.",
                      "Wie? Das wusstest du nicht? Wie willst du dann ihr König werden?! Du beschließt.... ");

            SetActions(("...das Weite zu suchen!", KuerbistanWahlkampf),
                ("...dich deiner Verantwortung zu stellen.", KaffeBohnenplantageVerantwortungStellen));
        }

        public void KuerbistanWahlkampf()
        {
            //Button1
            SetzeHintergrundBild("kuerbispalast.jpg");

            WriteText("Du fliehst vor dem wütenden Mob, diese sind aber ziemlich flink für ihre magere Statur. Schließlich sind in Kürbissen Vitamine und Ballaststoffe vertreten.",
                      "Du lässt die getragenen Kürbisse aufgrund der kritischen Situation fallen und entkommst den zornigen Bewohnern.",
                      "Diese bleiben zurück und singen Klagelieder für die am Boden zerschellten Kürbisse. Trauerstimmung macht sich breit.",
                      "Aber nicht für dich, denn du stehst nun unmittelbar vor dem Kürbispalast. Nachdem du eingelassen wurdest, wirst du auch schon direkt in den Thronsaal geleitet.",
                      "Jetzt steht dir und dem Königstitel nichts mehr im Wege. Außer dem einzigen anderen Anwärter: Donald J. Trumpkin.",
                      "Der erbitterte Wahlkampf beginnt. Donald J. Trumpkin weiß worauf es ankommt.",
                      "Er verspricht dem Volk die Aufrüstung der Kürbisgrenzen und Sanktionen für das benachbarte Rübanien.",
                      "Er hat gute Chancen. Aber du weißt, was die Bewohner wirklich wollen. Sie wollen.... ");

            bool eier = AktuellerHeld.HatItem("Ei");
            if (eier)
            {
                SetActions(("...mehr Kürbisse", KuerbistanMehrKuerbis), ("...Eier", KuerbistanEier));
            }
            else
            {
                SetActions(("...mehr Kürbisse", KuerbistanMehrKuerbis));
            }
        }

        public void KuerbistanMehrKuerbis()
        {
            SetzeHintergrundBild("kuerbisfelder_koenig_deathscreen.png");

            WriteText("Das Kürbisreich verlangt nach noch mehr Kürbis! So etwas hätte ich nicht für möglich gehalten.",
                      "Aber es stimmt. Donald J. Trumpkin verspricht dem Volk eine Kürbisflotte, woraufhin du mit Kürbisversicherungen konterst.",
                      "Argument nach Argument, Versprechen nach Versprechen, Stunden vergehen bis sich der hohe Rat berät und den Sieger bekannt gibt: Euch beide!",
                      "Ihr habt gleich viele Stimmen und seid somit beide König. Als dir die Kürbiskrone aufgesetzt wird, erkennt der Pöbel den dreisten Kürbisdieb von neulich wieder.",
                      "Das ist nicht weiter schlimm. Dann regierst du einfach von den Kürbisfeldern weiter, auf denen du deine Schulden abarbeitest.",
                      "Kein König war seinem Volk je so nahe.");

            SpielZuende();
        }

        public void KuerbistanEier()
        {
            SetzeHintergrundBild("koenig_deathscreen_new.png");

            WriteText("Dir fallen beim besten Willen keine Argumente ein und so beschließt du dich dazu, nichtssagend eine Schachtel Eier emporzuhalten.",
                      "Stillschweigen setzt ein, das Volk wirkt schockiert. Es hat so etwas schließlich noch nie gesehen.",
                      "Aus Mythen und Legenden hat es von einem Nahrungsmittel gehört, welches keinen Gramm Kürbis enthalten soll.",
                      "Nie hätten sie es für möglich gehalten so etwas wunderschönes jemals zu Gesicht zu bekommen.",
                      "Dem sekundenlangen Schweigen folgt ein Jubeln der Masse. Die Stimmen sind eindeutig, du bist ihr neuer König.");

            SpielZuende();
        }

        public void KuerbistanVerantwortung()
        {
            //Button2

        }

        public void KuerbistanGeschenkeAblehnen()
        {
            SetzeHintergrundBild("kuerberlin_mit_kuerbispalast.png");

            WriteText("Wie undankbar. Die gütigen Bewohner des Königreichs wollen dir ihr letztes Hab und Kürbistum anbieten und du lehnst ab. Schäm dich.",
                      "Den Bürgern gefällt deine Einstellung ganz und gar nicht. Sie schmeißen dich umgehend aus der Stadt und sagen dir, dass du nie wieder ihr Land betreten sollst.",
                      "Wie gut, dass anscheinend alle hier an Amnesie leiden.");

            SetActions(("Weiter", KuerbistanAnkunft));
        }

        public void KaffeBohnenplantageMitEiernWerfen()
        {
            AktuellerHeld.EntferneItem("Ei");
            SetzeHintergrundBild("kuerberlin_mit_kuerbispalast.png");
            SetzePersonenBild();
            WriteText("Du zückst die Packung Eier und wirfst drauf los. ",
                   "Noch bevor die Kobold-Punks reagieren können, fliegen ihnen auch schon Eier um die übergroßen Ohren. ",
                   "Eier sind ihre größte Schwachstelle.",
                   "Niemand wusste das, du aber schon. Gut gemacht. ",
                   " ",
                   "Das Königreich Kürbistan liegt vor dir.",
                   "Kürbisfelder soweit das Auge reicht. Die örtlichen Bewohner empfangen dich wehenden Flaggen und reichen dir Kürbisse in allen Farben und Formen.",
                   "Die Menschen strecken dir mehr Kürbisse entgegen als du jemals tragen könntest.",
                   "Weiß ja schließlich niemand, dass du im Grunde gar keine Kürbisse magst.",
                   "Aber du nimmst die gütigen Geschenke entgegen.",
                   "Oder etwa nicht?");
            SetActions(("Geschenke abweisen.", KaffeBohnenplantageGeschenkeAbweisen),
                ("Geschenke annehmen.", KaffeBohnenplantageGeschenkeAnnehmen));
        }

        public void KaffeBohnenplantageGnadeFlehen()
        {
            SetzeHintergrundBild("kuerberlin_mit_kuerbispalast.png");
            WriteText("Du bittest um Verzeihung und versuchst, die finsteren Gestalten durch Selbstmitleid von ihren Machenschaften abzubringen.",
                "“Kannste knicken”, schnauft der Anführer der Kobold-Punks.",
                "Der Kampf beginnt.");
            KaempfenKaffeeGegenKobolde();
        }

        public void KaempfenKaffeeGegenKobolde()
        {
            StarteKampf(GegnerTyp.Kobolde, KaempfenKoboldanfuehrer);
        }

        public void KaempfenKoboldanfuehrer()
        {
            StarteKampf(GegnerTyp.KoboldAnfuehrer, KuerberlinKampfGewonnen);
        }
    }
}

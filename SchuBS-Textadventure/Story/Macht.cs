using SchuBS_Textadventure.Objects;
using System.Collections.Generic;

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

            SetButtonsText("Kaffeebohnenplantage", "Tiefseegrotte");
            previous = Previous.MachtGestartet;
        }

        public void TiefseegrotteFragen()
        {
            SetzeHintergrundBild("landschaft_1.jpg");
            WriteText("“Bist du dir da sicher? Ich habe gehört in der Tiefseegrotte soll es seltsame Wesen geben.”");

            SetButtonsText("Ich habe doch keine Angst vor seltsamen Wesen einer Tiefseegrotte! Ab zum See!", "Dann gehe ich doch lieber über die Kaffeebohnenplantage!");
            previous = Previous.TiefseegrotteErfragt;
        }

        public void TiefseegrotteSchwimmen()
        {
            SetzeHintergrundBild("tiefseegrotte.png");
            WriteText("Du schwimmst angespannt und höchst aufmerksam durch die Tiefseegrotte. Hinter einer Ecke taucht eine Abzweigung auf.",
                      "Der Linke Weg ist tief dunkel und du kannst nicht erkennen, wie es dort weiter gehen könnte.Aber geradeaus wird es heller.",
                      "Dein Kopf sagt dir: Schwimm geradeaus weiter.Aber wie entscheidet dein Bauch?");

            SetButtonsText("Den linken Weg nehmen!", "Geradeaus weiterschwimmen!");
            previous = Previous.TiefseegrotteGeschwommen;
        }

        public void TiefseegrotteLinksSchwimmen()
        {
            SetzeHintergrundBild("tiefseegrotte.png");

            WriteText("Todesmutig und entgegen deines Kopfes biegst du links ab. Du musst immer weiter in die Tiefe tauchen um vorwärts zu kommen und es wird immer dunkler.",
                      "Doch plötzlich spürst du einen Strudel. Du denkst jetzt ist alles vorbei.",
                      "Doch entgegen deiner Erwartungen bringt dich der Strudel an die Wasseroberfläche. Du schaffst es zum Ufer und kletterst an Land.",
                      "Du entdeckst einen Weg.",
                      "Der Weg führt dich vorbei an einem Kürbisacker zu einem kleinen Dorf…");

            SetButtonsText("Weiter");
            previous = Previous.TiefseegrotteLinksSchwimmen;
        }

        public void TiefseegrotteBegegnungUngeheuer()
        {
            SetzePersonenBild("tiefsee_ungeheuer.png");

            WriteText("Du schwimmst ein ganzes Stück immer geradeaus.",
                      "Es wird immer heller und als du denkst, du hat die Grotte schon fast verlassen, steht dir plötzlich ein Ungeheuer im Weg.",
                      "Es sieht sehr groß und mächtig aus.",
                      "Möchtest du gegen das Ungeheuer kämpfen oder versuchen, dich an dem Ungeheuer vorbei zu mogeln?");

            SetButtonsText("Kämpfen!", "Vorbeimogeln.");
            previous = Previous.TiefseegrotteBegegnungUngeheuer;
        }

        public void TiefseegrotteUngeheuerKaempfen()
        {
            WriteText($"Ungeheuer fordert dich zum Kampf!", "Was wirst du tun?!");
            StarteKampf(this, Gegner.GetByTyp(GegnerTyp.Ungeheuer));

            previous = Previous.TiefseegrotteUngeheuerKaempfen;
        }

        public void TiefseegrotteUngeheuerBesiegt()
        {
            EntferneGegner();
            WriteText("Du hast das Ungeheuer besiegt und kannst ungehindert deinen Weg fortsetzen.",
                      "Der Weg bis zur Wasseroberfläche ist tatsächlich nicht mehr weit und dir gelingt es an Land zu klettern.");
            previous = Previous.TiefseegrotteUngeheuerBesiegt;
        }

        public void TiefseegrotteVorbeimogeln()
        {
            WriteText("Du versteckst dich hinter einem Felsvorsprung und imitierst das Gackern eines Huhnes.",
                      "“Versuch locker zu bleiben”,sagst du dir immer wieder.",
                      "Das Ungeheuer kriecht hungrig auf dich zu und hinterlässt eine Spur aus Sabber auf seinem Weg.",
                      "Du gerätst in Panik, du hast seine Größe unterschätzt. Vielleicht war das nicht die klügste Entscheidung. Aber was wirst du tun?");

            SetButtonsText("Panisch versuchen, um das Monster herum zu rennen!", "Versuchen, eine erwachsene Konversation zu führen");

            previous = Previous.TiefseegrotteVorbeimogeln;
        }

        public void TiefseegrotteVorbeimogeldTod()
        {
            SetzeHintergrundBild("you_died_lol.png");

            WriteText("Kreischend und mit wild schlackernden Armen rennst du auf das Ungeheuer zu. Das Ungetüm ist eingeschüchtert und wirkt ängstlich.",
                      "Wieso schreist du so laut?! Es zieht seinen Kopf ein und winselt um Gnade, was du aber aufgrund der Panik nicht wahrnimmst.",
                      "Du läufst in Schlangenlinien um das Ungeheuer, doch rutscht anmutig auf der Sabberspur aus.",
                      "Du stößt dir den Kopf und alles wird schwarz.");

            SpielerTod();
        }

        public void TiefseegrotteKonversation()
        {
            EingabefeldNutzen();

            List<string> text = new List<string>()
            {
                "Du atmest tief durch und trittst vor das Ungeheuer. Deine Knie sind weich, doch du stehst erhobenen Hauptes und fragst das Monster nach dem Grund seines Zorns.",
                "Bittere, riesige Tränen kullern an den scharfen Fangzähnen des Ungeheuers vorbei. Es gibt unverständliche Grunzlaute von sich und versucht, dir etwas mitzuteilen.",
                "Aber was kann das nur sein? Du beschließt, konsequent darauf zu antworten und sagst:…",
                "(Gib die die Zahl der Antwort in das Textfeld ein. Mögliche Antworten:",
                "(1) Hör auf zu flennen.",
                "(2) Mir hat auch mal jemand das Herz gebrochen.",
                "(3) Ein paar Kilogramm weniger könntest du schon vertragen",
                "(4) Hör mal, ich habe wirklich keine Zeit dafür."
            };

            if (AktuellerHeld.Klasse.KlassenTyp == KlassenTyp.Magier)
            {
                text.Add("(5) I SHALL PASS!)");
            }
            else
            {
                text[text.Count - 1] += ")";
            }

            WriteText(text.ToArray());

            //BEI 1 UND 3 SOLL DER SPIELER STERBEN-> TiefseegrotteFalscheAntwort
            //BEI 2,4 UND 5 SOLL DER SPIELER ITEM ,,EIER" ERHALTEN-> TiefseegrotteRichtigeAntwort

            previous = Previous.TiefseegrotteKonversation;
        }

        public void TiefseegrotteFalscheAntwort()
        {
            //BEI 1 UND 3 SOLL DER SPIELER STERBEN

            SetzeHintergrundBild("you_died_lol.png");
            WriteText("Das Ungeheuer wird wütend und schlägt wild um sich.Du hättest seine Gefühle nicht verletzen sollen.",
                      "So ein Mist aber auch.");

            SpielerTod();
        }

        public void TiefseegrotteRichtigeAntwort()
        {
            //BEI 2,4,5 GIBT ES DAS ITEM EIER UND ES GEHT WEITER

            AktuellerHeld.FuegeItemHinzu(new Item("Ei", GetBild("ei.png")));

            WriteText("Das Ungeheuer streckt seine Zunge raus und überreicht dir eine Packung Eier(ITEM).",
                      "Es tritt zur Seite und salutiert, während du stolz, aber auch ziemlich verwundert zum Ausgang der Grotte schreitest.");

            SetButtonsText("Weiter");

            previous = Previous.TiefseegrotteRichtigeAntwort;
        }

        public void KaffeBohnenplantage()
        {
            SetzeHintergrundBild("kaffeebohnenplantage.jpg");
            WriteText("Du verabschiedest dich und schlenderst ganz gemütlich über die Kaffeebohnenplantage.",
                "Du siehst einen Baum, in dessen Schatten du erstmal eine kleine Pause einlegst.",
                "Abenteuer sind schließlich anstrengend.",
                "Im Halbschlaf kommst du ins Grübeln: Ist dir Macht wirklich so wichtig? ");

            SetButtonsText("Ja klar. Und ich liebe Kürbisse! ", "Was will ich denn mit Macht, wenn ich auch reich sein könnte?");

            previous = Previous.KaffeBohnenplantage;
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
                SetButtonsText("Um Gnade flehen ", "Kämpfen!", "Mit Eiern werfen ");
            }
            else
            {
                SetButtonsText("Um Gnade flehen ", "Kämpfen!");
            }

            previous = Previous.MachtWichtig;
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
            SetButtonsText("Weiter");

            previous = Previous.Geschenkeabweisen;
        }

        public void KaffeBohnenplantageGeschenkeAnnehmen()
        {
            SetzeHintergrundBild("kaffeebohnenplantage.jpg");
            WriteText("Nachdem du die gütigen Geschenke empfängst und auf direktem Weg zum Kürbispalast bist, strecken dir auch schon die ersten ihre leeren Hände entgegen.  ",
                "Das sind schließlich Händler, die vom Kürbishandel leben.  ",
                "Wie? ",
                "Das wusstest du nicht? ",
                "Wie willst du dann ihr König werden?! Du beschließt....  ");
            SetButtonsText("...das Weite zu suchen!", "...dich deiner Verantwortung zu stellen.");

            previous = Previous.GeschenkeAnnehmen;
        }
         public void KaffeBohnenplantageVerantwortungStellen()
         {
            SetzeHintergrundBild("kaffeebohnenplantage.jpg");
            WriteText("Du stellst dich deinem Schicksal und erklärst den Bewohner deine missliche Lage.",
                "Nun wirst du bis ans Ende aller Tage deine Schulden auf den Kürbisackern von Kürbistan arbeiten.",
                "Du wirst nicht reich und auch nicht mächtig, jedoch gibt es von nun an jeden Morgen Kürbisbrot.",
                "Vielleicht gewöhnst du dich eines Tages daran.",
                "Außer...");
            SetButtonsText("...das Weite zu suchen!", "...dich deiner Verantwortung zu stellen.");
            bool muenze = AktuellerHeld.HatItem("Münze");
            if (muenze)
            {
               SetButtonsText("...du verwendest mehr Salz", "...du gönnst dir mal ein richtiges Steak.  ");
            }
            else
            {
               SetButtonsText("...du verwendest mehr Salz ");
            }
            previous = Previous.KaffeBohnenplantageVerantwortungStellen;
         }
      public void KaffeBohnenplantageSteak()
      {
         SetzeHintergrundBild("food_truck_deathscreen.png");
         WriteText("Außerhalb der Stadt steht ein Food-Truck Food-to-Goat. ",
             "Dein alter Kumpel Jürgen bedient dich heute. ",
             "Er empfiehlt dir direkt ein Stück seines besten Fantasy-Ziegenfleisches, welches er für dich sofort auf den Grill schmeißt.  ",
             "Dieses Steak ist mehr als du dir jemals erträumen konntest.",
             "Die saftige Konsistenz, der ausfüllende Duft, der dir in die Nase steigt, die goldig braune Farbe dieses anmutigen Stückes köstlichen Fleisches.",
             "Jürgen gefällt dein Sinn für Geschmack. Er bietet dir einen Arbeitsplatz in seinem Food-truck an, den du selbstverständlich gerne annimmst.",
             " Mit brutzelndem Fleischduft in der Nase macht das Schulden abarbeiten viel mehr Spaß. ",
             "Schönes Leben noch. ");
         SetButtonsText();
      }
      public void KaffeBohnenplantageSalzverwenden()
      {
         SetzeHintergrundBild("kaffeebohnenplantage.jpg");
            WriteText("Mmmhhhhh, das schmeckt. Gar nicht übel.",
                "Reicht dir eine Prise Salz für den Rest deines Lebens?",
                "Nein?!  ",
                "Das muss es aber.",
                "Schönes Leben noch.");
            SetButtonsText();
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
               SetButtonsText("...mehr Kürbisse ", "...Eier");
            }
            else
            {
               SetButtonsText("...mehr Kürbisse ");
            }

         previous = Previous.WeiteSuchen;
         }

        public void KuerberlinGnadeFlehen()
        {
            SetzePersonenBild("kobold_punks.png");

            WriteText("Du bittest um Verzeihung und versuchst, die finsteren Gestalten durch Selbstmitleid von ihren Machenschaften abzubringen.",
                      "“Kannste knicken”, schnauft der Anführer der Kobold-Punks. Der Kampf beginnt.");

            SetButtonsText("Weiter");

            previous = Previous.KuerberlinGnadeFlehen;
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
         SetButtonsText();
         previous = Previous.KaffeBohnenPlantagemehrKuerbisse;
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
         SetButtonsText();
         previous = Previous.KaffeBohnenPlantageWollenEier;
      }


      public void KuerberlinEier()
        {
            SetzePersonenBild("kobold_punks.png");

            WriteText("Du zückst die Packung Eier und wirfst drauf los. Noch bevor die Kobold-Punks reagieren können, fliegen ihnen auch schon Eier um die übergroßen Ohren.",
                      "Eier sind ihre größte Schwachstelle. Niemand wusste das, du aber schon. Gut gemacht.");

            SetButtonsText("Weiter");

            AktuellerHeld.EntferneItem("Ei");

            previous = Previous.KuerberlinEier;
        }

        public void KuerberlinKoboldKampf()
        {
            KaempfenKaffeeGegenKobolde();
        }

        public void KuerberlinKampfGewonnen()
        {
            SetzePersonenBild("kobold_punks.png");

            WriteText("Du bist der Sieger, ein Gewinner. Die Kobold-Punks ziehen mit geknickten Mienen von dannen.",
                      "Sie konnten dir nichts entgegensetzen und denken nun über eine Umschulung nach.");

            SetButtonsText("Weiter");

            previous = Previous.KuerberlinKampfGewonnen;
        }

        public void KuerberlinKampfVerloren()
        {
            SetzeHintergrundBild("blaues_auge_deathscreen.png");

            WriteText("Du wurdest aufgemischt. Lass den Kopf nicht hängen. Selbstverständlich kannst du es nochmal versuchen. Am Anfang des Spiels.");

            SetButtonsText("Weiter");

            previous = Previous.KuerberlinKampfVerloren;
            //Spieler stirbt
        }

        public void KuerbistanAnkunft()
        {
            SetzeHintergrundBild("kuerberlin_mit_kuerbispalast.png");

            WriteText("Das Königreich Kürbistan liegt vor dir. Kürbisfelder soweit das Auge reicht.",
                      "Die örtlichen Bewohner empfangen dich wehenden Flaggen und reichen dir Kürbisse in allen Farben und Formen.",
                      "Die Menschen strecken dir mehr Kürbisse entgegen als du jemals tragen könntest. Weiß ja schließlich niemand, dass du im Grunde gar keine Kürbisse magst.",
                      "Aber du nimmst die gütigen Geschenke entgegen. Oder etwa nicht?");

            SetButtonsText("Geschenke annehmen", "Geschenke abweisen");

            previous = Previous.KuerbistanAnkunft;
        }

        public void KuerbistanGeschenkeAnnehmen()
        {
            SetzeHintergrundBild("kuerberlin_mit_kuerbispalast.png");

            WriteText("Nachdem du die gütigen Geschenke empfängst und auf direktem Weg zum Kürbispalast bist, strecken dir auch schon die ersten ihre leeren Hände entgegen.",
                      "Das sind schließlich Händler, die vom Kürbishandel leben.",
                      "Wie? Das wusstest du nicht? Wie willst du dann ihr König werden?! Du beschließt.... ");

            SetButtonsText("...das Weite zu suchen!", "… dich deiner Verantwortung zu stellen.");

            previous = Previous.KuerbistanGeschenkeAnnehmen;
        }


        public void KuerbistanGeschenkeAblehnen()
        {
            SetzeHintergrundBild("kuerberlin_mit_kuerbispalast.png");

            WriteText("Wie undankbar. Die gütigen Bewohner des Königreichs wollen dir ihr letztes Hab und Kürbistum anbieten und du lehnst ab. Schäm dich.",
                      "Den Bürgern gefällt deine Einstellung ganz und gar nicht. Sie schmeißen dich umgehend aus der Stadt und sagen dir, dass du nie wieder ihr Land betreten sollst.",
                      "Wie gut, dass anscheinend alle hier an Amnesie leiden.");

            SetButtonsText("Weiter");

            previous = Previous.KuerbistanGeschenkeAblehnen;
        }

        public void KaffeBohnenplantageMitEiernWerfen()
        {
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
            SetButtonsText("Geschenke abweisen.", "Geschenke annehmen.");

            previous = Previous.MitEierWerfen;
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
            StarteKampf(this, Gegner.GetByTyp(GegnerTyp.Kobolde));
            previous = Previous.KaempfenKaffeeKobolde;
        }

        public void KaempfenKoboldanfuehrer()
        {
            StarteKampf(this, Gegner.GetByTyp(GegnerTyp.KoboldAnfuehrer));
            previous = Previous.KaempfenKoboldanfuehrer;
        }
    }
}

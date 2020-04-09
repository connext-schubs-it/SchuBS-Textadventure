using SchuBS_Textadventure.Objects;

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
            /*Hier fehlt noch die Verbindung zum Dorf Kürberlin*/
        }

        public void TiefseegrotteBegegnungUngeheuer()
        {
            SetzePersonenBild("tiefsee_ungeheuer.png");

            WriteText("Du schwimmst ein ganzes Stück immer geradeaus.",
                      "Es wird immer heller und als du denkst, du hat die Grotte schon fast verlassen, steht dir plötzlich ein Ungeheuer im Weg.",
                      "Es sieht sehr groß und mächtig aus.",
                      "Möchtest du gegen das Ungeheuer kämpfen oder versuchen dich an dem Ungeheuer vorbei zu mogeln?");

            SetButtonsText("Kämpfen!", "Vorbeimogeln");
            previous = Previous.TiefseegrotteBegegnungUngeheuer;
        }

        public void TiefseegrotteUngeheuerKaempfen()
        {
            WriteText($"Ungeheuer fordert dich zum Kampf!", "Was wirst du tun?!");
            StarteKampf(this, Gegner.GetByTyp(GegnerListe, Gegner.Typ.Ungeheuer));

            previous = Previous.TiefseegrotteUngeheuerKaempfen;
        }

        public void TiefseegrotteUngeheuerBesiegt()
        {
            SetzePersonenBild();
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

            //HIER WIRD GESTORBEN, MOOOOOOIS-> Muss auch in Story.cs angegeben werden
        }

        public void TiefseegrotteKonversation()
        {
            //Button2
            SetzeHintergrundBild("tiefsee_ungeheuer.png");

            WriteText("Du atmest tief durch und trittst vor das Ungeheuer. Deine Knie sind weich, doch du stehst erhobenen Hauptes und fragst das Monster nach dem Grund seines Zorns.",
                      "Bittere, riesige Tränen kullern an den scharfen Fangzähnen des Ungeheuers vorbei. Es gibt unverständliche Grunzlaute von sich und versucht, dir etwas mitzuteilen.",
                      "Aber was kann das nur sein? Du beschließt, konsequent darauf zu antworten und sagst:…",
                      "(Gib deine Antwort in das Textfeld ein. Mögliche Antworten:",
                      "(1) Hör auf zu flennen.",
                      "(2) Mir hat auch mal jemand das Herz gebrochen.",
                      "(3) Ein paar Kilogramm weniger könntest du schon vertragen",
                      "(4) Hör mal, ich habe wirklich keine Zeit dafür.",
                      //IF-ABFRAGE,,WENN MAGIER, DANN....// 
                      "(5) I SHALL PASS!)");

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

            previous = Previous.TiefseegrotteFalscheAntwort;
            //Spieler stirbt
        }

        public void TiefseegrotteRichtigeAntwort()
        {
            //BEI 2,4,5 GIBT ES DAS ITEM EIER UND ES GEHT WEITER

            SetzeHintergrundBild("you_died_lol.png");

            WriteText("Das Ungeheuer streckt seine Zunge raus und überreicht dir eine Packung Eier(ITEM).",
                      "Es tritt zur Seite und salutiert, während du stolz, aber auch ziemlich verwundert zum Ausgang der Grotte schreitest.");

            previous = Previous.TiefseegrotteRichtigeAntwort;
        }

        public void KaffeBohnenplantage()
        {
            SetzeHintergrundBild("kaffeebohnenplantage.jpg");
            WriteText("Du verabschiedest dich von Thoron und schlenderst ganz gemütlich über die Kaffeebohnenplantage.",
                "Du siehst einen Baum, in dessen Schatten du erstmal eine kleine Pause einlegst.",
                "Abenteuer sind schließlich anstrengend.",
                "Im Halbschlaf kommst du ins Grübeln: Ist dir Macht wirklich so wichtig? ");
            SetButtonsText("Ja klar. Und ich liebe Kürbisse! ", "Was will ich denn mit Macht, wenn ich auch reich sein könnte");
            previous = Previous.KaffeBohnenplantage;
        }

        public void istMachtWichtig()
        {
            SetzeHintergrundBild("kaffeebohnenplantage.jpg");
            WriteText("Der Weg führt dich vorbei an einem Kürbisacker zu einem kleinen Dorf … ",
                "Dir bietet sich ein grandioser Ausblick. Das Dorf Kürberlin liegt vor dir.",
                "Abenteuerlust steigt in dir auf als du das Dorf betrittst, doch du spürst, dass etwas anders ist. ",
                "Unheil liegt in der Luft.",
                "Kein einziger Dorfbewohner ist zu sehen und zu allem Übel kommen drei sehr furchteinflößende Kobold-Punks auf dich zu. ",
                "“Wir sind die Kobold-Punks, wir sind hier um die Menschen aufzumischen, und du bist der nächste.” ",
                "Was wirst du tun? ");
            SetButtonsText("Um Gnade flehen ", "Mit Eiern werfen ", "Kämpfen!");
            previous = Previous.MachtWichtig;
        }

        public void MitEiernWerfen()
        {
            bool eier = AktuellerHeld.HatItem("Ei");

        }

        public void GnadeFlehen()
        {
            SetzeHintergrundBild("tiefsee_ungeheuer.png");
            KaempfenKaffe();
            previous = Previous.GnafeFlehen;
        }

        public void KaempfenKaffe()
        {
            SetzeHintergrundBild("tiefsee_ungeheuer.png");
            Gegner ungeheuer = new Gegner
            {
                Lebenspunkte = 100,
                Name = "Ungeheuer",
                Staerke = 1,
                Verteidigung = 0
            };
            StarteKampf(this, ungeheuer);
            WriteText("Du bittest um Verzeihung und versuchst, die finsteren Gestalten durch Selbstmitleid von ihren Machenschaften abzubringen.",
                "“Kannste knicken”, schnauft der Anführer der Kobold-Punks.",
                "Der Kampf beginnt ");
        }
    }
}

using System.Windows;
using System.Windows.Input;
using SchuBS_IT_2020;
using SchuBS_Textadventure.Objects;

namespace SchuBS_Textadventure
{
    public partial class Textadventure
    {
        public void MachtStart()
        {
            SetzeHintergrundBild("landschaft_1.jpg");
            AktuellerHeld.Inventar.Add(new Item("Test", GetBild("ei.png")));
            AktuellerHeld.Inventar.Add(new Item("Test2", null));
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
            AktuellerHeld.Inventar.Add(new Item("Test", GetBild("ei.png")));
            AktuellerHeld.Inventar.Add(new Item("Test2", null));
            WriteText("“Bist du dir da sicher? Ich habe gehört in der Tiefseegrotte soll es seltsame Wesen geben.”");

            SetButtonsText("Ich habe doch keine Angst vor seltsamen Wesen einer Tiefseegrotte! Ab zum See!", "Dann gehe ich doch lieber über die Kaffeebohnenplantage!");
            previous = Previous.TiefseegrotteErfragt;
        }

        public void TiefseegrotteSchwimmen()
        {
            SetzeHintergrundBild("tiefseegrotte.jpg");
            AktuellerHeld.Inventar.Add(new Item("Test", GetBild("ei.png")));
            AktuellerHeld.Inventar.Add(new Item("Test2", null));
            WriteText("Du schwimmst angespannt und höchst aufmerksam durch die Tiefseegrotte. Hinter einer Ecke taucht eine Abzweigung auf.",
                      "Der Linke Weg ist tief dunkel und du kannst nicht erkennen, wie es dort weiter gehen könnte.Aber geradeaus wird es heller.",
                      "Dein Kopf sagt dir: Schwimm geradeaus weiter.Aber wie entscheidet dein Bauch?");

            SetButtonsText("Den linken Weg nehmen!", "Geradeaus weiterschwimmen!");
            previous = Previous.TiefseegrotteGeschwommen;
        }

        public void TiefseegrotteLinksSchwimmen()
        {
            SetzeHintergrundBild("tiefseegrotte.jpg");
            AktuellerHeld.Inventar.Add(new Item("Test", GetBild("ei.png")));
            AktuellerHeld.Inventar.Add(new Item("Test2", null));

            WriteText("Todesmutig und entgegen deines Kopfes biegst du links ab. Du musst immer weiter in die Tiefe tauchen um vorwärts zu kommen und es wird immer dunkler.",
                      "Doch plötzlich spürst du einen Strudel. Du denkst jetzt ist alles vorbei.",
                      "Doch entgegen deiner Erwartungen bringt dich der Strudel an die Wasseroberfläche. Du schaffst es zum Ufer und kletterst an Land.",
                      "Du entdeckst einen Weg.",
                      "Der Weg führt dich vorbei an einem Kürbisacker zu einem kleinen Dorf…");
            /*Hier fehlt noch die Verbindung zum Dorf Kürberlin*/
        }

        public void TiefseegrotteBegegnungUngeheuer()
        {
            SetzeHintergrundBild("tiefsee_ungeheuer.jpg");
            AktuellerHeld.Inventar.Add(new Item("Test", GetBild("ei.png")));
            AktuellerHeld.Inventar.Add(new Item("Test2", null));

            WriteText("Du schwimmst ein ganzes Stück immer geradeaus.",
                      "Es wird immer heller und als du denkst, du hat die Grotte schon fast verlassen, steht dir plötzlich ein Ungeheuer im Weg.",
                      "Es sieht sehr groß und mächtig aus.",
                      "Möchtest du gegen das Ungeheuer kämpfen oder versuchen dich an dem Ungeheuer vorbei zu mogeln?");

            SetButtonsText("Kämpfen!","Vorbeimogeln");
            previous = Previous.TiefseegrotteUngeheuerBegegnet;
            /*Kämpfen*/
        }

        public void TiefseegrotteVorbeimogeln()
        {
            SetzeHintergrundBild("tiefsee_ungeheuer.jpg");
            AktuellerHeld.Inventar.Add(new Item("Test", GetBild("ei.png")));
            AktuellerHeld.Inventar.Add(new Item("Test2", null));

            WriteText("Du versteckst dich hinter einem Felsvorsprung und imitierst das Gackern eines Huhnes.",
                      "“Versuch locker zu bleiben”,sagst du dir immer wieder.",
                      "");
        }


      public void KaffeBohnenplantage()
      {
         SetzeHintergrundBild("landschaft_1.jpg");
         WriteText("Du verabschiedest dich von Thoron und schlenderst ganz gemütlich über die Kaffeebohnenplantage.",
             "Du siehst einen Baum, in dessen Schatten du erstmal eine kleine Pause einlegst.",
             "Abenteuer sind schließlich anstrengend.",
             "Im Halbschlaf kommst du ins Grübeln: Ist dir Macht wirklich so wichtig? ");
         SetButtonsText("Ja klar. Und ich liebe Kürbisse! ", "Was will ich denn mit Macht, wenn ich auch reich sein könnte");
         previous = Previous.KaffeBohnenplantage;
      }

      public void istMachtWichtig()
      {
         SetzeHintergrundBild("landschaft_1.jpg");
         WriteText("Der Weg führt dich vorbei an einem Kürbisacker zu einem kleinen Dorf … ",
             "Dir bietet sich ein grandioser Ausblick. Das Dorf Kürberlin liegt vor dir.",
             "Abenteuerlust steigt in dir auf als du das Dorf betrittst, doch du spürst, dass etwas anders ist. ",
             "Unheil liegt in der Luft.",
             "Kein einziger Dorfbewohner ist zu sehen und zu allem Übel kommen drei sehr furchteinflößende Kobold-Punks auf dich zu. ",
             "“Wir sind die Kobold-Punks, wir sind hier um die Menschen aufzumischen, und du bist der nächste.” ",
             "Was wirst du tun? ");
         SetButtonsText("Um Gnade flehen ", "Mit Eiern werfen ","Kämpfen!");
         previous = Previous.MachtWichtig;
      }
   }

   
}

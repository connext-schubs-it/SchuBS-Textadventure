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
            WriteText("Schön zu hören.",
                "An der Grenze dieses Landes existiert ein Königreich, welches ausschließlich von Kürbisbauern bevölkert wird.",
                "Es ist ein sehr armes Land, aber die Ernte ist reich und die Menschen gütig. Und die Halloweenpartys sind der Hammer.",
                "Dein Kürbiskopf hätte sicherlich gute Chancen auf den Königstitel.",
                "Um zum Königreich Kürbistan zu gelangen, könntest du über die Kaffeebohnenplantage oder über die Tiefseegrotte reisen.",
                "Wie entscheidest du dich?");

            SetButtonsText("Kaffeebohnenplantage", "Tiefseegrotte");
            previous = Previous.MachtGestartet;
        }

      public void KaffeBohnenplantage()
      {
         SetzeHintergrundBild("landschaft_1.jpg");
         AktuellerHeld.Inventar.Add(new Item("Test", GetBild("ei.png")));
         AktuellerHeld.Inventar.Add(new Item("Test2", null));
         WriteText("Du verabschiedest dich von Thoron und schlenderst ganz gemütlich über die Kaffeebohnenplantage.",
             "Du siehst einen Baum, in dessen Schatten du erstmal eine kleine Pause einlegst.",
             "Abenteuer sind schließlich anstrengend.",
             "Im Halbschlaf kommst du ins Grübeln: Ist dir Macht wirklich so wichtig? ");
         SetButtonsText("Ja klar. Und ich liebe Kürbisse! ", "Was will ich denn mit Macht, wenn ich auch reich sein könnte");
         previous = Previous.MachtGestartet;
      }
    }
}

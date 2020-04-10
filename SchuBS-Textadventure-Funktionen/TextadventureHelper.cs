using SchuBS_Textadventure.Dialogs;
using SchuBS_Textadventure.MyControls;

using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;

namespace SchuBS_Textadventure
{
    public static class TextadventureHelper
    {
        /// <summary>
        /// Kann zum zufälligen erstellen von Zahlen verwendet werden.
        /// <list type="table">
        /// <item><description>Zwischen 0 und 10: <c>Zufallsgenerator.Next(10)</c></description></item>
        /// <item><description>Zwischen 5 und 10: <c>Zufallsgenerator.Next(5, 10)</c></description></item>
        /// </list>
        /// </summary>
        public static readonly Random Zufallsgenerator = new Random();

        /// <summary>
        /// Die Aktionsknöpfe der Oberfläche.
        /// </summary>
        public static Button[] ButtonsAktionen { get; set; }

        public const string TextVariableDelimiter = "##";

        public static Image ImageHintergrund;
        public static Image ImagePerson;
        public static SlowTextBox TextBoxHauptText;
        public static TextBox TextBoxEingabe;
        public static UniformGrid UniformGridButtons;

        public static Func<string[], string> GetText;

        public static StringBuilder VerlaufText = new StringBuilder();

        /// <summary>
        /// Zeigt ein Popup, in dem der ganze bisher Gezeigte Text gezeigt wird.
        /// </summary>
        public static void ZeigeVerlaufFenster() => new VerlaufFenster(VerlaufText.ToString()).ShowDialog();

        /// <summary>
        /// Setzt den Text der Aktions-Knöpfe. Nicht genutze Knöpfe werden ausgeblendet.
        /// <code>SetButtonsText("Links", "Rechts");</code>
        /// </summary>
        /// <param name="text"></param>
        public static void SetButtonsText(params string[] text)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i < text.Length)
                {
                    SetButtonText(i, text[i]);
                }
                else
                {
                    SetButtonText(i, null);
                }
            }

            if (TextBoxEingabe.IsEnabled)
            {
                ButtonsAktionen[0].Focus();
                TextBoxEingabe.IsEnabled = false;
            }

            UniformGridButtons.Columns = ButtonsAktionen.Count(button => button.Visibility == Visibility.Visible);

            void SetButtonText(int buttonIndex, string buttonText)
            {
                ButtonsAktionen[buttonIndex].Content = buttonText;
                ButtonsAktionen[buttonIndex].Visibility = string.IsNullOrEmpty(buttonText) ? Visibility.Collapsed : Visibility.Visible;
                ButtonsAktionen[buttonIndex].IsEnabled = !string.IsNullOrEmpty(buttonText);
            }
        }

        /// <summary>
        /// Schreibt die Zeilen in die ausgabe Textbox. Nach jeder Zeile wird ein Zeilenumbruch eingefügt.<br/>
        /// Im Text enthaltene Variablen (mit <see cref="TextVariableDelimiter"/> umschlossen) werden durch die entsprechenden
        /// Werte ersetzt.<br/>
        /// Mögliche Werte sind:
        /// <list type="bullet">
        /// <item><description>SpielerName</description></item>
        /// <item><description>SpielerKlasse</description></item>
        /// <item><description>Weltname</description></item>
        /// </list>
        /// <code>WriteText("Hallo", "Wie gehts es dir?");</code>
        /// </summary>
        /// <param name="zeilen">Die Zeilen, die in die Ausgabe geschreiben werden sollen.</param>
        public static void WriteText(params string[] zeilen)
        {
            string text = GetText(zeilen);
            VerlaufText.AppendLine(text);
            TextBoxHauptText.SetText(text);
        }

        /// <summary>
        /// Fügt die Zeilen zur ausgabe Textbox hinzu. Nach jeder Zeile wird ein Zeilenumbruch eingefügt.<br/>
        /// Im Text enthaltene Variablen (mit <see cref="TextVariableDelimiter"/> umschlossen) werden durch die entsprechenden
        /// Werte ersetzt.<br/>
        /// Mögliche Werte sind:
        /// <list type="bullet">
        /// <item><description>SpielerName</description></item>
        /// <item><description>SpielerKlasse</description></item>
        /// <item><description>Weltname</description></item>
        /// </list>
        /// <code>AppendText("Hallo", "Wie gehts es dir?");</code>
        /// </summary>
        /// <param name="zeilen">Die Zeilen, die angehangen werden sollen.</param>
        public static void AppendText(params string[] zeilen)
        {
            string text = GetText(zeilen);
            VerlaufText.AppendLine(text);
            TextBoxHauptText.AppendText(text);
        }

        /// <summary>
        /// Ersetzt die <paramref name="textVaraible"/> im <paramref name="text"/> mit dem <paramref name="wert"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="textVaraible"></param>
        /// <param name="wert"></param>
        /// <returns>Der Text, in dem die Variablen ersetzt wurden.</returns>
        public static string ErsetzeVariable(string text, string textVaraible, string wert) =>
            Regex.Replace(text, TextVariableDelimiter + textVaraible + TextVariableDelimiter, wert ?? string.Empty);


        /// <summary>
        /// Bereitet die Oberfläche so vor, dass das Eingabefeld genutzt wird.<br/>
        /// Die Überprüfung der Eingabe findet in VerarbeiteTextEingabe (Eingaben.cs) statt.
        /// </summary>
        public static void EingabefeldNutzen()
        {
            SetButtonsText("Bestätigen");
            ButtonsAktionen[0].IsEnabled = false;
            TextBoxEingabe.IsEnabled = true;
            TextBoxEingabe.Focus();
        }

        /// <summary>
        /// Setzt das <paramref name="bildName"/> als Hintergrundbild.
        /// </summary>
        /// <param name="bildName">Der Name des Bildes.</param>
        public static void SetzeHintergrundBild(string bildName = null) => ImageHintergrund.Source = GetBild(bildName);

        /// <summary>
        /// Setzt das <paramref name="bildName"/> als Personenbild.
        /// </summary>
        /// <param name="bildName">Der Name des Bildes.</param>
        public static void SetzePersonenBild(string bildName = null) => ImagePerson.Source = GetBild(bildName);

        /// <summary>
        /// Holt ein Bild aus dem Resources-Ordner.<br/>
        /// Wenn hier nach Programmstart eine Fehlermeldung auftauch, ist entweder das Bild nicht vorhanden
        /// oder der der Name ist falsch geschrieben.
        /// </summary>
        /// <param name="name">Der Name des Bildes mit Dateiendung.</param>
        /// <returns></returns>
        public static BitmapImage GetBild(string name = null) => string.IsNullOrWhiteSpace(name) ? null : new BitmapImage(new Uri("pack://application:,,,/Resources/" + name));

        /// <summary>
        /// Versucht den <paramref name="text"/> in einen <see cref="int"/> umzuwandlen und gibt diesen zurück.
        /// Ist keine Umwandlung möglich wird <c>-1</c> zurückgegeben.
        /// </summary>
        /// <param name="text">Der text, der zu einem <see cref="int"/> umgewandelt werden soll.</param>
        /// <returns>Den <paramref name="text"/> als <see cref="int"/>.</returns>
        public static int TextAlsZahl(string text)
        {
            if (int.TryParse(text, out int eingabeZahl))
            {
                return eingabeZahl;
            }
            else
            {
                return -1;
            }
        }
    }
}

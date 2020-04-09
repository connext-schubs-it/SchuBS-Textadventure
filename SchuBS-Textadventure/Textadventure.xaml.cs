using SchuBS_Textadventure.Dialogs;
using SchuBS_Textadventure.Helpers;
using SchuBS_Textadventure.MyControls;
using SchuBS_Textadventure.Objects;

using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SchuBS_Textadventure
{
    /// <summary>
    /// Interaktionslogik für Textadventure.xaml
    /// </summary>
    public partial class Textadventure : Window
    {
        #region Globale Variablen

        public Random Zufallsgenerator = new Random();

        public const string TextVariableDelimiter = "##";

        public const string Weltname = "Cucurbita";

        public Button[] ButtonsAktionen;
        public SlowTextBox AusgabeBox;

        #endregion

        #region Spiel Variablen

        public Spieler AktuellerHeld { get; } = new Spieler();

        public StringBuilder VerlaufText = new StringBuilder();

        #endregion

        public Textadventure()
        {
            InitializeComponent();
            ButtonsAktionen = new Button[]
            {
                Button1,
                Button2,
                Button3,
            };
            AusgabeBox = TextBoxHauptText;
            Start();
        }

        #region Funktionen

        /// <summary>
        /// Setzt den Text der Aktions-Knöpfe.
        /// <code>SetButtonsText("Links", "Rechts");</code>
        /// </summary>
        /// <param name="text"></param>
        public void SetButtonsText(params string[] text)
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
        public void WriteText(params string[] zeilen)
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
        public void AppendText(params string[] zeilen)
        {
            string text = GetText(zeilen);
            VerlaufText.AppendLine(text);
            TextBoxHauptText.AppendText(text);
        }

        private string GetText(params string[] zeilen)
        {
            string text = string.Join("\n", zeilen);

            Escape("SpielerName", AktuellerHeld.Name);
            Escape("SpielerKlasse", AktuellerHeld.Klasse.ToString());
            Escape("Weltname", Weltname);

            return text;

            string Escape(string textVaraible, string wert) =>
                text = Regex.Replace(text, TextVariableDelimiter + textVaraible + TextVariableDelimiter, wert ?? string.Empty);
        }

        private void ButtonVerlauf_Click(object sender, RoutedEventArgs e)
        {
            new VerlaufFenster(VerlaufText.ToString()).ShowDialog();
        }

        /// <summary>
        /// Setzt das <paramref name="bildName"/> als Hintergrundbild.
        /// </summary>
        /// <param name="bildName">Der Name des Bildes.</param>
        public void SetzeHintergrundBild(string bildName = null) => ImageHintergrund.Source = GetBild(bildName);

        /// <summary>
        /// Setzt das <paramref name="bildName"/> als Personenbild.
        /// </summary>
        /// <param name="bildName">Der Name des Bildes.</param>
        public void SetzePersonenBild(string bildName = null) => ImagePerson.Source = GetBild(bildName);

        /// <summary>
        /// Holt ein Bild aus dem Resources-Ordner.<br/>
        /// Wenn hier nach Programmstart eine Fehlermeldung auftauch, ist entweder das Bild nicht vorhanden
        /// oder der der Name ist falsch geschrieben.
        /// </summary>
        /// <param name="name">Der Name des Bildes mit Dateiendung.</param>
        /// <returns></returns>
        public BitmapImage GetBild(string name = null) => string.IsNullOrWhiteSpace(name) ? null : new BitmapImage(new Uri("pack://application:,,,/Resources/" + name));

        /// <summary>
        /// Bereitet die Oberfläche so vor, dass das Eingabefeld genutzt wird.<br/>
        /// Die Überprüfung der Eingabe findet in <see cref="VerarbeiteTextEingabe"/> (Story.cs) statt.
        /// </summary>
        private void EingabefeldNutzen()
        {
            SetButtonsText("Bestätigen");
            ButtonsAktionen[0].IsEnabled = false;
            TextBoxEingabe.IsEnabled = true;
            TextBoxEingabe.Focus();
        }

        /// <summary>
        /// Startet einen kampf gegen den <paramref name="gegnerTyp"/>.
        /// </summary>
        /// <param name="gegnerTyp">Der Gegner.</param>
        public void StarteKampf(GegnerTyp gegnerTyp) => StarteKampf(Gegner.GetByTyp(gegnerTyp));

        public void StarteKampf(Gegner gegner)
        {
            TextBoxEingabe.Text = "";

            SetzeGegner(gegner);
            Kampf = new Kampf(AktuellerHeld, gegner, null, this);
            Kampf.Aktion();
        }

        public void SetzeGegner(Gegner gegner)
        {
            PersonStats.DataContext = gegner;
            if (gegner != null)
            {
                SetzePersonenBild(gegner.Bild);
                PersonStats.Visibility = Visibility.Visible;
            }
            else
            {
                PersonStats.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Rufe diese Methode auf, nachdem ein Gegner besiegt wurde.
        /// </summary>
        public void EntferneGegner() => SetzeGegner(null);

        /// <summary>
        /// Das Spiel wird beendet und nachdem der Spieler "Neustarten" klickt startet ein neues Spiel.
        /// </summary>
        private void SpielZuende()
        {
            previous = Previous.SpielZuende;
            SetButtonsText("Neustarten");
        }
        #endregion
    }
}

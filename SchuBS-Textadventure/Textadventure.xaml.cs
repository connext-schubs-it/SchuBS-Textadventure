using ModernWpf.Controls;

using SchuBS_Textadventure.Data;
using SchuBS_Textadventure.KampfHelper;
using SchuBS_Textadventure.Objects;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using static SchuBS_Textadventure.TextadventureHelper;

namespace SchuBS_Textadventure
{
    /// <summary>
    /// Interaktionslogik für Textadventure.xaml
    /// </summary>
    public partial class Textadventure : Window
    {
        #region Spiel Variablen
        public const string Weltname = "Cucurbita";

        public Spieler AktuellerHeld { get; } = new();
        #endregion

        #region Initialisierung

        public Textadventure()
        {
            InitializeComponent();
            ButtonsAktionen = new Button[]
            {
                Button1,
                Button2,
                Button3,
            };
            Init(ButtonsAktionen, ImageHintergrund, ImagePerson, TextBoxHauptText, TextBoxEingabe, UniformGridButtons, GetText);

            if (GetStartArgsParameter("textspeed") is string geschwindigkeit)
            {
                double textGeschwindigkeit = TextAlsKommaZahl(geschwindigkeit);
                if (!double.IsNaN(textGeschwindigkeit) && !double.IsInfinity(textGeschwindigkeit))
                    TextBoxHauptText.TextSpeed = (float)textGeschwindigkeit;
            }

            if (GetStartArgsParameter("class") is string klassenName)
            {
                AktuellerHeld.Name = "Held";
                BerufErfragen();
                TextBoxEingabe.Text = klassenName;
                VerarbeiteTextEingabe();
            }
            else
            {
                Start();
            }
        }

        #endregion

        #region Funktionen

        private void ButtonVerlauf_Click(object sender, RoutedEventArgs e)
        {
            ZeigeVerlaufFenster();
        }

        /// <summary>
        /// Wandelt einen <see cref="string"/>[] in einen Text um, der dem Spieler angezeigt werden kann.
        /// </summary>
        /// <param name="zeilen"></param>
        /// <returns></returns>
        private string GetText(params string[] zeilen)
        {
            string text = string.Join("\n", zeilen);

            text = ErsetzeVariable(text, "SpielerName", AktuellerHeld.Name);
            text = ErsetzeVariable(text, "SpielerKlasse", AktuellerHeld.Klasse.ToString());
            text = ErsetzeVariable(text, "Weltname", Weltname);

            return text;
        }

        /// <summary>
        /// Startet einen kampf gegen den <paramref name="gegnerTyp"/>.
        /// </summary>
        /// <param name="gegnerTyp">Der Gegner.</param>
        public void StarteKampf(GegnerTyp gegnerTyp, Action continueWin, Action tot = null) => StarteKampf(Gegner.GetByTyp(gegnerTyp), continueWin, tot);

        public void StarteKampf(Gegner gegner, Action continueWin, Action tot = null)
        {
            TextBoxEingabe.Text = "";

            SetzeGegner(gegner);
            Kampf = new Kampf(AktuellerHeld, gegner, continueWin, tot);

            if (!Werte.Instance.HatKampfTutorialGesehen)
            {
                new ContentDialog()
                {
                    Title = "Kampf - Tutotrial",
                    Content = string.Join("\n", "Du hast das erste Mal einen Kampf betreten.",
                                                "Klicke auf „Angriff“ um den Gegner normal anzugreifen.",
                                                "Klicke auf „Magie“ um deine Zauberkünste zu beweisen, wenn du denn welche beherrscht.",
                                                "Wähle ein Item aus und klicke auf „Item benutzen“ um es zu benutzen, oder doppelklicke das Item.",
                                                "",
                                                "Manche Items haben einen speziellen Effekt im Kampf. Probiere es aus!"),
                    PrimaryButtonText = "Ok"
                }.ShowAsync();

                Werte.Instance.HatKampfTutorialGesehen = true;
                Werte.Save();
            }

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
                SetzePersonenBild();
                PersonStats.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Rufe diese Methode auf, nachdem ein Gegner besiegt wurde.
        /// </summary>
        public void EntferneGegner() => SetzeGegner(null);

        /// <summary>
        /// Bereitet die Oberfläche so vor, dass das Eingabefeld genutzt wird.<br/>
        /// Die Überprüfung der Eingabe findet in VerarbeiteTextEingabe (Eingaben.cs) statt.
        /// </summary>
        public void EingabefeldNutzen(Func<bool> verarbeiteTextEingabe)
        {
            Actions = new AdventureAction[]
            {
                ("Bestätigen", verarbeiteTextEingabe)
            };
            SetButtonsTextOhneVerlauf(Actions.Select(item => item.Text).ToArray());

            ButtonsAktionen[0].IsEnabled = false;
            TextBoxEingabe.IsEnabled = true;
            TextBoxEingabe.Focus();
        }

        /// <summary>
        /// Das Spiel wird beendet und nachdem der Spieler "Neustarten" klickt startet ein neues Spiel.
        /// </summary>
        private void SpielZuende()
        {
            SetActions(("Neustarten", () =>
            {
                new Textadventure().Show();
                Close();
            }));
        }
        #endregion
    }
}

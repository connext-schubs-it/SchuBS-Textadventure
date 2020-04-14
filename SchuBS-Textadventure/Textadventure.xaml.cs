using SchuBS_Textadventure.KampfHelper;
using SchuBS_Textadventure.Objects;

using System.Collections.Generic;
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
        #region Globale Variablen

        public const string Weltname = "Cucurbita";

        public Button[] ButtonsAktionen { get; set; }

        #endregion

        #region Spiel Variablen

        public Spieler AktuellerHeld { get; } = new Spieler();

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
            TextadventureHelper.ButtonsAktionen = ButtonsAktionen;
            TextadventureHelper.ImageHintergrund = ImageHintergrund;
            TextadventureHelper.ImagePerson = ImagePerson;
            TextadventureHelper.TextBoxHauptText = TextBoxHauptText;
            TextadventureHelper.TextBoxEingabe = TextBoxEingabe;
            TextadventureHelper.UniformGridButtons = UniformGridButtons;
            TextadventureHelper.GetText = GetText;

            List<string> args = System.Environment.GetCommandLineArgs().ToList();
            int index = args.IndexOf("\\class");
            if (index >= 0 && index + 1 < args.Count)
            {
                AktuellerHeld.Name = "Held";
                BerufErfragen();
                TextBoxEingabe.Text = args[index + 1];
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
        public void StarteKampf(GegnerTyp gegnerTyp) => StarteKampf(Gegner.GetByTyp(gegnerTyp));

        public void StarteKampf(Gegner gegner)
        {
            TextBoxEingabe.Text = "";

            SetzeGegner(gegner);
            Kampf = new Kampf(AktuellerHeld, gegner, this);
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

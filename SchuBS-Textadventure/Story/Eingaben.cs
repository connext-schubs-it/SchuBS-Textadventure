using SchuBS_Textadventure.KampfHelper;
using SchuBS_Textadventure.Objects;
using SchuBS_Textadventure.Objects.Verlauf;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using static SchuBS_Textadventure.TextadventureHelper;

namespace SchuBS_Textadventure
{
    public partial class Textadventure
    {
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (AktuelleAuswahl != null)
                AktuelleAuswahl.GewaehlterAktionsIndex = 0;

            switch (previous)
            {
                case Previous.SpielZuende:
                    new Textadventure().Show();
                    Close();
                    break;

                default:
                    if (TextBoxEingabe.IsEnabled)
                    {
                        VerarbeiteTextEingabe();
                    }
                    else
                    {
                        KaempfeWennMoeglich(buttonIndex: 0);
                    }

                    break;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            AktuelleAuswahl.GewaehlterAktionsIndex = 1;

            switch (previous)
            {
                default:
                    KaempfeWennMoeglich(buttonIndex: 1);
                    break;
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            AktuelleAuswahl.GewaehlterAktionsIndex = 2;

            switch (previous)
            {
                default:
                    KaempfeWennMoeglich(buttonIndex: 2);
                    break;
            }
        }

        /// <summary>
        /// Texteingaben werden ausgewertet
        /// </summary>
        private void VerarbeiteTextEingabe()
        {
            string eingabe = TextBoxEingabe.Text;
            int zahl = TextAlsZahl(eingabe);

            VerlaufText.AppendBlock(new Eingabe(eingabe));

            switch (previous)
            {
               
            }

            TextBoxEingabe.Text = "";
        }

        /// <summary>
        /// Organisiert den Kampfablauf
        /// </summary>
        /// <param name="buttonIndex">Index des Buttons, von dem diese Methode aufgerufen wurde</param>
        private void KaempfeWennMoeglich(int buttonIndex)
        {
            if (Kampf != null)
            {
                if (Kampf.IstZuende)
                {
                    Kampf = null;

                    switch (previous)
                    {
                        // wenn der Kampf gewonnen ist, geht es hier weiter...
                    }
                }
                else
                {
                    switch (buttonIndex)
                    {
                        case 0:
                            Kampf.Button1Angriff();
                            break;
                        case 1:
                            Kampf.Button2Magie();
                            break;
                        case 2:
                            if (ListBoxInventar.SelectedItem is Item selectedItem)
                                Kampf.Button3Item(selectedItem);
                            break;
                    }

                    if (Kampf.IstZuende)
                    {
                        if (AktuellerHeld.Lebenspunkte <= 0)
                        {
                            WriteText("Du bist im Kampf gestorben!");
                            SpielZuende();
                        }
                        else
                        { 
                            SetButtonsText("Kampf beenden");
                        }
                    }
                }
            }
        }

        private void ListBoxInventar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Kampf != null && !Kampf.IstZuende)
            {
                KaempfeWennMoeglich(2);
            }
        }

        private void TextBoxEingabe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                VerarbeiteTextEingabe();
            }
        }

        private void TextBoxEingabe_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxEingabe.IsEnabled)
            {
                ButtonsAktionen[0].IsEnabled = !string.IsNullOrWhiteSpace(TextBoxEingabe.Text);
            }
        }
    }
}

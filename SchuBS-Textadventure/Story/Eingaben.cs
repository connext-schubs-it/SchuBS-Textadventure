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
        private string EingabeText => TextBoxEingabe.Text;

        private int EingabeZahl => TextAlsZahl(EingabeText);

        private Kampf Kampf { get; set; } = null;

        public Button[] ButtonsAktionen { get; }

        private void ButtonEingabe(int buttonIndex)
        {
            if (AktuelleAuswahl != null)
                AktuelleAuswahl.GewaehlterAktionsIndex = buttonIndex;

            if (Actions != null)
            {
                AdventureAction[] actionsBackup = Actions;
                Actions = null;
                if (!actionsBackup[buttonIndex].ContinueWith())
                {
                    // Wenn der Text im Eingabefeld falsch war, Eingabe wiederholen
                    Actions = actionsBackup;
                }
            }
            else
            {
                if (TextBoxEingabe.IsEnabled && buttonIndex == 0)
                {
                    VerarbeiteTextEingabe();
                }
                else
                {
                    KaempfeWennMoeglich(buttonIndex);
                }
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            ButtonEingabe(buttonIndex: 0);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ButtonEingabe(buttonIndex: 1);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            ButtonEingabe(buttonIndex: 2);
        }

        private void KaempfeWennMoeglich(int buttonIndex)
        {
            if (Kampf != null)
            {
                if (Kampf.IstZuende)
                {
                    Kampf?.ContinueWin();
                    Kampf = null;
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
                            if (Kampf.ContinueTot != null)
                            {
                                Kampf.ContinueTot();
                            }
                            else
                            {
                                WriteText("Du bist im Kampf gestorben!");
                            }

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
                KaempfeWennMoeglich(buttonIndex: 2);
            }
        }

        private void TextBoxEingabe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                VerarbeiteTextEingabe();
                e.Handled = true;
            }
        }

        private void TextBoxEingabe_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxEingabe.IsEnabled)
            {
                ButtonsAktionen[0].IsEnabled = !string.IsNullOrWhiteSpace(TextBoxEingabe.Text);
            }
        }

        private void VerarbeiteTextEingabe()
        {
            string eingabe = EingabeText;

            VerlaufText.AppendBlock(new Eingabe(eingabe));

            TextBoxEingabe.Text = "";
        }
    }
}

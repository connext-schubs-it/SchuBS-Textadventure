using SchuBS_Textadventure.KampfHelper;
using SchuBS_Textadventure.Objects;

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
            switch (previous)
            {
                case Previous.Start:
                    NameErfragen();
                    break;

                case Previous.SpielZuende:
                    new Textadventure().Show();
                    Close();
                    break;

                case Previous.BerufungErfragt:
                    BerufErfragen();
                    break;

                case Previous.ZielErfragt:
                    MachtStart();
                    break;

                case Previous.TiefseegrotteErfragt:
                    TiefseegrotteSchwimmen();
                    break;

                case Previous.TiefseegrotteGeschwommen:
                    TiefseegrotteLinksSchwimmen();
                    break;

                case Previous.MachtGestartet:
                    KaffeBohnenplantage();
                    break;

                case Previous.KaffeBohnenplantage:
                    KaffeBohnenplantageIstMachtWichtig();
                    break;

                case Previous.EisKaufen:
                    EisGekauft();
                    break;

                case Previous.EisGekauft:
                case Previous.EisNichtGekauft:
                    Taube();
                    break;

                case Previous.TiefseegrotteLinksSchwimmen:
                    KaffeBohnenplantageIstMachtWichtig();
                    break;

                case Previous.TiefseegrotteBegegnungUngeheuer:
                    TiefseegrotteUngeheuerKaempfen();
                    break;

                case Previous.Taube:
                    DeckungSuchen();
                    break;

                case Previous.DeckungSuchen:
                    WegZurTiefseegrotte();
                    break;

                case Previous.TaubeTreten:
                    BrueckenZoll();
                    break;

                case Previous.MachtWichtig:
                    KaffeBohnenplantageGnadeFlehen();
                    break;

                case Previous.BrueckenZollMuenzeVorhanden:
                    RaetselMauer();
                    break;

                case Previous.BrueckenZollMuenzeNichtVorhanden:
                    WegZurTiefseegrotte();
                    break;

                // rechts
                case Previous.WegZurTiefseegrotte:
                    TiefseegrotteSchwimmen();
                    break;

                case Previous.Windstoß:
                    BrueckenZoll();
                    break;

                case Previous.Weggabelung:
                    Aufzug();
                    break;

                case Previous.TiefseegrotteRichtigeAntwort:
                    KaffeBohnenplantageIstMachtWichtig();
                    break;

                case Previous.IstMachtWichtig:
                    KuerberlinGnadeFlehen();
                    break;

                case Previous.KuerberlinGnadeFlehen:
                case Previous.KuerberlinEier:
                    KuerberlinKoboldKampf();
                    break;

                case Previous.Fußweg:
                case Previous.Aufzug:
                    JoshkaBegegnen();
                    break;

                case Previous.JoshkaBegegnen:
                    KampfFeuerdracheSchwach();
                    break;

                case Previous.TauschMesserblock:
                    EndeThemenpark();
                    break;

                case Previous.TauschNunchakus:
                    KampfFeuerdracheStark();
                    break;

                case Previous.MitEierWerfen:
                    KaffeBohnenplantageGeschenkeAbweisen();
                    break;

                case Previous.Geschenkeabweisen:
                    KaffeBohnenplantageMitEiernWerfen();
                    break;

                case Previous.TiefseegrotteUngeheuerBesiegt:
                    KueberlinAnkunft();
                    break;

                case Previous.KuerbistanGeschenkeAblehnen:
                    KuerbistanAnkunft();
                    break;

                case Previous.KuerbistanGeschenkeAnnehmen:
                    KuerbistanWahlkampf();
                    break;


                case Previous.TiefseegrotteVorbeimogeln:
                    TiefseegrotteVorbeimogeldTod();
                    break;
                case Previous.GeschenkeAnnehmen:
                    KaffeBohnenplantageWeiteSuchen();
                    break;
                case Previous.WeiteSuchen:
                    KaffeBohnenmehrKuerbisse();
                    break;
                case Previous.KaffeBohnenplantageVerantwortungStellen:
                    KaffeBohnenplantageSalzverwenden();
                    break;

                case Previous.KuerbistanAnkunft:
                    KuerbistanGeschenkeAnnehmen();
                    break;

                case Previous.KuerberlinKampfGewonnen:
                    KuerbistanAnkunft();
                    break;


                case Previous.FeuerdracheSchwachBesiegt:
                    KampfFeuerdracheStark();
                    break;

                case Previous.KuerbistanWahlkampf:
                    KuerbistanMehrKuerbis();
                    break;

                case Previous.ZurueckAufStraße:
                    RaetselMauer();
                    break;

                case Previous.KueberlinAnkunft:
                    KaffeBohnenplantageGnadeFlehen();
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
            switch (previous)
            {
                case Previous.Start:
                    EndeAugenGeschlossen();
                    break;

                case Previous.BerufungErfragt:
                    AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Keine);
                    ZielErfragen();
                    break;

                case Previous.ZielErfragt:
                    EisKaufen();
                    break;

                case Previous.EisKaufen:
                    EisNichtGekauft();
                    break;

                case Previous.Taube:
                    TaubeTreten();
                    break;

                case Previous.MachtGestartet:
                    TiefseegrotteFragen();
                    break;

                case Previous.TiefseegrotteGeschwommen:
                    TiefseegrotteBegegnungUngeheuer();
                    break;

                case Previous.KaffeBohnenplantage:
                    AktuellerHeld.EntferneItem("Münze");
                    EisKaufen();
                    break;

                case Previous.TiefseegrotteBegegnungUngeheuer:
                    TiefseegrotteVorbeimogeln();
                    break;

                case Previous.TiefseegrotteVorbeimogeln:
                    TiefseegrotteKonversation();
                    break;
                case Previous.BrueckenZollMuenzeVorhanden:
                    WegZurTiefseegrotte();
                    break;

                case Previous.KuerbistanAnkunft:
                    KuerbistanGeschenkeAblehnen();
                    break;

                case Previous.Weggabelung:
                    Fußweg();
                    break;

                case Previous.JoshkaBegegnen:
                    Tauschgeschaeft();
                    break;

                case Previous.MachtWichtig:
                    KaempfenKaffeeGegenKobolde();
                    break;

                case Previous.MitEierWerfen:
                    KaffeBohnenplantageGeschenkeAnnehmen();
                    break;

                case Previous.WeiteSuchen:
                    KaffeBohnenWollenEier();
                    break;

                case Previous.GeschenkeAnnehmen:
                    KaffeBohnenplantageVerantwortungStellen();
                    break;

                case Previous.KaffeBohnenplantageVerantwortungStellen:
                    KaffeBohnenplantageSteak();
                    break;

                case Previous.KuerbistanWahlkampf:
                    KuerbistanEier();
                    break;
                case Previous.KueberlinAnkunft:
                    KaempfenKaffeeGegenKobolde();
                    break;

                case Previous.KuerbistanGeschenkeAnnehmen:
                    KaffeBohnenplantageVerantwortungStellen();
                    break;
                case Previous.TiefseegrotteErfragt:
                    KaffeBohnenplantage();
                    break;
                // links
                case Previous.WegZurTiefseegrotte:
                    ZurueckAufStraße();
                    break;

                // case Previous.istMachtWichtig:
                //    MitEiernWerfen();
                //  break;

                default:
                    KaempfeWennMoeglich(buttonIndex: 1);
                    break;
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            switch (previous)
            {
                case Previous.MachtWichtig:
                    KaffeBohnenplantageMitEiernWerfen();
                    break;
                //case Previous.istMachtWichtig:
                //KuerberlinEier();
                // break;

                default:
                    KaempfeWennMoeglich(buttonIndex: 2);
                    break;
            }
        }

        private void KaempfeWennMoeglich(int buttonIndex)
        {
            if (Kampf != null)
            {
                if (Kampf.IstZuende)
                {
                    Kampf = null;

                    switch (previous)
                    {
                        case Previous.TiefseegrotteUngeheuerKaempfen:
                            TiefseegrotteUngeheuerBesiegt();
                            break;

                        case Previous.KaempfenKaffeeKobolde:
                            KaempfenKoboldanfuehrer();
                            break;

                        case Previous.KaempfenKoboldanfuehrer:
                            KuerberlinKampfGewonnen();
                            break;

                        case Previous.FeuerdracheStarkKaempfen:
                            EndeThemenpark();
                            break;
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
                            if (previous == Previous.FeuerdracheSchwachKaempfen ||
                                previous == Previous.FeuerdracheStarkKaempfen)
                            {
                                TodKampf();
                            }
                            else
                            {
                                WriteText("Du bist im Kampf gestorben!");
                            }
                            SpielZuende();
                        }
                        else
                        {
                            if (previous == Previous.FeuerdracheSchwachKaempfen)
                            {
                                KampfSchwachBeendet();
                            }
                            else
                            {
                                SetButtonsText("Kampf beenden");
                            }
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

        private void VerarbeiteTextEingabe()
        {
            string eingabe = TextBoxEingabe.Text;
            int zahl = TextAlsZahl(eingabe);
            switch (previous)
            {
                case Previous.NameErfragt:
                    AktuellerHeld.Name = eingabe;
                    BerufungErfragen();
                    break;

                case Previous.BerufErfragt:
                    switch (eingabe.ToLower())
                    {
                        case "krieger":
                            AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Krieger);
                            ZielErfragen();
                            break;
                        case "kriegerin":
                            AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Krieger);
                            ZielErfragen();
                            break;
                        case "waldläuferin":
                            AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Waldlaeufer);
                            ZielErfragen();
                            break;
                        case "waldläufer":
                            AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Waldlaeufer);
                            ZielErfragen();
                            break;
                        case "magierin":
                            AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Magier);
                            ZielErfragen();
                            break;
                        case "magier":
                            AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Magier);
                            ZielErfragen();
                            break;
                        case "assassine":
                            AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Assassine);
                            ZielErfragen();
                            break;
                        default:
                            WriteText("Diesen Beruf kenne ich nicht. Kannst du ihn nochmal wiederholen?", "");
                            break;
                    }

                    break;

                case Previous.RaetselMauer:
                    switch (eingabe.ToLower())
                    {
                        case "kürbis":
                        case "vierunddreißig":
                        case "fünf":
                        case "eins":
                            Raetsel2();
                            break;

                        case "acht":
                            Weggabelung();
                            break;

                        default:
                            WriteText("Das ist auf jeden Fall keine Antwortmöglichkeit!", "");
                            break;
                    }

                    break;

                case Previous.Raetsel2:
                    switch (eingabe.ToLower())
                    {
                        case "thoron":
                        case "Eierkarton":
                        case "donald j trumpkin":
                        case "blau":
                            Windstoß();
                            break;

                        case "acht":
                            Weggabelung();
                            break;

                        default:
                            WriteText("Das ist auf jeden Fall keine Antwortmöglichkeit!", "");
                            break;
                    }

                    break;

                case Previous.Tauschgeschaeft:
                    switch (eingabe.ToLower())
                    {
                        case "nunchakus":
                            if (AktuellerHeld.HatItem("Nunchakus"))
                            {
                                TauschNunchakus();
                            }
                            else
                            {
                                goto default;
                            }
                            break;

                        case "messerblock":
                            if (AktuellerHeld.HatItem("Messerblock"))
                            {
                                TauschMesserblock();
                            }
                            else
                            {
                                goto default;
                            }
                            break;

                        default:
                            WriteText("Dieses Item befindet sich nicht in deinem Inventar.");
                            break;
                    }

                    break;

                case Previous.TiefseegrotteKonversation:
                    if (zahl == 5 && AktuellerHeld.Klasse.KlassenTyp != KlassenTyp.Magier)
                    {
                        zahl = -1;
                    }

                    switch (zahl)
                    {
                        case 1:
                        case 3:
                            TiefseegrotteFalscheAntwort();
                            break;

                        case 2:
                        case 4:
                        case 5:
                            TiefseegrotteRichtigeAntwort();
                            break;

                        default:
                            WriteText("Diese Antwortmöglichkeit gibt es nicht");
                            break;
                    }
                    break;
            }

            TextBoxEingabe.Text = "";
        }
    }
}

﻿using SchuBS_Textadventure.Dialogs;
using SchuBS_Textadventure.MyControls;
using SchuBS_Textadventure.Objects.Verlauf;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;

namespace SchuBS_Textadventure
{
    /// <summary>
    /// Stellt Hilfsfunktionen für das Textadventure bereit.
    /// </summary>
    public static class TextadventureHelper
    {
        /// <summary>
        /// Kann zum zufälligen erstellen von Zahlen verwendet werden.
        /// <list type="table">
        /// <item><description>Zwischen 0 und 10: <c>Zufallsgenerator.Next(10)</c></description></item>
        /// <item><description>Zwischen 5 und 10: <c>Zufallsgenerator.Next(5, 10)</c></description></item>
        /// </list>
        /// </summary>
        public static readonly Random Zufallsgenerator = new();

        /// <summary>
        /// Die Aktionsknöpfe der Oberfläche.
        /// </summary>
        public static Button[] ButtonsAktionen { get; set; }

        /// <summary>
        /// Werden im Text Variablen verwendet, müssen dises mit diesem Wert umschlossen sein.
        /// </summary>
        public const string TextVariableDelimiter = "##";

        /// <summary>
        /// Speichert die aktuelle Auswahl, die der Spieler mit den <see cref="ButtonsAktionen"/> gerade treffen muss und das Ergebnis.
        /// </summary>
        public static Auswahl AktuelleAuswahl { get; set; }

        /// <summary>
        /// Speichert den gesamten Verlauf des Textadventures
        /// </summary>
        public static Verauf VerlaufText { get; private set; }

        private static Image ImageHintergrund;
        private static Image ImagePerson;
        private static SlowTextBox TextBoxHauptText;
        private static TextBox TextBoxEingabe;
        private static UniformGrid UniformGridButtons;

        private static Func<string[], string> GetText;

        private static VerlaufFenster AktuellesVerlaufFenster;

        /// <summary>
        /// Initialisiert den Helfer.
        /// Diese Methode sollte vor allen anderen aufgerufen werden.
        /// </summary>
        /// <param name="buttonsAktionen">Die <see cref="Button"/>s, mit denen der Spieler interagieren kann.</param>
        /// <param name="imageHintergrund">Das <see cref="Image"/>, dass das Hintergrundbild enthält.</param>
        /// <param name="imagePerson">Das <see cref="Image"/>, in dem eine Person dargestellt werden kann.</param>
        /// <param name="textBoxHauptText">Die <see cref="SlowTextBox"/>, in der Text für den Spieler angezeigt wird.</param>
        /// <param name="textBoxEingabe">Die <see cref="TextBox"/>, in die der Spieler Texte eingeben kann.</param>
        /// <param name="uniformGridButtons">Das <see cref="UniformGrid"/>, dass die <paramref name="buttonsAktionen"/> enthält.</param>
        /// <param name="getText">Wandelt einen <see cref="string"/><c>[]</c> in einen Text um, der dem Spieler angezeigt werden kann.</param>
        public static void Init(Button[] buttonsAktionen,
                                Image imageHintergrund,
                                Image imagePerson,
                                SlowTextBox textBoxHauptText,
                                TextBox textBoxEingabe,
                                UniformGrid uniformGridButtons,
                                Func<string[], string> getText)
        {
            ButtonsAktionen    = buttonsAktionen    ?? throw new ArgumentNullException(nameof(buttonsAktionen));
            ImageHintergrund   = imageHintergrund   ?? throw new ArgumentNullException(nameof(imageHintergrund));
            ImagePerson        = imagePerson        ?? throw new ArgumentNullException(nameof(imagePerson));
            TextBoxHauptText   = textBoxHauptText   ?? throw new ArgumentNullException(nameof(textBoxHauptText));
            TextBoxEingabe     = textBoxEingabe     ?? throw new ArgumentNullException(nameof(textBoxEingabe));
            UniformGridButtons = uniformGridButtons ?? throw new ArgumentNullException(nameof(uniformGridButtons));
            GetText            = getText            ?? throw new ArgumentNullException(nameof(getText));

            AktuelleAuswahl         = null;
            AktuellesVerlaufFenster = null;
            VerlaufText             = new Verauf();
        }

        /// <summary>
        /// Zeigt ein Popup, in dem der ganze bisher gezeigte Text gezeigt wird.
        /// </summary>
        public static void ZeigeVerlaufFenster()
        {
            if (AktuellesVerlaufFenster is null)
            {
                AktuellesVerlaufFenster = new VerlaufFenster(VerlaufText);
                AktuellesVerlaufFenster.Closed += delegate
                {
                    AktuellesVerlaufFenster = null;
                };
                AktuellesVerlaufFenster.Show();
            }
            else
            {
                AktuellesVerlaufFenster.Activate();
            }
        }

        /// <summary>
        /// Setzt den Text der Aktions-Knöpfe. Nicht genutze Knöpfe werden ausgeblendet.
        /// Setzt automatisch <see cref="AktuelleAuswahl"/> neu.
        /// <code>SetButtonsText("Links", "Rechts");</code>
        /// </summary>
        /// <param name="text"></param>
        public static void SetButtonsText(params string[] text)
        {
            SetButtonsTextOhneVerlauf(text);

            AktuelleAuswahl = new Auswahl()
            {
                Aktionen = text,
            };

            VerlaufText.AppendBlock(AktuelleAuswahl);
        }

        /// <summary>
        /// Genau wie <see cref="SetButtonsText(string[])"/>, der Text der Buttons wird aber nicht zum Verlauf hinzugeüft.
        /// </summary>
        /// <param name="text"></param>
        public static void SetButtonsTextOhneVerlauf(params string[] text)
        {
            for (int buttonIndex = 0; buttonIndex < ButtonsAktionen.Length; buttonIndex++)
            {
                string buttonText = buttonIndex < text.Length ? text[buttonIndex] : null;

                ButtonsAktionen[buttonIndex].Content    = buttonText;
                ButtonsAktionen[buttonIndex].Visibility = string.IsNullOrEmpty(buttonText) ? Visibility.Collapsed : Visibility.Visible;
                ButtonsAktionen[buttonIndex].IsEnabled  = !string.IsNullOrEmpty(buttonText);
            }

            if (TextBoxEingabe.IsEnabled)
            {
                ButtonsAktionen[0].Focus();
                TextBoxEingabe.IsEnabled = false;
            }

            UniformGridButtons.Columns = ButtonsAktionen.Count(button => button.Visibility == Visibility.Visible);
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
        public static void WriteText(IEnumerable<string> zeilen) => WriteText(zeilen.ToArray());

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

            VerlaufText.AppendBlock(text);

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
            VerlaufText.AppendBlock(text);
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
        /// Versucht den <paramref name="text"/> in einen <see cref="int"/> umzuwandlen und gibt diesen zurück.<br/>
        /// Ist keine Umwandlung möglich wird <c>-1</c> zurückgegeben.
        /// <code>
        /// int wert = TextAlsKommaZahl(eingabe);<br/>
        /// if (wert != -1) { ... }
        /// </code>
        /// </summary>
        /// <param name="text">Der text, der zu einem <see cref="int"/> umgewandelt werden soll.</param>
        /// <returns>Den <paramref name="text"/> als <see cref="int"/>.</returns>
        public static int TextAlsZahl(string text) =>
            int.TryParse(text, out int eingabeZahl) ? eingabeZahl : -1;

        /// <summary>
        /// Versucht den <paramref name="text"/> in einen <see cref="double"/> umzuwandlen und gibt diesen zurück.<br/>
        /// Ist keine Umwandlung möglich wird <see cref="double.NaN"/> zurückgegeben.
        /// <code>
        /// double wert = TextAlsKommaZahl(eingabe);<br/>
        /// if (!double.IsNaN(wert)) { ... }
        /// </code>
        /// </summary>
        /// <param name="text">Der text, der zu einem <see cref="double"/> umgewandelt werden soll.</param>
        /// <returns>Den <paramref name="text"/> als <see cref="double"/>.</returns>
        public static double TextAlsKommaZahl(string text) =>
            double.TryParse(text.Replace('.', ','), out double eingabeZahl) ? eingabeZahl : double.NaN;

        /// <summary>
        /// Gibt den Wert als <see cref="string"/>, der für das Startargument angegeben wurde.<br/>
        /// Wurde das Argument nicht angegeben, wird <see langword="null"/> zurückgegeben.
        /// <code>SchuBS-Textadventure.exe \class Krieger</code>
        /// <code>if (<see cref="GetStartArgsParameter(string)">GetStartArgsParameter("class")</see> is <see cref="string"/> klassenName) { ... }<br/>
        /// else { ... }<br/>
        /// </code>
        /// </summary>
        /// <param name="name">Der Name des Startargumentes.</param>
        /// <returns>Der Wert des Startargumentes als <see cref="string"/>.</returns>
        public static string GetStartArgsParameter(string name)
        {
            string[] args = Environment.GetCommandLineArgs();
            int index = Array.IndexOf(args, $"\\{name}");
            return index >= 0 && index + 1 < args.Length ? args[index + 1] : null;
        }
    }
}

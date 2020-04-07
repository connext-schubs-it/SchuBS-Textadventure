﻿using SchuBS_IT_2020;
using SchuBS_Textadventure.Dialogs;

using System;
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

        public const string Weltname = "";

        public string[] DefaultButtonText = new string[]
        {
            "Button 1",
            "Button 2",
            "Button 3",
        };

        public Button[] ButtonsAktionen;

        #endregion

        #region Spiel Variablen

        public Spieler AktuellerHeld = new Spieler();

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
            Start();
        }

        #region Funktionen

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
                    ButtonsAktionen[i].IsEnabled = false;
                }
            }
        }

        public void SetButtonText(int buttonIndex, string text)
        {
            ButtonsAktionen[buttonIndex].Content = text ?? DefaultButtonText[buttonIndex];
        }

        /// <summary>
        /// Schreibt die Zeilen in die ausgabe Textbox. Nach jeder Zeile wird ein Zeilenumbruch eingefügt.<br/>
        /// Im Text enthaltene Variablen (mit <see cref="TextVariableDelimiter"/> umschlossen) werden durch die entsprechenden
        /// Werte ersetzt.
        /// </summary>
        /// <param name="zeilen"></param>
        /// <example><code>WriteText("Hallo!", "Wie gehts es dir?");</code></example>
        public void WriteText(params string[] zeilen)
        {
            string text = string.Join("\n", zeilen);

            Escape("SpielerName", AktuellerHeld.Name);
            Escape("SpielerKlasse", AktuellerHeld.Klasse.ToString());
            Escape("Weltname", Weltname);

            VerlaufText.AppendLine(text);
            TextBoxHauptText.SetText(text);

            string Escape(string textVaraible, string wert) =>
                text = Regex.Replace(text, TextVariableDelimiter + textVaraible + TextVariableDelimiter, wert ?? string.Empty);
        }


        private void ButtonVerlauf_Click(object sender, RoutedEventArgs e)
        {
            new VerlaufFenster(VerlaufText.ToString()).ShowDialog();
        }

        public void SetzeHintergrundBild(string bildName) => ImageHintergrund.Source = GetBild(bildName);

        public void SetzePersonenBild(string bildName) => ImagePerson.Source = GetBild(bildName);

        public BitmapImage GetBild(string name) => new BitmapImage(new Uri("pack://application:,,,/Resources/" + name));

        #endregion
    }
}

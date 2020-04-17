﻿using SchuBS_Textadventure.Objects.Verlauf;

using System;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SchuBS_Textadventure.Dialogs
{
    public partial class VerlaufFenster : Window
    {
        /// <summary>
        /// Erstellt ein neuers Objekt vom Typ <see cref="VerlaufFenster"/> mit dem <paramref name="verauf"/>.
        /// </summary>
        /// <param name="verauf"></param>
        public VerlaufFenster(Verauf verauf)
        {
            InitializeComponent();
            foreach (object item in verauf.VerlaufItems)
            {
                AddVerlaufItem(item);
            }

            verauf.VerlaufItems.CollectionChanged += VerlaufItems_CollectionChanged;
        }

        private void VerlaufItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            bool end = ScrollViewerVerlauf.VerticalOffset == ScrollViewerVerlauf.ScrollableHeight;

            foreach (object item in e.NewItems)
            {
                AddVerlaufItem(item);
            }

            if (end)
                ScrollViewerVerlauf.ScrollToEnd();
        }

        private void AddVerlaufItem(object item)
        {
            var textblock = new TextBlock();
            bool spielerEingabe = false;

            switch (item)
            {
                case Eingabe _:
                    spielerEingabe = true;
                    goto default;

                case Auswahl auswahl:
                    spielerEingabe = true;
                    for (int index = 0; index < auswahl.Aktionen.Length; index++)
                    {
                        Run inline = new Run(auswahl.Aktionen[index]);
                        if (index != auswahl.GewaehlterAktionsIndex)
                        {
                            inline.Foreground = new SolidColorBrush(Colors.Gray);
                        }

                        textblock.Inlines.Add(inline);

                        if (index != auswahl.Aktionen.Length - 1)
                            textblock.Inlines.Add(new Run(Environment.NewLine));
                    }

                    Auswahl.GewaehlterAktionsIndexPropertyDescriptor.AddValueChanged(auswahl, (sender, e) =>
                        {
                            if (textblock.Inlines.FirstOrDefault(inl => auswahl.Aktionen[auswahl.GewaehlterAktionsIndex] == (inl as Run)?.Text) is Inline inline)
                            {
                                inline.Foreground = new SolidColorBrush(Colors.White);
                            }
                        });
                    break;

                default:
                    textblock.Text = item?.ToString();
                    break;
            }

            if (spielerEingabe)
            {
                textblock.HorizontalAlignment = HorizontalAlignment.Right;
            }

            if (StackPanelVerlaufText.Children.Count != 0)
            {
                StackPanelVerlaufText.Children.Add(new Rectangle()
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Stroke = new SolidColorBrush(Colors.White),
                    Margin = new Thickness(0, 5, 0, 5)
                });
            }

            StackPanelVerlaufText.Children.Add(textblock);
        }

        private void ScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            ((ScrollViewer)sender).ScrollToBottom();
        }
    }
}

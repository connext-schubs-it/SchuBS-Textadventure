
using System.Collections.Generic;
using Newtonsoft.Json;
using SchuBS_Textadventure.Helpers;

namespace SchuBS_Textadventure.Objects
{
    public class Gegner : BaseObject
    {
        public int Staerke { get; set; }
        public int Verteidigung { get; set; }

        public enum GegnerTyp
        {
            Feuerdrache,
            Ungeheur
        }

        internal static Gegner GetGegnerByTyp(List<Gegner> gegnerListe, GegnerTyp typ)
        {
            foreach (Gegner item in gegnerListe)
            {
                if (item.Name.Equals(nameof(typ)))
                    return item;
            }

            return null;
        }

        internal static List<Gegner> LadeGegner()
        {
            List<Gegner> gegnerList = new List<Gegner>()
            {
                new Gegner()
                {
                    Name = "Feuerdrache",
                    Lebenspunkte = 100,
                    Staerke = 10,
                    Verteidigung = 10,
                    Reaktionen = new List<Reaktion>()
                    {
                        new Reaktion() { LP = 90, Text = "Ha das war ja gar nichts!"},
                        new Reaktion() { LP = 60, Text = "Gar nicht mal schlecht!"},
                        new Reaktion() { LP = 30, Text = "Ouch!"},
                        new Reaktion() { LP = 10, Text = "Aufhören!"}
                    }
                },
                new Gegner()
                {
                    Name = "Ungeheuer",
                    Lebenspunkte = 100,
                    Staerke = 1,
                    Verteidigung = 0,
                    Reaktionen = new List<Reaktion>()
                    {
                        new Reaktion() { LP = 90, Text = "Ha das war ja gar nichts!"},
                        new Reaktion() { LP = 60, Text = "Gar nicht mal schlecht!"},
                        new Reaktion() { LP = 30, Text = "Ouch!"},
                        new Reaktion() { LP = 10, Text = "Aufhören!"}
                    }
                }
            };

            return gegnerList;
        }
    }
}

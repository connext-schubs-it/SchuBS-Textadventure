using System;
using System.Collections.Generic;

using SchuBS_Textadventure.Helpers;

namespace SchuBS_Textadventure.Objects
{
    public class Gegner : BaseObject
    {
        public int Staerke { get; set; }
        public int Verteidigung { get; set; }

        public enum Typ
        {
            Feuerdrache,
            Ungeheuer
        }

        public static Gegner GetByTyp(List<Gegner> gegnerListe, Typ typ)
        {
            foreach (Gegner item in gegnerListe)
            {
                if (item.Name.Equals(Enum.GetName(typeof(Typ), typ)))
                    return item;
            }

            return null;
        }

        public static List<Gegner> LadeGegner()
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

using System;
using System.Collections.Generic;

namespace Aufgabe1
{
    public class Spielkarte
    {
        public Kartenfarbe Farbe { get; private set; }
        public Kartenwert Wert { get; private set; }


        public static IEnumerable<Kartenfarbe> Kartenfarben()
        {
            foreach (Kartenfarbe kartenfarbe in Enum.GetValues(typeof(Kartenfarbe)))
                yield return kartenfarbe;
        }

        public static IEnumerable<Kartenwert> Kartenwerte()
        {
            foreach (Kartenwert kartenwert in Enum.GetValues(typeof(Kartenwert)))
                yield return kartenwert;
        }


        /// <summary>
        /// Kartenspiel mit LINQ
        /// 
        /// Der Konstruktor, der zwei Parameter akzeptiert: eine
        /// Kartenfarbe und einen Kartenwert. Diese Parameter werden in den beiden öffentlichen,
        /// schreibgeschützten Eigenschaften Farbe und Wert gespeichert.
        /// </summary>
        public Spielkarte(Kartenfarbe kartenfarbe, Kartenwert kartenwert)
        {
            Farbe = kartenfarbe;
            Wert = kartenwert;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool Equals(object o)
        {
            if (o == null) return false;
            Spielkarte other = o as Spielkarte;
            if (other == null) return false;
            return this.Farbe == other.Farbe && this.Wert == other.Wert;
        }
        
        /// <summary>
        /// Die ToString() Methode wird hier überschrieben, so dass die Farbe und der Wert mit
        /// einem Bindestrich getrennt als Ergebnis zurückgegeben werden.
        /// </summary>
        public override string ToString() => $"{Farbe}-{Wert}";
    }
}

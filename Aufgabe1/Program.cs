using System;
using System.Linq;
using System.Collections.Generic;

namespace Aufgabe1
{
    class Program
    {       
        static void Main(string[] args)
        {
            Console.Write("Kartenfarben: ");
            foreach (Kartenfarbe farbe in Spielkarte.Kartenfarben())
            {
                Console.Write(farbe + " ");
            }
            Console.WriteLine();
            Console.Write("Kartenwerte: ");
            foreach (Kartenwert wert in Spielkarte.Kartenwerte())
            {
                Console.Write(wert + " ");
            }
            

            Console.WriteLine();
            Console.WriteLine();


            /* Hier werden mit Hilfe eines LINQ-Ausdrucks unter Verwendung der beiden statischen
             * Methoden Kartenfarben() und Kartenwerte() und des Konstruktors alle 32 Spielkarten
             * erzeugt.
             */
            IEnumerable<Spielkarte> Kartenspiel = (from Kartenfarbe in Spielkarte.Kartenfarben()
                                                   from Kartenwert in Spielkarte.Kartenwerte()
                                                   select new Spielkarte(Kartenfarbe, Kartenwert)).ToList();
            Console.Write("Kartenspiel: ");            
            foreach (Spielkarte k in Kartenspiel)
            {
                Console.Write(k + " ");
            }
                        
            
            Console.WriteLine();
            Console.WriteLine();


            /* Zweiter LINQ-Ausdruck, um alle Asse in dem Kartenspiel zu finden.
             */
            Console.Write("Asse: ");
            IEnumerable<Spielkarte> Asse = (from karte in Kartenspiel
                                           where karte.Wert.Equals(Kartenwert.Ass)
                                           select karte).ToList();
            foreach (Spielkarte k in Asse) Console.Write(k + " ");


            Console.WriteLine();
            Console.WriteLine();


            var Spielkarten = Kartenspiel.Take(16).MischenMit(Kartenspiel.Skip(16));
            Console.Write("Spielkarten: ");
            foreach (var k in Spielkarten) Console.Write(k + " ");

            Console.WriteLine();

            Console.WriteLine("\nSpielkarten gemischt: " + !Kartenspiel.VergleichenMit(Spielkarten));                       
        }
    }
}

using System;
using System.Collections;

namespace Aufgabe3
{
    class Fussballverein : IComparable<Fussballverein>
    {
        public string Name { get; set; }
        public int Punkte { get; set; }
        public int Tordifferenz { get; set; }

        /// <summary>
        /// Bei einem Vergleich soll der Verein, der mehr
        /// Punkte hat, oder bei gleicher Punktzahl der Verein mit der besseren Tordifferenz in einer
        /// sortierten Reihenfolge VORNE stehen.Implementieren Sie dazu die IComparable<T>-Schnittstelle.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Fussballverein other)
        {
            if (Punkte > other.Punkte)
                return -1;
            if (Punkte == other.Punkte)
            {
                if (Tordifferenz < other.Tordifferenz) return 1;
                else if (Tordifferenz == other.Tordifferenz) return 0;
                else return -1;
            };
            return 1;
        }
    }
}

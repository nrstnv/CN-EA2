using System;
using System.Collections.Generic;
using System.Linq;

namespace Aufgabe1
{
    public static class Erweiterungsmethoden
    {       
        /// <summary>
        /// Die Erweiterungsmethode MischenMit mischt die beiden Kartenstapel, indem Sie immer
        /// abwechselnd die nächste (unterste) Karte des ersten Kartenstapels und die nächste Karte des
        /// zweiten Kartenstapels auswählt.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stapel1"></param>
        /// <param name="stapel2"></param>
        /// <returns></returns>
        public static IEnumerable<T> MischenMit<T>(this IEnumerable<T> stapel1, IEnumerable<T> stapel2)
        {
            // Inefizienter Ansatz
            //for (int index = 0; index < stapel1.Count(); index++)
            //{
            //    yield return stapel1.ElementAt(index);
            //    yield return stapel2.ElementAt(index);
            //}

            // Bessere Vorgehensweise, da die Eigenschaften der Aufzählungen
            // zum Iterieren eingesetzt werden
            var s1 = stapel1.GetEnumerator();
            var s2 = stapel2.GetEnumerator();
            while (s1.MoveNext() && s2.MoveNext())
            {
                yield return s1.Current;
                yield return s2.Current;
            }
        }

        /// <summary>
        /// Die Erweiterungsmethode VergleichenMit vergleicht die
        /// jeweiligen Karten der beiden Kartenstapel miteinander. Diese Methode liefert True zurück, falls
        /// die Reihenfolge der Karten in beiden Stapeln gleich sind und ansonsten False.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stapel1"></param>
        /// <param name="stapel2"></param>
        /// <returns></returns>
        public static bool VergleichenMit<T>(this IEnumerable<T> stapel1, IEnumerable<T> stapel2)
        {
            return stapel1.SequenceEqual(stapel2);
        }
    }
}

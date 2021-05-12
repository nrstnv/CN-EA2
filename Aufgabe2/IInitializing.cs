using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabe2
{
    /// <summary>
    /// Stellt eine Methode bereit zur Initialisierung von Objekten.
    /// </summary>
    /// <typeparam name="P">
    /// Der Typ des Parameters, mit dem das Objekt initialisiert werden soll.
    /// </typeparam>
    interface IInitializing<P>
    {
        /// <summary>
        /// Initialisiert das Objekt.
        /// </summary>
        /// <param name="p">
        /// Der Parameter, mit dem das Objekt initialisiert wird.
        /// </param>
        void Initialize(P p);
    }
}

using System.Collections.Generic;

namespace Aufgabe2
{
    /// <summary>
    /// Dies ist eine generische Klasse Factory<TItemType, TParameterType>.
    /// 
    /// Auf die generischen Typparameter der Klasse sind Einschränkungen angewendet,
    /// um neue Objekte erzeugen zu können und um die Initialize-Methode auf
    /// diesen Instanzen aufrufen zu können.
    /// </summary>
    /// <typeparam name="TItemType"></typeparam>
    /// <typeparam name="TParameterType"></typeparam>    
    class Factory<TItemType, TParameterType> where TItemType : IInitializing<TParameterType>, new()
    {
        public static TParameterType Parameter { get; private set; }

        /// <summary>
        /// Der Konstruktor dieser Klasse erwartet einen Parameter vom Typ TParameterType mit dem die
        /// Objekte vom Typ TItemType bei der Generierung initialisiert werden.
        /// </summary>
        /// <param name="parameter"></param>
        public Factory(TParameterType parameter)
        {
            Initialize(parameter);
        }

        static void Initialize(TParameterType type)
        {
            Parameter = type;
        }


        /// <summary>
        /// Hier ist eine parameterlose Methode MakeItem, die bei jedem Aufruf ein neues Objekt
        /// vom Typ TItemType generiert und initialisiert. Die Methode gibt dieses Objekt als Ergebnis
        /// zurück.
        /// </summary>
        public static TItemType MakeItem()
        {
            var item = new TItemType();
            item.Initialize(Parameter);
            return item;
        }


        /// <summary>
        /// Hier ist eine weitere Methode MakeItems, welche als Parameter eine Anzahl entgegennimmt
        /// und ein Array mit dieser Länge von initialisierten Objekten vom Typ TItemType zurückgibt.
        /// Diese Methode ruft dazu entsprechend oft die Methode MakeItem auf.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static TItemType[] MakeItems(int count)
        {
            List<TItemType> items = new List<TItemType>();
            for (int i = 0; i < count; i++)
            {                
                items.Add(MakeItem());
            }
            return items.ToArray();
        }
    }
}

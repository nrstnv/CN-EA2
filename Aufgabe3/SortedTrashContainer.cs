using System;
using System.Collections;
using System.Collections.Generic;

namespace Aufgabe3
{
    /// <summary>
    /// Ziel dieser Aufgabe ist es, eine generische Klasse SortedTrashContainer<T> zu implementieren,
    /// bei der die Elemente beim Hinzufügen automatisch sortiert werden. Die maximale Anzahl wird als
    /// Parameter im Konstruktor übergeben. Falls eine negative Zahl übergeben wird, soll eine
    /// ArgumentOutOfRangeException ausgelöst werden.
    /// Überlegen Sie sich, welche Einschränkungen für den Typ T gelten müssen, damit alle unten
    /// angegebenen Methoden korrekt funktionieren.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class SortedTrashContainer<T> : IEnumerable<T> where T : IComparable<T>
    {
        private int size;
        private int pointer = 0;
        private T[] items;

        /// <summary>
        /// Maximale Anzahl von Elementen im Mülleimer.
        /// </summary>
        public int Capacity => size;


        /// <summary>
        /// Die aktuelle Anzahl von Elementen im Mülleimer.
        /// </summary>
        public int Count => pointer;


        /// <summary>
        /// Ein Flag das anzeigt, ob der Mülleimer voll ist oder nicht. 
        /// </summary>
        public bool isFull => pointer == size;


        /// <summary>
        /// Die maximale Anzahl wird als Parameter im Konstruktor übergeben.
        /// Falls eine negative Zahl übergeben wird, soll eine 
        /// ArgumentOutOfRangeException ausgelöst werden.
        /// </summary>
        /// <param name="capacity"></param>        
        public SortedTrashContainer(int capacity)
        {            
            if (capacity >= 0)
            {
                size = capacity;
                items = new T[capacity];
            }
            else
                throw new ArgumentOutOfRangeException(string
                .Format("Argument außerhalb des Bereichs. Die Größe eines Mülleimers kann nicht negativ sein."));
        }


        /// <summary>
        /// Löscht alle Elemente im Mülleimer und setzt die
        /// Array-Einträge auf den Default-Wert des jeweiligen Typs.
        /// </summary>        
        public void Clear()
        {
            items = new T[size];
            pointer = 0;
        }


        /// <summary>
        /// Fügt ein Element an der korrekten Position hinzu,
        /// so dass die Elemente im Mülleimer in aufsteigender Reihenfolge sortiert sind.
        /// Falls der Mülleimer schon voll ist, wird eine InvalidOperationException ausgelöst.
        /// </summary>
        public void Add(T item)
        {
            if (pointer < size)
            {
                items[pointer++] = item;
                Sort(items, pointer);
            }
            else
                throw new InvalidOperationException(string
                .Format("Ungültige Handlung. Sie versuchen, einem vollen Mülleimer einen neuen Element hinzuzufügen."));
        }

        
        /// <summary>
        /// Die Elemente beim Hinzufügen werden automatisch sortiert.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="currentItem"></param>
        private static void Sort(T[] array, int currentItem)
        {
            int top = currentItem - 1;
            int indexOfLargest;
            while (top > 0)
            {
                indexOfLargest = 0;
                for (int i = 0; i <= top; i++)
                {
                    if (array[indexOfLargest].CompareTo(array[i]) < 0)
                        indexOfLargest = i;
                }
                IComparable<T> temp = array[top];
                array[top] = array[indexOfLargest];
                array[indexOfLargest] = (T)temp;
                top--;
            }
        }
        

        /// <summary>
        /// Entfernt das letzte Element aus dem Mülleimer. Falls
        /// der Mülleimer leer ist, wird eine InvalidOperationException ausgelöst.
        /// </summary>        
        public void Remove()
        {
            if (pointer > 0 && !items[pointer - 1].Equals(default(T)))
            {
                items[pointer - 1] = default(T);
                pointer--;
            }
            else if (pointer == 0 /* && items[pointer].Equals(default(T))*/)
            {
                throw new InvalidOperationException(string
                    .Format("Ungültige Handlung. Sie versuchen, einen leeren Mülleimer zu leeren."));
            }
        }
        
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)items).GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int index = 0; index < pointer; index++)
                yield return items[index];
        }
    }
}

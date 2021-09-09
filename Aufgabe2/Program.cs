using System;

namespace Aufgabe2
{
    class A : IInitializing<String>
    {
        public string Culture { get; private set; }
        public void Initialize(string t)
        {
            Culture = t;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var factory = new Factory<A, String>("en-US");
            foreach (var item in factory.MakeItems(3))
            {
                Console.Write(item.Culture + " ");
            }
            Console.ReadKey(true);
        }
    }
}

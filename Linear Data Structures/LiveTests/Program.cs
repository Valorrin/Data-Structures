using System;
using Problem01.List;
using Problem04.SinglyLinkedList;

namespace LiveTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new SinglyLinkedList<int>();
           // list.AddFirst(5);

            Console.WriteLine(list.GetFirst());
            Console.WriteLine(list.GetLast());

            if (Equals(5, list.GetFirst()))
            {
                Console.WriteLine("Yess");
            }
            


        }
    }
}
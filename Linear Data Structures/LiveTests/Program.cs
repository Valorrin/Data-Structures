using System;
using Problem01.List;

namespace LiveTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new Problem01.List.List<int>();
            list.Add(5);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
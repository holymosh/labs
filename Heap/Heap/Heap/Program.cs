using System;
using System.Collections.Generic;

namespace Heap
{
    public class Program
    {
        static void Main(string[] args)
        {
            var heap = new Heap(new List<int>()
            {
                7,5,8,6,3,10,20,15,22,17
            });

            var sorted = heap.TreeSort();
            foreach (var element in sorted)
            {
                Console.Write(element+" ");
            }
        }
    }
}
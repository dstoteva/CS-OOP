using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());
            stack.Push("Ivan");
            stack.AddRange(new string[] { "Mimi", "Gosho", "Pesho" });
            Console.WriteLine(string.Join(":", stack));
            Console.WriteLine(stack.IsEmpty());
        }
    }
}

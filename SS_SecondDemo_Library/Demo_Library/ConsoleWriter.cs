using Demo_Library.Interfaces;
using System;

namespace Demo_Library
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
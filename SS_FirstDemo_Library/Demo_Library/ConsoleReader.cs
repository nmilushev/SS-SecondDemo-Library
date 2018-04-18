using Demo_Library.Interfaces;
using System;

namespace Demo_Library
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
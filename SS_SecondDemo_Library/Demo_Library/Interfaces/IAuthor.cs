using System;

namespace Demo_Library.Interfaces
{
    public interface IAuthor
    {
        string Name { get; }
        DateTime DateOfBirth { get; }
    }
}
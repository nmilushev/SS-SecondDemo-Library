using System;

namespace Demo_Library.Interfaces
{
    public interface IAuthorFactory
    {
        IAuthor CreateAuthor(string name, DateTime dateOfBirth);
    }
}
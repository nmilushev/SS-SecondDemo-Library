using Demo_Library.Interfaces;
using Demo_Library.Models;
using System;

namespace Demo_Library.Factrories
{
    public class AuthorFactory : IAuthorFactory
    {
        public IAuthor CreateAuthor(string name, DateTime dateOfBirth)
        {
            return new Author(name, dateOfBirth);
        }
    }
}
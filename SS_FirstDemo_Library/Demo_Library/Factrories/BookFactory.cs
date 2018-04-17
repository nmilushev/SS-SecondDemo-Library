using Demo_Library.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace Demo_Library.Factrories
{
    public class BookFactory : IBookFactory
    {
        private const string bookTypesSuffix = "Book";

        public IBook CreateBook(string bookType, long isbn, string title, IAuthor author, string bookGenre, int yearPublished, int length)
        {
           IBook book = null;

            Assembly assembly = Assembly.GetExecutingAssembly();

            Type model = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == bookType + bookTypesSuffix);

            if (model == null)
            {
                throw new ArgumentException(OutputMessages.InvalidTypeOfBook);
            }

            try
            {
                book = (IBook)Activator.CreateInstance(model, new object[] { isbn, title, author, bookGenre, yearPublished, length });
            }
            catch (TargetInvocationException tie)
            {
                throw new ArgumentException(tie.InnerException.Message);
            }

            return book;
        }
    }
}
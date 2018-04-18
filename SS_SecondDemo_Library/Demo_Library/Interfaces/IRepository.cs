using System.Collections.Generic;

namespace Demo_Library.Interfaces
{
    public interface IRepository
    {
        ICollection<IBook> Books { get; set; }
        void LoadBooks();
        void AddBook(IBook book);
        void RemoveBook(long isbn);
    }
}
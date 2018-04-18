using Demo_Library.Models.BookModels;

namespace Demo_Library.Interfaces
{
    public interface IBook
    {
        string BookType { get; }
        long ISBN { get; }
        string Title { get; }
        IAuthor Author { get; }
        BookGenre BookGenre { get; }
        int YearPublished { get; }
        int Length { get; }
    }
}
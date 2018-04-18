namespace Demo_Library.Models.BookModels
{
    public class PaperBook : Book
    {
        public PaperBook(long isbn, string title, Author author, string bookGenre, int yearPublished, int length)
            : base("Paper", isbn, title, author, bookGenre, yearPublished, length)
        {
        }
    }
}
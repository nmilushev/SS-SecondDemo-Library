namespace Demo_Library.Models.BookModels
{
    public class AudioBook : Book
    {
        public AudioBook(long isbn, string title, Author author, string bookGenre, int yearPublished, int length) 
            : base("Audio" , isbn, title, author, bookGenre, yearPublished, length)
        {
        }
    }
}
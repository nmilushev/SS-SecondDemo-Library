namespace Demo_Library.Interfaces
{
    public interface IBookFactory
    {
        IBook CreateBook(string bookType, 
                         long isbn, 
                         string title, 
                         IAuthor author, 
                         string bookGenre, 
                         int yearPublished, 
                         int length);
    }
}
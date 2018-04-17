using Demo_Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Demo_Library.Data
{
    public class BookRepository : IRepository
    {
        private const string fileWithDataPath = "../../data.csv";
        private const string dateFormat = "yyyy/mm/dd";

        private ICollection<IBook> books;
        private IBookFactory bookFactory;
        private IAuthorFactory authorFactory;

        public BookRepository(IBookFactory bookFactory, IAuthorFactory authorFactory)
        {
            this.Books = new List<IBook>();
            this.BookFactory = bookFactory;
            this.AuthorFactory = authorFactory;
            this.LoadBooks();
        }

        public ICollection<IBook> Books
        {
            get
            {
                return this.books;
            }
            set
            {
                this.books = value;
            }
        }

        public IBookFactory BookFactory
        {
            get
            {
                return this.bookFactory;
            }
            private set
            {
                this.bookFactory = value;
            }
        }

        public IAuthorFactory AuthorFactory
        {
            get
            {
                return this.authorFactory;
            }
            private set
            {
                this.authorFactory = value;
            }
        }

        // loading books from data.csv file
        public void LoadBooks()
        {
            string[] dataLines = File.ReadAllLines(fileWithDataPath);

            foreach (var line in dataLines)
            {
                string[] inputArgs = line.Split(new char[] { ',' });
                long isbn = long.Parse(inputArgs[0].Trim());
                string bookType = inputArgs[1].Trim();
                string bookGenre = inputArgs[2].Trim();
                string title = inputArgs[3].Trim();
                string authorName = inputArgs[4].Trim();
                DateTime authorBday = DateTime.ParseExact(inputArgs[5].Trim(), dateFormat, CultureInfo.InvariantCulture);
                int yearPublished = int.Parse(inputArgs[6].Trim());
                int length = int.Parse(inputArgs[7].Trim());

                IAuthor author = authorFactory.CreateAuthor(authorName, authorBday);
                IBook book = bookFactory.CreateBook(bookType, isbn, title, author, bookGenre, yearPublished, length);

                this.Books.Add(book);
            }
        }

        public void AddBook(IBook book)
        {
            this.books.Add(book);
        }

        public void RemoveBook(long isbn)
        {
            IBook bookToRemove = this.books.SingleOrDefault(b => b.ISBN == isbn);

            if (bookToRemove == null)
            {
                throw new ArgumentException(OutputMessages.BookNotFound);
            }

            this.books.Remove(bookToRemove);
        }
    }
}
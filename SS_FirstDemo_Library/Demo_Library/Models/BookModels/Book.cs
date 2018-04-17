using Demo_Library.Interfaces;
using System;

namespace Demo_Library.Models.BookModels
{
    public abstract class Book : IBook
    {
        private const int TitleMaxLength = 35;
        private const int TitleMinLength = 1;
        private const int ISBNexactLength = 13;

        private string title;
        private long isbn;
        private int length;

        protected Book(string bookType, long isbn, string title, IAuthor author, string bookGenre, int yearPublished, int length)
        {
            this.BookType = bookType;
            this.ISBN = isbn;
            this.Title = title;
            this.Author = author;
            this.BookGenre = this.validateBookGenre(bookGenre);
            this.YearPublished = yearPublished;
            this.Length = length;
        }

        public string BookType { get; }
        public long ISBN
        {
            get
            {
                return this.isbn;
            }
            private set
            {
                if (value.ToString().Length != ISBNexactLength)
                {
                    throw new ArgumentException(string.Format(OutputMessages.InvalidISBN, ISBNexactLength));
                }

                this.isbn = value;
            }
        }
        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > TitleMaxLength)
                {
                    throw new ArgumentException(string.Format(OutputMessages.InvalidTitle, TitleMinLength, TitleMaxLength));
                }

                this.title = value;
            }
        }
        public IAuthor Author { get; }
        public BookGenre BookGenre { get; }
        public int YearPublished { get; }
        public int Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(OutputMessages.InvalidBookLength));
                }
                this.length = value;
            }
        }

        private BookGenre validateBookGenre(string bookGenre)
        {
            BookGenre objBookGenre;
            bool validGenre = Enum.TryParse(bookGenre, out objBookGenre);

            if (!validGenre)
            {
                throw new ArgumentException(string.Format(OutputMessages.InvalidGenreOfBook, bookGenre,
                    BookGenre.Drama.ToString(), BookGenre.Horror.ToString(), BookGenre.Romance.ToString()));
            }

            return objBookGenre;
        }
        private string getBookTypeWithoutSuffix()
        {
            string fullType = this.GetType().Name;
            string typeWithourSuffix = fullType.Remove(fullType.LastIndexOf('B'));

            return typeWithourSuffix;
        }

        public override string ToString()
        {
            return $"ISBN: {this.ISBN}, Type: {this.getBookTypeWithoutSuffix()}" + Environment.NewLine +
                   $"Title: {this.Title}" + Environment.NewLine +
                   $"Published: {this.YearPublished}, Genre: {this.BookGenre}" + Environment.NewLine +
                   $"Author: {this.Author.Name}, born: {this.Author.DateOfBirth:dd-mm-yyyy}" + Environment.NewLine +
                   $"----------------------------------------";
        }
    }
}
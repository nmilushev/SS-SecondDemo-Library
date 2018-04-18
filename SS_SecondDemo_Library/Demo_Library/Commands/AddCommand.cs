using System;
using System.Globalization;
using Demo_Library.Interfaces;

namespace Demo_Library.Commands
{
    public class AddCommand : Command
    {
        private const string dateFormat = "yyyy/mm/dd";

        [Inject]
        private IRepository bookRepository;
        [Inject]
        private IBookFactory bookFactory;
        [Inject]
        private IAuthorFactory authorFactory;
        [Inject]
        private IReader reader;
        [Inject]
        private IWriter writer;

        public AddCommand(string commandName, IRepository bookRepository, IBookFactory bookFactory, IAuthorFactory authorFactory, IReader reader, IWriter writer) 
            : base(commandName)
        {
            this.BookRepository = bookRepository;
            this.BookFactory = bookFactory;
            this.AuthorFactory = authorFactory;
            this.Reader = reader;
            this.Writer = writer;
        }

        public IRepository BookRepository
        {
            get { return this.bookRepository; }
            private set { this.bookRepository = value; }
        }
        public IBookFactory BookFactory
        {
            get { return this.bookFactory; }
            private set { this.bookFactory = value; }
        }
        public IAuthorFactory AuthorFactory
        {
            get { return this.authorFactory; }
            private set { this.authorFactory = value; }
        }

        public IReader Reader
        {
            get { return this.reader; }
            private set { this.reader = value; }
        }

        public IWriter Writer
        {
            get { return this.writer; }
            private set { this.writer = value; }
        }

        public override string Execute()
        {
            writer.WriteLine("Book type:"); 
            string bookType = reader.ReadLine();
            writer.WriteLine(OutputMessages.InputISBN);
            long resultISBN = 0L;
            bool isValid = long.TryParse(reader.ReadLine(), out resultISBN);
            if (!isValid)
            {
                throw new ArgumentException(OutputMessages.InvalidISBN);
            }
            writer.WriteLine("Title:");
            string title = reader.ReadLine();
            writer.WriteLine("Author:");
            string authorName = reader.ReadLine();
            writer.WriteLine($"Author birthdate ({dateFormat}):");
            DateTime authorBday = DateTime.ParseExact(reader.ReadLine(), dateFormat, CultureInfo.InvariantCulture);
            writer.WriteLine("Book genre:");
            string bookGenre = reader.ReadLine();
            writer.WriteLine("Year published:");
            int yearPublished = int.Parse(reader.ReadLine());
            writer.WriteLine("Length:");
            int length = int.Parse(reader.ReadLine());

            IAuthor author = this.AuthorFactory.CreateAuthor(authorName, authorBday);
            IBook bookToAdd = this.BookFactory.CreateBook(bookType, resultISBN, title, author, bookGenre, yearPublished, length);

            this.BookRepository.AddBook(bookToAdd);

            return string.Format(OutputMessages.BookAdded, bookToAdd.Title);
        }
    }
}
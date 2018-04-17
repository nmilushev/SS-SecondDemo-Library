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

        public AddCommand(string commandName, IRepository bookRepository, IBookFactory bookFactory, IAuthorFactory authorFactory) 
            : base(commandName)
        {
            this.BookRepository = bookRepository;
            this.BookFactory = bookFactory;
            this.AuthorFactory = authorFactory;
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

        public override string Execute()
        {
            Console.WriteLine("Book type:");
            string bookType = Console.ReadLine();
            Console.WriteLine(OutputMessages.InputISBN);
            long resultISBN = 0L;
            bool isValid = long.TryParse(Console.ReadLine(), out resultISBN);
            if (!isValid)
            {
                throw new ArgumentException(OutputMessages.InvalidISBN);
            }
            Console.WriteLine("Title:");
            string title = Console.ReadLine();
            Console.WriteLine("Author:");
            string authorName = Console.ReadLine();
            Console.WriteLine($"Author birthdate ({dateFormat}):");
            DateTime authorBday = DateTime.ParseExact(Console.ReadLine(), dateFormat, CultureInfo.InvariantCulture);
            Console.WriteLine("Book genre:");
            string bookGenre = Console.ReadLine();
            Console.WriteLine("Year published:");
            int yearPublished = int.Parse(Console.ReadLine());
            Console.WriteLine("Length:");
            int length = int.Parse(Console.ReadLine());

            IAuthor author = this.AuthorFactory.CreateAuthor(authorName, authorBday);
            IBook bookToAdd = this.BookFactory.CreateBook(bookType, resultISBN, title, author, bookGenre, yearPublished, length);

            this.BookRepository.AddBook(bookToAdd);

            return string.Format(OutputMessages.BookAdded, bookToAdd.Title);
        }
    }
}
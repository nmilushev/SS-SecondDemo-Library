using System.Linq;
using Demo_Library.Interfaces;

namespace Demo_Library.Commands
{
    public class PrintCommand : Command
    {
        [Inject]
        private IRepository bookRepository;
        [Inject]
        private IReader reader;
        [Inject]
        private IWriter writer;

        public PrintCommand(string commandName, IRepository bookRepository, IReader reader, IWriter writer) 
            : base(commandName)
        {
            this.Reader = reader;
            this.Writer = writer;
            this.BookRepository = bookRepository;
        }

        public IRepository BookRepository
        {
            get { return this.bookRepository; }
            private set { this.bookRepository = value; }
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
            writer.WriteLine("all / number of books");
            string secondArgument = reader.ReadLine();
            int result;
            bool validBooksToPrint = int.TryParse(secondArgument, out result);

            if (validBooksToPrint)
            {
                writer.WriteLine();
                foreach (IBook book in this.BookRepository.Books.Take(result))
                {
                    writer.WriteLine(book.ToString());
                }
            }
            else
            {
                writer.WriteLine();
                foreach (IBook book in this.BookRepository.Books)
                {
                    writer.WriteLine(book.ToString());
                }
            }

            return null;
        }
    }
}
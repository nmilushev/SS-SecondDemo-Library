using System;
using Demo_Library.Interfaces;

namespace Demo_Library.Commands
{
    public class RemoveCommand : Command
    {
        [Inject]
        private IRepository bookRepository;
        [Inject]
        private IReader reader;
        [Inject]
        private IWriter writer;

        public RemoveCommand(string commandName, IRepository bookRepository, IReader reader, IWriter writer) 
            : base(commandName)
        {
            this.BookRepository = bookRepository;
            this.Reader = reader;
            this.Writer = writer;
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
            writer.WriteLine(OutputMessages.InputISBN);
            long resultISBN = 0L;
            bool isValid = long.TryParse(reader.ReadLine(), out resultISBN);
            if (!isValid)
            {
                throw new ArgumentException(OutputMessages.InvalidISBN);
            }
            this.BookRepository.RemoveBook(resultISBN);

            return OutputMessages.BookRemoved;
        }
    }
}
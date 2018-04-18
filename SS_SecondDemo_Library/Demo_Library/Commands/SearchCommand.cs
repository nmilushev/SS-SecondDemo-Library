using System;
using System.Collections.Generic;
using Demo_Library.BussinessLogic;
using Demo_Library.Interfaces;

namespace Demo_Library.Commands
{
    public class SearchCommand : Command
    {
        [Inject]
        private IRepository bookRepository;
        [Inject]
        private IReader reader;
        [Inject]
        private IWriter writer;

        public SearchCommand(string commandName, IRepository bookRepository, IReader reader, IWriter writer) 
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
            IBook foundBook = Algorithms.BinarySearchPerISBN(Algorithms.SortISBNMerge((List<IBook>)this.BookRepository.Books), resultISBN);
            writer.WriteLine();
            writer.WriteLine(OutputMessages.SearchDone);
            return ((foundBook == null) ? OutputMessages.BookNotFound : foundBook.ToString());
        }
    }
}
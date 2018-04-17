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
       
        public SearchCommand(string commandName, IRepository bookRepository) 
            : base(commandName)
        {
            this.BookRepository = bookRepository;
        }

        public IRepository BookRepository
        {
            get { return this.bookRepository; }
            private set { this.bookRepository = value; }
        }

        public override string Execute()
        {
            Console.WriteLine(OutputMessages.InputISBN);
            long resultISBN = 0L;
            bool isValid = long.TryParse(Console.ReadLine(), out resultISBN);
            if (!isValid)
            {
                throw new ArgumentException(OutputMessages.InvalidISBN);
            }
            IBook foundBook = Algorithms.BinarySearchPerISBN(Algorithms.SortISBNMerge((List<IBook>)this.BookRepository.Books), resultISBN);
            Console.WriteLine();
            Console.WriteLine(OutputMessages.SearchDone);
            return ((foundBook == null) ? OutputMessages.BookNotFound : foundBook.ToString());
        }
    }
}
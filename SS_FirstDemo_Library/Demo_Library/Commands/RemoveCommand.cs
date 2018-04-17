using System;
using Demo_Library.Interfaces;

namespace Demo_Library.Commands
{
    public class RemoveCommand : Command
    {
        [Inject]
        private IRepository bookRepository;
      
        public RemoveCommand(string commandName, IRepository bookRepository) 
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
            this.BookRepository.RemoveBook(resultISBN);

            return OutputMessages.BookRemoved;
        }
    }
}
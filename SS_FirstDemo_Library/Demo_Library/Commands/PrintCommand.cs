using System;
using System.Linq;
using Demo_Library.Interfaces;

namespace Demo_Library.Commands
{
    public class PrintCommand : Command
    {
        [Inject]
        private IRepository bookRepository;
       
        public PrintCommand(string commandName, IRepository bookRepository) 
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
            Console.WriteLine("all / number of books");
            string secondArgument = Console.ReadLine();
            int result;
            bool validBooksToPrint = int.TryParse(secondArgument, out result);

            if (validBooksToPrint)
            {
                Console.WriteLine();
                foreach (IBook book in this.BookRepository.Books.Take(result))
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine();
                foreach (IBook book in this.BookRepository.Books)
                {
                    Console.WriteLine(book);
                }
            }

            return null;
        }
    }
}

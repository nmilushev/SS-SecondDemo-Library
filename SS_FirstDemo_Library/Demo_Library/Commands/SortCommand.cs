using System;
using System.Collections.Generic;
using System.Diagnostics;
using Demo_Library.BussinessLogic;
using Demo_Library.Interfaces;

namespace Demo_Library.Commands
{
    public class SortCommand : Command
    {
        private Stopwatch stopwatch = new Stopwatch();
        [Inject]
        private IRepository bookRepository;
      
        public SortCommand(string commandName, IRepository bookRepository)
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
            Console.WriteLine(OutputMessages.ChooseAlgorithm);
            int chooseAlgorithm = int.Parse(Console.ReadLine());
            Console.WriteLine(OutputMessages.ChooseOrder);
            string order = Console.ReadLine().ToLower();
            if (chooseAlgorithm == 1)
            {
                stopwatch.Start();
                this.BookRepository.Books = Algorithms.SortYearBubble((IList<IBook>)this.BookRepository.Books, order);
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                return string.Format(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
            }
            else if (chooseAlgorithm == 2)
            {
                stopwatch.Start();
                this.BookRepository.Books = Algorithms.SortAuthorNameBubble((IList<IBook>)this.BookRepository.Books, order);
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                return string.Format(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
            }
            else if (chooseAlgorithm == 3)
            {
                stopwatch.Start();
                this.BookRepository.Books = Algorithms.SortYearMerge((IList<IBook>)this.BookRepository.Books, order);
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                return string.Format(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
            }
            else if (chooseAlgorithm == 4)
            {
                stopwatch.Start();
                this.BookRepository.Books = Algorithms.SortAuthorMerge((IList<IBook>)this.BookRepository.Books, order);
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                return string.Format(OutputMessages.BooksSorted, ts.Minutes, ts.Seconds, ts.Milliseconds);
            }
            else
            {
                throw new ArgumentException(OutputMessages.FunctionNotImplemented); 
            }
        } 
    }
}
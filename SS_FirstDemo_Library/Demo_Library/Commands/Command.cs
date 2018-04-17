using Demo_Library.Interfaces;

namespace Demo_Library.Commands
{
    public abstract class Command : IExecutable
    {
        private string commandName;

        protected Command(string commandName)
        {
            this.CommandName = commandName;
        }

        public string CommandName
        {
            get
            {
                return this.commandName;
            }
            private set
            {
                this.commandName = value;
            }
        }

        public abstract string Execute();
    }
}
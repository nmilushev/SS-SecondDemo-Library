using Demo_Library.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace Demo_Library.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        //private IRepository bookRepository;
        //private IAuthorFactory authorFactory;
        //private IBookFactory bookFactory;
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider/*IRepository bookRepository, IAuthorFactory authorFactory, IBookFactory bookFactory*/)
        {
            //this.bookRepository = bookRepository;
            //this.authorFactory = authorFactory;
            //this.bookFactory = bookFactory;
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string command)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == command + "command");

            if (commandType == null)
            {
                throw new NotImplementedException(OutputMessages.FunctionNotImplemented);
            }

            FieldInfo[] fieldsToInject = commandType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes
                .Any(ca => ca.AttributeType == typeof(InjectAttribute)))
                .ToArray();

            object[] injectArgs = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();
            object[] constrArgs = new object[] { command }.Concat(injectArgs).ToArray();

            IExecutable instance = (IExecutable)Activator.CreateInstance(commandType, constrArgs);

            return instance;
        }
    }
}
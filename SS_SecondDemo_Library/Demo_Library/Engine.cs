using Demo_Library.Interfaces;
using System;
using System.Linq;
using System.Reflection;


namespace Demo_Library
{
    public class Engine : IRunnable
    {
        private ICommandInterpreter commanInterpreter;
        private IReader reader;
        private IWriter writer;

        public Engine(ICommandInterpreter commanInterpreter, IReader reader, IWriter writer)
        {
            this.commanInterpreter = commanInterpreter;
            this.Reader = reader;
            this.Writer = writer;
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

        public void Run()
        {
            writer.WriteLine(OutputMessages.LibraryManagementHome);
            string command = String.Empty;
            while ((command = reader.ReadLine()) != "end")
            {
                try
                {
                    IExecutable commandResult = commanInterpreter.InterpretCommand(command);

                    MethodInfo method = typeof(IExecutable).GetMethods().First();

                    try
                    {
                        string result = (string)method.Invoke(commandResult, null);
                        writer.WriteLine(result);
                    }
                    catch (TargetInvocationException tie)
                    {
                        throw tie.InnerException;
                    }
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
                catch (NotImplementedException nie)
                {
                    writer.WriteLine(nie.Message);
                }
            }
        }
    }
}
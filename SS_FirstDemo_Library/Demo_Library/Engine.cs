using Demo_Library.Interfaces;
using System;
using System.Linq;
using System.Reflection;


namespace Demo_Library
{
    public class Engine : IRunnable
    {
        private ICommandInterpreter commanInterpreter;

        public Engine(ICommandInterpreter commanInterpreter)
        {
            this.commanInterpreter = commanInterpreter;
        }

        public void Run()
        {
            Console.WriteLine(OutputMessages.LibraryManagementHome);
            string command = String.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                try
                {
                    IExecutable commandResult = commanInterpreter.InterpretCommand(command);

                    MethodInfo method = typeof(IExecutable).GetMethods().First();

                    try
                    {
                        string result = (string)method.Invoke(commandResult, null);
                        Console.WriteLine(result);
                    }
                    catch (TargetInvocationException tie)
                    {
                        throw tie.InnerException;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (NotImplementedException nie)
                {
                    Console.WriteLine(nie.Message);
                }
            }
        }
    }
}
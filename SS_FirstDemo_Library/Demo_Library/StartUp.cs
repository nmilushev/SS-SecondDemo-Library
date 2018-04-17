using Demo_Library.Commands;
using Demo_Library.Data;
using Demo_Library.Factrories;
using Demo_Library.Interfaces;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Demo_Library
{
    class StartUp
    {
        static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IBookFactory, BookFactory>();
            services.AddTransient<IAuthorFactory, AuthorFactory>();
            services.AddSingleton<IRepository, BookRepository>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
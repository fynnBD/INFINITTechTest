using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using INFINITTechTest.Controller;
using INFINITTechTest.Controller.Interfaces;
using INFINITTechTest.Data;
using INFINITTechTest.Factories;
using INFINITTechTest.Factories.Interfaces;
using INFINITTechTest.Models;
using INFINITTechTest.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection; 
using INFINITTechTest.Repositories;
using INFINITTechTest.Repositories.Interfaces;
using INFINITTechTest.Views.Interfaces;
using Microsoft.Extensions.Hosting;

namespace INFINITTechTest
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<FileReaderView>());

        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<IHttpClientFactory, HttpClientFactory>();
                    services.AddTransient<IAPIReaderRepository, ApiReaderRepository>();
                    services.AddTransient<IFileReaderController, FileReaderController>();
                    services.AddTransient<IFileReaderModel, FileReaderModel>();
                    services.AddTransient<FileReaderView>();
                });
        }
    }
}

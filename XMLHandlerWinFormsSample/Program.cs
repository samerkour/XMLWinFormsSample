using Microsoft.Extensions.DependencyInjection;
using RACWinFormsSample.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RACWinFormsSample
{
    internal static class Program
    {
        //https://www.thecodebuzz.com/dependency-injection-windows-form-desktop-app-net-core/
        private static void ConfigureServices(ServiceCollection services)
        {
            services
                    //.AddLogging(configure => configure.AddConsole())
                    //.AddScoped<IBusinessLayer, CBusinessLayer>()                  
                    .AddSingleton<IDataProvider, DataProvider>();

            services.AddScoped<MainForm>();
            //services.AddScoped<AddProjectForm>();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }

            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
        }
    }
}

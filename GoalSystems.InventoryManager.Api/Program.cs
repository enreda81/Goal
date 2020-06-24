using GoalSystems.InventoryManager.Infrastructure.CrossCutting.Services.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace GoalSystems.InventoryManager.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            
            CreateWebHostBuilder(args).Build().Run();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


        #region Private Methods

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null)
                LoggingService.LogException(ex);
        }

        #endregion
    }
}

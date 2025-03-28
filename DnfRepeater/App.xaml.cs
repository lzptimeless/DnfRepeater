using Serilog;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Threading;

namespace DnfRepeater
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();

            Log.Information("Application started");

            // 处理未捕获的异常
            Application.Current.DispatcherUnhandledException += ProcessDispatcherUnhandledException;
            // 处理未捕获的线程异常
            AppDomain.CurrentDomain.UnhandledException += ProcessThreadUnhandledException;

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Log.Information("Application exit");
            Log.CloseAndFlush();
            base.OnExit(e);
        }

        private void ProcessThreadUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Error(e.ExceptionObject as Exception, "Unhandled exception");
            Log.CloseAndFlush();
        }

        private void ProcessDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Log.Error(e.Exception, "Unhandled exception");
            Log.CloseAndFlush();
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;

namespace MoneyTracker
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);
            
            var host = builder.Build();

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(host.Services.GetRequiredService<IConfiguration>()));
        }
    }
}

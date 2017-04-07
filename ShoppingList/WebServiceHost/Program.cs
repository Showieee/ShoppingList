using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace WebServiceHost
{
    class Program
    {
        private static ManualResetEvent quitEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Console.CancelKeyPress += Console_CancelKeyPress;

            var url = ConfigurationManager.AppSettings["Name3"];
            Console.WriteLine("Server starting at: " + url);

            WebApp.Start<Startup>(url);

            quitEvent.WaitOne();
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            quitEvent.Set();
            e.Cancel = true;
        }
    }
}

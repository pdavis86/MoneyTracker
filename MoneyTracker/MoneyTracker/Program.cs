using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyTracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //todo: where should this come from?
            string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=personal;Integrated Security=True;MultipleActiveResultSets=True"; 
            //string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=testing;Integrated Security=True;MultipleActiveResultSets=True" 
            Controller.SetDataSource(connStr); 

            Application.Run(new MainForm());
        }
    }
}

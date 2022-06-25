using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT_SCHOOL_DB_ADO_EXAMPLE_01
{
    internal static class Program
    {
        /// <summary>
        /// Точка входу у додаток
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NavigationForm());
        }
    }
}

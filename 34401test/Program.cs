using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _34401test
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

            //12-16-15
            //Setup a TestDataTable for holding freq and measurement results
            //eventually gets passed to the WriteToFile Routine and potentially the Write to SQL in future
            //Setup a TestDataTable. TestDataTable.cs class definition defines the table.
            TestDataTable myDT = new TestDataTable();

            Application.Run(new Frm34401test());
        }
    }
}

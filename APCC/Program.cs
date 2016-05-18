using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APCC
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool lRetry = true;
            bool lConnected = false;

            while (lRetry && !(lConnected))
            {
                try
                {
                    SqlConn.Connection.Open();
                    lConnected = true;
                }
                catch (Exception ex)
                {
                    DialogResult tmpResult;

                    tmpResult = MessageBox.Show("Cannot connect to database. Reconnect ?", 
                                                "Error", 
                                                MessageBoxButtons.YesNo);

                    if (tmpResult == DialogResult.No) {
                        lRetry = false;
                    }
                }
            }

            // Run aplication
            if (lConnected)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}

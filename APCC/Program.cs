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

            // Retry connecting  to database until
            // connected or abort.
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
                    string msgString = "Cannot connect to database. (Error: " + ex.Message + ") Reconnect ?";

                    tmpResult = MessageBox.Show( msgString, "Error", MessageBoxButtons.YesNo);

                    if (tmpResult == DialogResult.No) {
                        lRetry = false;
                    }
                }
            }

            // Run application
            if (lConnected)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new MainForm());
            }
        }
    }
}

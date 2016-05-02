using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APCC
{
    public sealed class LoginData
    {
        private static bool isAdmin = false;

        private static string FName = "";
        private static string LName = "";
        private static int RoleID = 0;
        private static int UserID = 0;

        // Login with role
        public static void Login(int pID)
        {
            string lStmt;

            UserID = pID;

            try
            {
                lStmt = "select usrFName, usrLName, usrRoleID from appUser where usrID = :pID";
                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);
                lCommand.Parameters.Add("pID", SqlDbType.Decimal, pID);

                SqlDataReader lDataReader = lCommand.ExecuteReader();

                while (lDataReader.Read())
                {
                    FName = lDataReader.GetString(0);
                    LName = lDataReader.GetString(1);
                    RoleID = lDataReader.GetInt32(2);
                }

                if (RoleID == 0)
                    isAdmin = true;
                else
                    isAdmin = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public static string GetUserName()
        {
            return FName + " " + LName;
        }

        // Logout
        public static void LogOut()
        {
            isAdmin = false;
        }

        public static int GetUserID()
        {
            return UserID;
        }

        // Check if current user is admin
        public static bool Admin
        {
            get
            {
                return isAdmin;
            }
        }

    }
}

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
        private static string SName = "";
        private static int RoleID = 0;
        private static int UserID = 0;

        // Login with role
        public static void Login(int pID)
        {
            string lStmt;
            UserID = pID;

            try
            {
                lStmt = "select usrFName, usrSName, usrRoleID from dbo.USERS where usrID = @pID";
                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);
                lCommand.Parameters.Add("@pID", SqlDbType.Int);
                lCommand.Parameters["@pID"].Value = pID;
                
                SqlDataReader lDataReader = lCommand.ExecuteReader();

                while (lDataReader.Read())
                {
                    FName = lDataReader.GetString(0);
                    SName = lDataReader.GetString(1);
                    RoleID = lDataReader.GetInt32(2);
                }

                //lDataReader.Close();
                // 3 is for admin 
                if (RoleID == 3)
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
            return FName + " " + SName;
        }

        // Logout
        public static void LogOut(){
            isAdmin = false;

            FName = "";
            SName = "";
            RoleID = 0;
            UserID = 0;
        }

        public static int GetUserID()
        {
            return UserID;
        }

        public static int GetUserRoleID()
        {
            return RoleID;
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

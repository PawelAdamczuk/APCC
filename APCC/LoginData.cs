using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace APCC
{
    public sealed class LoginData
    {
        //
        // VAR
        //
        private static bool isLogged = false;

        private static string FName = "";
        private static string SName = "";
        private static int RoleID = 0;
        private static int UserID = 0;
        private static string RoleName = "";

        private static Dictionary< string, AccessControl > dictPermissions = new Dictionary< string, AccessControl >();

        static LoginData() {
            getPermissions();
        }

        // Role enum
        public enum Role : int
        {
            NULL = 0,
            CONFIGURATOR = 1,
            TESTER = 2,
            ADMINISTRATOR = 3
        }

        // Access control enum
        public enum AccessControl : int
        {
            YES = 0,
            NO = 1,
            ONLY_OWN = 2
        }

        // Login with user id
        public static void Login(int pID)
        {
            string lStmt;
            UserID = pID;

            try
            {
                lStmt = @"SELECT
                             usrFName, 
                             usrSName, 
                             usrRoleID, 
                             rlsName 
                          FROM 
                             dbo.ROLES,
                             dbo.USERS 
                          WHERE 
                             usrID = @pID AND
                             rlsID = usrRoleID";
                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);

                lCommand.Parameters.Add("@pID", SqlDbType.Int);
                lCommand.Parameters["@pID"].Value = pID;

                using (SqlDataReader lDataReader = lCommand.ExecuteReader())
                {
                    while (lDataReader.Read())
                    {
                        FName = lDataReader.GetString(0);
                        SName = lDataReader.GetString(1);
                        RoleID = lDataReader.GetInt32(2);
                        RoleName = lDataReader.GetString(3);
                    }

                }

                isLogged = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            getPermissions();
        }

        // Load permissions for current Role from DataBase
        private static void getPermissions()
        { 
            string lStmt;

            try
            {
                lStmt = "SELECT * FROM getPermissionByRoleID(@pRoleID)";

                SqlCommand lCommand = new SqlCommand(lStmt, SqlConn.Connection);

                lCommand.Parameters.Add("@pRoleID", SqlDbType.Int);
                lCommand.Parameters["@pRoleID"].Value = LoginData.RoleID;
                                
                using (SqlDataReader lDataReader = lCommand.ExecuteReader())
                {
                    while (lDataReader.Read()) {
                        
                        dictPermissions[lDataReader["perName"].ToString()] = ((AccessControl)lDataReader["rlpAccessInt"]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load permissions: " + ex.ToString());
            }
        }

        // Check if user have specific permission
        public static bool havePermission(string pPerm, AccessControl pAccess)
        {
            if (!dictPermissions.ContainsKey(pPerm))
            {
                Debug.Print("havePermission(): Table does not cantain specified key " + pPerm);
                return false;
            }
            else
            {
                return ((dictPermissions[pPerm] == pAccess) ? true : false);
            }
        }

        // Logout current user
        public static void LogOut()
        {
            isLogged = false;

            FName = "";
            SName = "";
            RoleID = 0;
            UserID = 0;

            getPermissions();
        }

        public static string GetUserName()
        {
            return FName + " " + SName;
        }

        public static int GetUserID()
        {
            return UserID;
        }

        public static int GetUserRoleID()
        {
            return RoleID;
        }

        public static string GetUserRoleName()
        {
            return RoleName;
        }

        public static bool Logged
        {
            get
            {
                return isLogged;
            }
        }

    }
}

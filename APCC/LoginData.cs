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
        private static string RoleName = "";

        private static bool[] userPermissions = new bool[10];

        // Role enum
        public enum Role : int
        {
            NULL = 0,
            CONFIGURATOR = 1,
            TESTER = 2,
            ADMINISTRATOR = 3
        }

        // Permission enum
        public enum Permission : int
        {
            ADMIN_PANEL = 0,
            SHOW_COMPONENTS = 1,
            MANAGE_COMPONENTS = 2,
            SHOW_BUILDS = 3,
            SHOW_OWN_BUILDS = 4,
            MANAGE_BUILDS = 5,
            MANAGE_OWN_BUILDS = 6,
            MANAGE_BUILD_STATE = 7,
            MANAGE_OWN_BUILD_STATE = 8,
            MANAGE_OWN_ACCOUNT = 9
        }

        // Check if user have specific permission
        public static bool havePermission( Permission pPerm ) {
            return userPermissions[(int)pPerm];
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

            // Get permissions for current role
            getPermissions();
        }

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
                        userPermissions[(int)(lDataReader["rlpPerm"])] = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load permissions: " + ex.ToString());
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

            for (int i = 0; i < userPermissions.Length; i++)
                userPermissions[i] = false;
        }

        public static int GetUserID()
        {
            return UserID;
        }

        public static int GetUserRoleID()
        {
            return RoleID;
        }

        // Return name of user role
        public static string GetUserRoleName()
        {
            return RoleName;
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

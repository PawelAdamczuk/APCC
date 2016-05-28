using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace APCC
{
    public static class Utilities
    {
        // Return specific Form opened as MDI in MdiWindowForm
        // Parameters:
        //   @childType  - type of searching child
        //   @parentForm - Form to search in
        // Return:
        //   Form of given type in @parentForm
        public static Form FindMdiFormByType( Type childType, Form parentForm )
        {
            for (int i = 0; i < parentForm.MdiChildren.Count(); i++)
            {
                if (parentForm.MdiChildren.ElementAt(i).GetType() == childType)
                {
                    return parentForm.MdiChildren.ElementAt(i);
                }
            }
            return null;
        }

        public static string StringHash(string _input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(_input);
            SHA256Managed crypt = new SHA256Managed();
            byte[] hash = crypt.ComputeHash(bytes);
            string output = string.Empty;

            foreach (byte b in hash)
            {
                output += string.Format("{0:x2}", b);
            }

            return output;
        }

        public static bool TextValid(string text)
        {
            if (text.Contains(";"))
                return false;
            if (text.Contains("'"))
                return false;
            if (text.Contains("--"))
                return false;
            if (text.Contains("/"))
                return false;
            if (text.Contains("xp_"))
                return false;
            return true;
        }

        public static int PriceField(string _input)
        {
            StringBuilder price = new StringBuilder(_input);
            for (int i = 0; i < price.Length; ++i)
            {
                if (price[i] == ',')
                    price[i] = '.';
            }

            try
            {
                int priceInt = (int)(double.Parse(price.ToString(), System.Globalization.CultureInfo.InvariantCulture) * 100);
                return priceInt;
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }

        public static string getParamName(int compTypeId, int paramType, int paramNo)
        {
            string connString = String.Format("SELECT cmpParamName FROM COMPONENTS_PARAMS WHERE cmpComTypeID = {0} AND cmpParamType = {1} AND cmpParamNumber = {2}", compTypeId.ToString(), paramType.ToString(), paramNo.ToString());
            SqlCommand cmd = new SqlCommand(connString, SqlConn.Connection);
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return (string)reader["cmpParamName"];
                    }
                }
            }
            catch (SqlException ex)
            {
                return null;
            }
            return null;
         }

        public static string getComponentDescription(int id)
        {
            StringBuilder result = new StringBuilder();
            string connString = String.Format("SELECT * FROM COMPONENTS WHERE comID = {0}", id.ToString());
            SqlCommand cmd = new SqlCommand(connString, SqlConn.Connection);

            string[] fields = new string[23];
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; ++i)
                        fields[i] = reader[i].ToString();
                }
            }

            ArrayList intParamNames = new ArrayList();
            ArrayList strParamNames = new ArrayList();

            for (int i=3; i<13; ++i)
            {
                if (fields[i] == "")
                    break;

                intParamNames.Add(getParamName(int.Parse(fields[2]), 0, i - 2));
            }

            for (int i = 13; i < 23; ++i)
            {
                if (fields[i] == "")
                    break;

                strParamNames.Add(getParamName(int.Parse(fields[2]), 1, i - 12));
            }

            result.Append(fields[1] + "\n\n");


            int j = 3;
            foreach(string s in intParamNames)
            {
                result.Append(s + ": "  + fields[j++] + "\n");
            }

            j = 13;

            foreach (string s in strParamNames)
            {
                result.Append(s + ": " + fields[j++] + "\n");
            }

            return result.ToString();
        }










    }
}

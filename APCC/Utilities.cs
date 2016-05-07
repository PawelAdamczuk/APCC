using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace APCC
{
    public static class Utilities
    {
        // Is there specific Form opened as MDI in MdiWindowForm
        // @childType - type of searching child
        // @parentForm - Form to search in
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

        public static void appendToFile(string text)
        {
            var sw = File.AppendText("log.txt");
            sw.Write(text + "\n");
            sw.Close();
        }

        public static void appendToFile(SqlCommand comm)
        {
            string text = comm.CommandText;
            foreach (SqlParameter p in comm.Parameters)
            {
                text = text.Replace(p.ParameterName, p.Value.ToString());
            }
            appendToFile(text);
        }

        //public static String getComponentDescription(int id)
        //{

        //}










    }
}

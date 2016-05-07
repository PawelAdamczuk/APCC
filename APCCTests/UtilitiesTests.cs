using Microsoft.VisualStudio.TestTools.UnitTesting;
using APCC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace APCC.Tests
{
    [TestClass()]
    public class UtilitiesTests
    {
        [TestMethod()]
        public void getParamNameTest()
        {
            try
            {
                SqlConn.Connection.Open();
            }
            catch (Exception ex)
            {
            }

            Assert.AreEqual(Utilities.getParamName(10, 1, 1), "Socket");
        }

        [TestMethod()]
        public void getComponentDescriptionTest()
        {
            try
            {
                SqlConn.Connection.Open();
            }
            catch (Exception ex)
            {
            }

            Debug.WriteLine(Utilities.getComponentDescription(20));

            Assert.Fail();
        }
    }
}
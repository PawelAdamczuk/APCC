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
        public void getComponentDescriptionTest()
        {
            SqlConn.Connection.Open();
            Debug.WriteLine(Utilities.getComponentDescription(34));
            Assert.Fail();
        }
    }
}
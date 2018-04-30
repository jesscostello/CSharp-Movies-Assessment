using System;
using CSharp_Movies_Assessment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Form1 f = new Form1();
        Database d = new Database();

        [TestMethod]
        public void TestDBConection()
        {
            d.FillCustomersDGV();
        }
    }
}

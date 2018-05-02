using System;
using System.Data;
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
        public void TestCustomerSearchValue()
        {
            string searchValue = "jess";
            DataTable result = d.SearchCustomers(searchValue);
            int x = 3;
            Assert.AreEqual(x, result.Rows.Count);
        }

        [TestMethod]
        public void TestCustomerSearchNoValue()
        {
            string searchValue = "katie";
            DataTable result = d.SearchCustomers(searchValue);
            int x = 0;
            Assert.AreEqual(x, result.Rows.Count);
        }

        [TestMethod]
        public void TestCheckCopiesRentalsOut()
        {
            int MID = 9;
            int x = 1;

            Assert.AreEqual(x, d.CheckCopiesOut(MID));
        }

        [TestMethod]
        public void TestCheckCopiesNoRentals()
        {
            int MID = 3;
            int x = 0;

            Assert.AreEqual(x, d.CheckCopiesOut(MID));
        }
    }
}

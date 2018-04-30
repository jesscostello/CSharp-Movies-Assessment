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

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCustomerSearchNoValue()
        {
            string searchValue = "katie";
            DataTable result = d.SearchCustomers(searchValue);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestCustomerSearch()
        {
            string search = "jess";
            f.DisplayCustomerSearchInDGV();

            
        }
    }
}

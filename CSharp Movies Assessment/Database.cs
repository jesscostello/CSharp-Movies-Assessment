using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Movies_Assessment
{
    class Database
    {
        // Data Source=JESS-LAPTOP\SQLEXPRESS;Initial Catalog=MoviesDSED02Assess;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

        private SqlConnection myConnection = new SqlConnection();
        private SqlCommand myCommand = new SqlCommand();
        private SqlDataAdapter da = new SqlDataAdapter();

        public Database()
        {
            // connect to the Movies Database
            string connectionString =
                @"Data Source=JESS-LAPTOP\SQLEXPRESS;Initial Catalog=MoviesDSED02Assess;Integrated Security=True;";
            myConnection.ConnectionString = connectionString;
            myCommand.Connection = myConnection;
        }

        public DataTable FillCustomersDGV()
        {
            // Create a data table
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("SELECT * FROM Customers", myConnection))
            {
                // open a connection to the database
                myConnection.Open();
                // fill the datatable with the data from the SQL
                da.Fill(dt);
                // close the database connection
                myConnection.Close();
            }
            // pass the datatable data to the DGV
            return dt;
        }

        public void AddNewCustomerToDB(string firstName, string lastName, string address, string phone)
        {
            string SQL = "INSERT INTO Customers (FirstName, LastName, Address, Phone) VALUES (@First, @Last, @Address, @Phone)";

            using (da = new SqlDataAdapter(SQL, myConnection))
            {
                var myCommand = new SqlCommand(SQL, myConnection);
                // set the parameters
                myCommand.Parameters.AddWithValue("First", firstName);
                myCommand.Parameters.AddWithValue("Last", lastName);
                myCommand.Parameters.AddWithValue("Address", address);
                myCommand.Parameters.AddWithValue("Phone", phone);
                //open a connection to the DB
                myConnection.Open();
                // run the query
                myCommand.ExecuteNonQuery();
                // close the connection
                myConnection.Close();
            }
        }
    }
}

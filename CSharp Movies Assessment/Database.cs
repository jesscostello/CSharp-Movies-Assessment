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
            try
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

                MessageBox.Show("The new customer has been added to the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void EditCustomerInDB(int customerID, string firstName, string lastName, string address, string phone)
        {
            // only run if there is something in the textboxes 
            if (firstName != "" && lastName != "" && address != "" && phone != "" )
            {
                try
                {
                    string SQL = "UPDATE Customers SET FirstName = @First, LastName = @Last, Address = @Address, Phone = @Phone WHERE CustID = @Id";

                    using (da = new SqlDataAdapter(SQL, myConnection))
                    {
                        var myCommand = new SqlCommand(SQL, myConnection);
                        // set the parameters
                        myCommand.Parameters.AddWithValue("Id", customerID);
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

                    MessageBox.Show("The customer details have been edited in the database.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 
            }
            else
            {
                MessageBox.Show("Please complete all textboxes.");
            }
        }

        public void DeleteCustomer(int CustomerId)
        {
            try
            {
                string SQL = "DELETE FROM Customers WHERE CustID = @Id";

                using (da = new SqlDataAdapter(SQL, myConnection))
                {
                    var myCommand = new SqlCommand(SQL, myConnection);
                    // set the parameters
                    myCommand.Parameters.AddWithValue("Id", CustomerId);
                    //open a connection to the DB
                    myConnection.Open();
                    // run the query
                    myCommand.ExecuteNonQuery();
                    // close the connection
                    myConnection.Close();
                }

                MessageBox.Show("This customer has been deleted from the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable FillMoviesDGV()
        {
            // Create a data table
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("SELECT * FROM Movies", myConnection))
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

        public void AddNewMovieToDB(string rating, string title, string year, string cost, string copies, string plot, string genre)
        {
            try
            {
                string SQL = "INSERT INTO Movies (Rating, Title, Year, Rental_Cost, Copies, Plot, Genre) VALUES (@Rating, @Title, @Year, @Cost, @Copies, @Plot, @Genre)";

                using (da = new SqlDataAdapter(SQL, myConnection))
                {
                    var myCommand = new SqlCommand(SQL, myConnection);
                    // set the parameters
                    myCommand.Parameters.AddWithValue("Rating", rating);
                    myCommand.Parameters.AddWithValue("Title", title);
                    myCommand.Parameters.AddWithValue("Year", year);
                    myCommand.Parameters.AddWithValue("Cost", cost);
                    myCommand.Parameters.AddWithValue("Copies", copies);
                    myCommand.Parameters.AddWithValue("Plot", plot);
                    myCommand.Parameters.AddWithValue("Genre", genre);
                    //open a connection to the DB
                    myConnection.Open();
                    // run the query
                    myCommand.ExecuteNonQuery();
                    // close the connection
                    myConnection.Close();
                }

                MessageBox.Show("The new movie has been added to the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void EditMovieInDB(int movieId, string rating, string title, string year, string cost, string copies, string plot, string genre)
        {
            try
            {
                string SQL = "UPDATE Movies SET Rating = @Rating, Title = @Title, Year = @Year, Rental_Cost = @Cost, Copies = @Copies, Plot = @Plot, Genre = @Genre WHERE MovieID = @Id";
                
                using (da = new SqlDataAdapter(SQL, myConnection))
                {
                    var myCommand = new SqlCommand(SQL, myConnection);
                    // set the parameters
                    myCommand.Parameters.AddWithValue("Id", movieId);
                    myCommand.Parameters.AddWithValue("Rating", rating);
                    myCommand.Parameters.AddWithValue("Title", title);
                    myCommand.Parameters.AddWithValue("Year", year);
                    myCommand.Parameters.AddWithValue("Cost", cost);
                    myCommand.Parameters.AddWithValue("Copies", copies);
                    myCommand.Parameters.AddWithValue("Plot", plot);
                    myCommand.Parameters.AddWithValue("Genre", genre);
                    //open a connection to the DB
                    myConnection.Open();
                    // run the query
                    myCommand.ExecuteNonQuery();
                    // close the connection
                    myConnection.Close();
                }

                MessageBox.Show("The movie details have been updated in the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void DeleteMovie(int movieId)
        {
            try
            {
                string SQL = "DELETE FROM Movies WHERE MovieID = @Id";

                using (da = new SqlDataAdapter(SQL, myConnection))
                {
                    var myCommand = new SqlCommand(SQL, myConnection);
                    // set the parameters
                    myCommand.Parameters.AddWithValue("Id", movieId);
                    //open a connection to the DB
                    myConnection.Open();
                    // run the query
                    myCommand.ExecuteNonQuery();
                    // close the connection
                    myConnection.Close();
                }

                MessageBox.Show("This movie has been deleted from the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable FillRentalsDGV()
        {
            // Create a data table
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("SELECT * FROM Rentals", myConnection))
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

        public void ReturnMovie(int rentalId)
        {
            string currentDate = DateTime.Now.ToString();
            DateTime date = Convert.ToDateTime(currentDate);
            try
            {
                string SQL = "UPDATE RentedMovies SET DateReturned = @Date WHERE RMID = @Id";

                using (da = new SqlDataAdapter(SQL, myConnection))
                {
                    var myCommand = new SqlCommand(SQL, myConnection);
                    // set the parameters
                    myCommand.Parameters.AddWithValue("Id", rentalId);
                    myCommand.Parameters.AddWithValue("Date", date);
                    //open a connection to the DB
                    myConnection.Open();
                    // run the query
                    myCommand.ExecuteNonQuery();
                    // close the connection
                    myConnection.Close();
                }

                MessageBox.Show("This movie has been successfully returned.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RentOutMovie(int customer, int movie, DateTime date)
        {
            try
            {
                string SQL = "INSERT INTO RentedMovies (MovieIDFK, CustIDFK, DateRented) VALUES (@Movie, @Customer, @Date)";

                using (da = new SqlDataAdapter(SQL, myConnection))
                {
                    var myCommand = new SqlCommand(SQL, myConnection);
                    // set the parameters
                    myCommand.Parameters.AddWithValue("Customer", customer);
                    myCommand.Parameters.AddWithValue("Movie", movie);
                    myCommand.Parameters.AddWithValue("Date", date);
                    
                    //open a connection to the DB
                    myConnection.Open();
                    // run the query
                    myCommand.ExecuteNonQuery();
                    // close the connection
                    myConnection.Close();
                }

                MessageBox.Show("The movie has been issued successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable SearchCustomers(string search)
        {
            try
            {
                string searchName = search;
                string SQL = "SELECT * FROM Customers WHERE FirstName LIKE @Search";
                MessageBox.Show(searchName);
                DataTable dt = new DataTable();
                using (da = new SqlDataAdapter(SQL, myConnection))
                {
                    var myCommand = new SqlCommand(SQL, myConnection);
                    myCommand.Parameters.AddWithValue("@Search", "%" + searchName + "%");
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}

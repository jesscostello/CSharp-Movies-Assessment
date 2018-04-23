using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Movies_Assessment
{
    public partial class Form1 : Form
    {
        // todo search customers?? and movies?
        // return movie btn disabled until selection from rented movies
        // issue movie btn disabled until selection from movie and customer

        Database myDatabase = new Database();
        public int CID { get; set; }
        public int MID { get; set; }
        public int RID { get; set; }

        public Form1()
        {
            InitializeComponent();
            LoadDB();
        }

        public void LoadDB()
        {
            DisplayCustomersDGV();
            DisplayMoviesDGV();
            DisplayRentalsDGV();
        }

        private void DisplayCustomersDGV()
        {
            // Clear out any old data
            dgvCustomers.DataSource = null;
            try
            {
                dgvCustomers.DataSource = myDatabase.FillCustomersDGV();
                dgvCustomers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CustomerID = 0;
            try
            {
                CustomerID = (int) dgvCustomers.Rows[e.RowIndex].Cells[0].Value;
                txtFirstName.Text = dgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLastName.Text = dgvCustomers.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtAddress.Text = dgvCustomers.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPhone.Text = dgvCustomers.Rows[e.RowIndex].Cells[4].Value.ToString();

                lblFirst.Text = dgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString() + " ";
                lblFirst.Text += dgvCustomers.Rows[e.RowIndex].Cells[2].Value.ToString() + "    ";
                lblFirst.Text += dgvCustomers.Rows[e.RowIndex].Cells[3].Value.ToString() + "    ";
                lblFirst.Text += dgvCustomers.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // todo this is the one I want!
            CID = CustomerID;
            MakeIssueMovieButtonVisible();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;

            // call database method to add new customer
            myDatabase.AddNewCustomerToDB(firstName, lastName, address, phone);
            // refresh dgv
            DisplayCustomersDGV();
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            // collect text from text boxes and assign to variables
            int customerID = CID;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            // call the database method to edit customers
            myDatabase.EditCustomerInDB(customerID, firstName, lastName, address, phone);
            // refresh dgv
            DisplayCustomersDGV();
            // clear data from textboxes
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            int CustomerId = CID;
            // call the database method to delete customer
            myDatabase.DeleteCustomer(CustomerId);
            // refresh dgv
            DisplayCustomersDGV();
        }

        private void DisplayMoviesDGV()
        {
            // Clear out any old data
            dgvMovies.DataSource = null;
            try
            {
                dgvMovies.DataSource = myDatabase.FillMoviesDGV();
                dgvMovies.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvMovies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int MovieID = 0;

            try
            {
                MovieID = (int)dgvMovies.Rows[e.RowIndex].Cells[0].Value;
                txtTitle.Text = dgvMovies.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtGenre.Text = dgvMovies.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtYear.Text = dgvMovies.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtRating.Text = dgvMovies.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCost.Text = dgvMovies.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtCopies.Text = dgvMovies.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtPlot.Text = dgvMovies.Rows[e.RowIndex].Cells[6].Value.ToString();

                lblMovieDetails.Text = dgvMovies.Rows[e.RowIndex].Cells[2].Value.ToString() + "   ";
                lblMovieDetails.Text += dgvMovies.Rows[e.RowIndex].Cells[1].Value.ToString() + "   ";
                //lblMovieDetails.Text += dgvMovies.Rows[e.RowIndex].Cells[4].Value.ToString();
                int year = Convert.ToInt16(dgvMovies.Rows[e.RowIndex].Cells[3].Value);

                if (year >= 2013)
                {
                    lblMovieDetails.Text += "$5.00";
                }
                else
                {
                    lblMovieDetails.Text += "$2.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MID = MovieID;
            MakeIssueMovieButtonVisible();
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            // set variables from textbox fields
            string rating = txtRating.Text;
            string title = txtTitle.Text;
            string year = txtYear.Text;
            // todo set as currency
            string cost = txtCost.Text;
            string copies = txtCopies.Text;
            string plot = txtPlot.Text;
            string genre = txtGenre.Text;

            // call database method to add new movie
            myDatabase.AddNewMovieToDB(rating, title, year, cost, copies, plot, genre);
            // refresh dgv
            DisplayMoviesDGV();
        }

        private void btnEditMovie_Click(object sender, EventArgs e)
        {
            int movieID = MID;
            
            // set variables from textbox fields
            string rating = txtRating.Text;
            string title = txtTitle.Text;
            string year = txtYear.Text;
            // todo set as currency
            string cost = txtCost.Text;
            string copies = txtCopies.Text;
            string plot = txtPlot.Text;
            string genre = txtGenre.Text;

            // call database method to add new movie
            myDatabase.EditMovieInDB(movieID, rating, title, year, cost, copies, plot, genre);
            // refresh dgv
            DisplayMoviesDGV();

            // clear data from textboxes
            txtTitle.Text = "";
            txtGenre.Text = "";
            txtYear.Text = "";
            txtRating.Text = "";
            txtCost.Text = "";
            txtCopies.Text = "";
            txtPlot.Text = "";

            // highlight updated column
            //int rowID = movieID--;
            //dgvMovies.Rows[movieID].Selected = true;
        }

        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            int MovieId = MID;
            // todo are you sure you want to delete
            
            MessageBox.Show(caption:"Delete Movie", text:"Are you sure you want to delete this movie?");
            if (true)// user clicks okay
            {
                // call the database method to delete customer
                myDatabase.DeleteMovie(MovieId);
                // refresh dgv
                DisplayMoviesDGV();
            }
        }

        private void DisplayRentalsDGV()
        {
            // Clear out any old data
            dgvRentals.DataSource = null;
            try
            {
                dgvRentals.DataSource = myDatabase.FillRentalsDGV();
                dgvRentals.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            radShowAll.Checked = true;
            radShowOut.Checked = false;
        }

        private void dgvRentals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RentalID = 0;

            try
            {
                RentalID = (int)dgvRentals.Rows[e.RowIndex].Cells[0].Value;
                lblName.Text = dgvRentals.Rows[e.RowIndex].Cells[1].Value.ToString() + " ";
                lblName.Text += dgvRentals.Rows[e.RowIndex].Cells[2].Value.ToString();
                lblMovieName.Text = dgvRentals.Rows[e.RowIndex].Cells[3].Value.ToString();
                lblIssue.Text = dgvRentals.Rows[e.RowIndex].Cells[4].Value.ToString();
                btnReturn.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            RID = RentalID;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            int rentalId = RID;
            
            // call database method to return movie
            myDatabase.ReturnMovie(rentalId);
            // refresh dgv
            DisplayRentalsDGV();
            // clear data
            lblName.Text = "";
            lblMovieName.Text = "";
            lblIssue.Text = "";
            btnReturn.Visible = false;

            int rowId = rentalId--;
            // highlight updated column
            // todo change this because rows get deleted!!
            //dgvRentals.Rows[rowId].Selected = true;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int customer = CID;
            int movie = MID;
            string date = DateTime.Now.ToString();
            DateTime currentDate = Convert.ToDateTime(date);

            // call the database method to add to rented movies
            myDatabase.RentOutMovie(customer, movie, currentDate);
            // refresh rented movies dgv
            DisplayRentalsDGV();
            // show rented movies dgv
            tabControl1.SelectedIndex = 2;

            // clear data
            lblName.Text = "";
            lblMovieName.Text = "";
            lblIssue.Text = "";
            lblFirst.Text = "";
            lblMovieDetails.Text = "";
            btnIssue.Visible = false;

            // todo show recently rented movie as selected row
            dgvRentals.Rows[17].Selected = true;
            dgvRentals.FirstDisplayedScrollingRowIndex = 17;
        }

        private void MakeIssueMovieButtonVisible()
        {
            if (CID > 0 && MID > 0)
            {
                btnIssue.Visible = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //myDatabase.SearchCustomers();
            string search = txtCustSearch.Text;
            DisplayCustomerSearchInDGV();
        }

        public void DisplayCustomerSearchInDGV()
        {
            string search = txtCustSearch.Text;

            // Clear out any old data
            dgvMovies.DataSource = null;
            try
            {
                dgvCustomers.DataSource = myDatabase.SearchCustomers(search);
                dgvCustomers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radShowOut_CheckedChanged(object sender, EventArgs e)
        {
            if (radShowOut.Checked == true)
            {
                radShowAll.Checked = false;
                // Clear out any old data
                dgvRentals.DataSource = null;
                try
                {
                    dgvRentals.DataSource = myDatabase.ShowRentedOutMovies();
                    dgvRentals.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }   
        }

        private void radShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radShowAll.Checked == true)
            {
                radShowOut.Checked = false;
                DisplayRentalsDGV();
            }
        }

        private void radTopCust_CheckedChanged(object sender, EventArgs e)
        {
            if (radTopCust.Checked == true)
            {
                radAllCust.Checked = false;
                // Clear out any old data
                dgvCustomers.DataSource = null;
                try
                {
                    dgvCustomers.DataSource = myDatabase.ShowTopCustomers();
                    dgvCustomers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void radAllCust_CheckedChanged(object sender, EventArgs e)
        {
            if (radAllCust.Checked == true)
            {
                radTopCust.Checked = false;
                DisplayCustomersDGV();
            }
        }

        private void radTopMovies_CheckedChanged(object sender, EventArgs e)
        {
            if (radTopMovies.Checked == true)
            {
                radAllMovies.Checked = false;
                // Clear out any old data
                dgvMovies.DataSource = null;
                try
                {
                    dgvMovies.DataSource = myDatabase.ShowTopMovies();
                    dgvMovies.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void radAllMovies_CheckedChanged(object sender, EventArgs e)
        {
            if (radAllMovies.Checked == true)
            {
                radTopMovies.Checked = false;
                DisplayMoviesDGV();
            }
        }
    }
}
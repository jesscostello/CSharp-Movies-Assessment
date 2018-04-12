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
        // todo search customers??


        Database myDatabase = new Database();
        public int CID { get; set; }
        public int MID { get; set; }

        public Form1()
        {
            InitializeComponent();
            LoadDB();
        }

        public void LoadDB()
        {
            DisplayCustomersDGV();
            DisplayMoviesDGV();
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

            CID = CustomerID;
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
                lblMovieDetails.Text += dgvMovies.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MID = MovieID;
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

            // todo highlight new column?
        }
    }
}

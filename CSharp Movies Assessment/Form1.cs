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

        public Form1()
        {
            InitializeComponent();
            LoadDB();
        }

        public void LoadDB()
        {
            DisplayCustomersDGV();
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

                // todo Fill the next DGV???
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

        }
    }
}

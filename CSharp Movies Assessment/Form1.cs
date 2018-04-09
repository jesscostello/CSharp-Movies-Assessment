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

                if (e.RowIndex >= 0)
                {
                    // todo Fill the next DGV?

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            CID = CustomerID;
        }
    }
}

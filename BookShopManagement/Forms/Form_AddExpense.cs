using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BookShopManagement.Forms
{
    public partial class Form_AddExpense : Form
    {
        public Form_AddExpense()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete TBL_ADDEXPENSE where ExpenseTitle=@ExpenseTitle", con);
            cmd.Parameters.AddWithValue("@ExpenseTitle", txtExpenseTitle.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Successfully Deleted");
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");

        private void Form_AddExpense_Load(object sender, EventArgs e)
        {
            GetAddExpenseRecord();
        }

        private void GetAddExpenseRecord()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from TBL_ADDEXPENSE", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_ADDEXPENSE VALUES (@ExpenseTitle, @Amount, @Description)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ExpenseTitle", txtExpenseTitle.Text);
                cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                cmd.Parameters.AddWithValue("@Description", richTextBox1.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                disp_data();
                MessageBox.Show("Add Expense is Successfully Insert in the Database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TBL_ADDEXPENSE";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private bool isvalid()
        {
            if (txtExpenseTitle.Text == String.Empty)
            {
                MessageBox.Show("Author Name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtExpenseTitle.Text == String.Empty)
            {
                MessageBox.Show(" is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update TBL_ADDEXPENSE set Amount= @Amount, Description=@Description where ExpenseTitle= @ExpenseTitle", con);
            cmd.Parameters.AddWithValue("@ExpenseTitle", txtExpenseTitle.Text);
            cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
            cmd.Parameters.AddWithValue("@Description", richTextBox1.Text);


            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Successfully Updated");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from TBL_ADDEXPENSE where ExpenseTitle=@ExpenseTitle", con);
            cmd.Parameters.AddWithValue("ExpenseTitle", txtExpenseTitle.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}

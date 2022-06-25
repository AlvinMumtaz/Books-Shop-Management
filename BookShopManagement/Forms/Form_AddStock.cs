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
    public partial class Form_AddStock : Form
    {

        public Form_AddStock()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");

        private void Form_AddStock_Load(object sender, EventArgs e)
        {
            GetAddStockRecord();
        }

        private void GetAddStockRecord()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from TBL_ADDSTOCK", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_ADDSTOCK VALUES (@ExistingStock, @NewStock, @TotalStock, @CostPrice, @SellingPrice)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ExistingStock", txtExistingStock.Text);
                cmd.Parameters.AddWithValue("@NewStock", txtNewStock.Text);
                cmd.Parameters.AddWithValue("@TotalStock", txtTotalStock.Text);
                cmd.Parameters.AddWithValue("@CostPrice", txtCostPrice.Text);
                cmd.Parameters.AddWithValue("@SellingPrice", txtSellingPrice.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                disp_data();
                MessageBox.Show("Add Stock is Successfully Insert in the Database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TBL_ADDSTOCK";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private bool isvalid()
        {
            if (txtExistingStock.Text == String.Empty)
            {
                MessageBox.Show("Existing Stock is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            disp_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete TBL_ADDSTOCK where TrackingID=@TrackingID", con);
            cmd.Parameters.AddWithValue("@TrackingID", txtTrackingID.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Successfully Deleted");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update TBL_ADDSTOCK set ExistingStock= @ExistingStock, NewStock=@NewStock, TotalStock= @TotalStock, CostPrice= @CostPrice, SellingPrice= @SellingPrice where TrackingID= @TrackingID", con);
            cmd.Parameters.AddWithValue("@TrackingID", txtTrackingID.Text);
            cmd.Parameters.AddWithValue("@ExistingStock", txtExistingStock.Text);
            cmd.Parameters.AddWithValue("@NewStock", txtNewStock.Text);
            cmd.Parameters.AddWithValue("@TotalStock", txtTotalStock.Text);
            cmd.Parameters.AddWithValue("@CostPrice", txtCostPrice.Text);
            cmd.Parameters.AddWithValue("@SellingPrice", txtSellingPrice.Text);


            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Successfully Updated");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from TBL_ADDSTOCK where TrackingID=@TrackingID", con);
            cmd.Parameters.AddWithValue("TrackingID", txtTrackingID.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}

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
    public partial class Form_SellBooks : Form
    {
        public Form_SellBooks()
        {
            InitializeComponent();
        }

        private void btnAddNewBooks_Click(object sender, EventArgs e)
        {

        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {
            
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_SELLBOOKS;Integrated Security=True");

        private void Form_SellBooks_Load(object sender, EventArgs e)
        {
            GetSellBooksRecord();
        }

        private void GetSellBooksRecord()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_SELLBOOKS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from TBL_SELLBOOKS", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            SellBooksDataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            disp_data();
        }

        private void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TBL_SELLBOOKS";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            SellBooksDataGridView1.DataSource = dt;

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_SELLBOOKS;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_SELLBOOKS VALUES (@Author, @BookTitle, @Publisher, @Price, @Discount, @TotalAmount)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@BookTitle", txtBookTitle.Text);
                cmd.Parameters.AddWithValue("@Publisher", txtPublisher.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@Discount", txtDiscount.Text);
                cmd.Parameters.AddWithValue("@TotalAmount", txtTotalAmount.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                disp_data();
                MessageBox.Show("Sell Books is Successfully Insert in the Database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool isvalid()
        {
            if (txtAuthor.Text == String.Empty)
            {
                MessageBox.Show("Author Name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_SELLBOOKS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update TBL_SELLBOOKS set Author= @Author, BookTitle= @BookTitle, Publisher= @Publisher, Price= @Price, Discount= @Discount, TotalAmount= @TotalAmount where TrackingID = @TrackingID", con);
            cmd.Parameters.AddWithValue("@TrackingID", txtTrackingID.Text);
            cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
            cmd.Parameters.AddWithValue("@BookTitle", txtBookTitle.Text);
            cmd.Parameters.AddWithValue("@Publisher", txtPublisher.Text);
            cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
            cmd.Parameters.AddWithValue("@Discount", txtDiscount.Text);
            cmd.Parameters.AddWithValue("@TotalAmount", txtTotalAmount.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Successfully Updated");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_SELLBOOKS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete TBL_SELLBOOKS where TrackingID=@TrackingID", con);
            cmd.Parameters.AddWithValue("@TrackingID", int.Parse(txtTrackingID.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Successfully Deleted");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_SELLBOOKS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from TBL_SELLBOOKS where Author=@Author", con);
            cmd.Parameters.AddWithValue("Author", txtAuthor.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SellBooksDataGridView1.DataSource = dt;
        }   
    }
}

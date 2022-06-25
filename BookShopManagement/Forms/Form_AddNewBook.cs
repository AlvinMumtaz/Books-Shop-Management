using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace BookShopManagement.Forms
{
    public partial class Form_AddNewBook : Form
    {
        public Form_AddNewBook()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Form_AddCategory ac = new Form_AddCategory())
            {
                ac.ShowDialog();
            }
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_PURCHASEBOOKS;Integrated Security=True");

        private void Form_AddNewBook_Load(object sender, EventArgs e)
        {
            GetPurchaseRecord();
        }

        private void GetPurchaseRecord()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_PURCHASEBOOKS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from TBL_PURCHASEBOOKS", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            PurchaseBooksDataGridView.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_PURCHASEBOOKS;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_PURCHASEBOOKS VALUES (@Author, @Publisher, @BookTitle, @Category, @SellingPrice, @CostPrice, @Quantity, @Remarks)", con);
                cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@Publisher", txtPublisher.Text);
                cmd.Parameters.AddWithValue("@BookTitle", txtBookTitle.Text);
                cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                cmd.Parameters.AddWithValue("@SellingPrice", txtSellingPrice.Text);
                cmd.Parameters.AddWithValue("@CostPrice", txtCostPrice.Text);
                cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                disp_data();
                MessageBox.Show("Purchase Books is Successfully Insert in the Database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TBL_PURCHASEBOOKS";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            PurchaseBooksDataGridView.DataSource = dt;

            con.Close();
        }

        private bool isvalid()
        {
            if(txtAuthor.Text == String.Empty)
            {
                MessageBox.Show("Author Name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void PurchaseBooksDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_PURCHASEBOOKS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete TBL_PURCHASEBOOKS where TrackingID=@TrackingID", con);
            cmd.Parameters.AddWithValue("@TrackingID", int.Parse(txtTrackingID.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Successfully Deleted");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_PURCHASEBOOKS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update TBL_PURCHASEBOOKS set Author= @Author, Publisher= @Publisher, BookTitle= @BookTitle, Category= @Category, SellingPrice= @SellingPrice, CostPrice= @CostPrice, Quantity= @Quantity, Remarks= @Remarks where TrackingID = @TrackingID", con);
            cmd.Parameters.AddWithValue("@TrackingID", txtTrackingID.Text);
            cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
            cmd.Parameters.AddWithValue("@Publisher", txtPublisher.Text);
            cmd.Parameters.AddWithValue("@BookTitle", txtBookTitle.Text);
            cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
            cmd.Parameters.AddWithValue("@SellingPrice", txtSellingPrice.Text);
            cmd.Parameters.AddWithValue("@CostPrice", txtCostPrice.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
            cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Successfully Updated");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_PURCHASEBOOKS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from TBL_PURCHASEBOOKS where Author=@Author", con);
            cmd.Parameters.AddWithValue("Author", txtAuthor.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PurchaseBooksDataGridView.DataSource= dt;
        }
    }
}

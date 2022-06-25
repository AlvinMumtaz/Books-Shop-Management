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
    public partial class Form_AddCategory : Form
    {
        public Form_AddCategory()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");

        private void Form_AddCategory_Load(object sender, EventArgs e)
        {
            GetAddCategoryRecord();
        }

        private void GetAddCategoryRecord()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from TBL_ADDCATEGORY", con);
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
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_ADDCATEGORY VALUES (@CategoryName, @Description)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);
                cmd.Parameters.AddWithValue("@Description", richtxtDescription.Text);


                cmd.ExecuteNonQuery();
                con.Close();
                disp_data();
                MessageBox.Show("Add Category is Successfully Insert in the Database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void disp_data()
        {
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from TBL_ADDCATEGORY";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
        }

        private bool isvalid()
        {
            {
                if (txtCategoryName.Text == String.Empty)
                {
                    MessageBox.Show("Category Name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update TBL_ADDCATEGORY set Description=@Description where CategoryName= @CategoryName", con);
            cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);
            cmd.Parameters.AddWithValue("@Description", richtxtDescription.Text);


            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Successfully Updated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete TBL_ADDCATEGORY where CategoryName=@CategoryName", con);
            cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Successfully Deleted");
        }
    }
}

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
    public partial class Form_Users : Form
    {
        public Form_Users()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");

        private void Form_Users_Load(object sender, EventArgs e)
        {
            GetUsersRecord();
        }

        private void GetUsersRecord()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from TBL_USERS", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TBL_USERS VALUES (@FirstName, @LastName, @Phone, @Email, @UserName, @Password, @NoIdentity, @Role)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@NoIdentity", txtNoIdentity.Text);
                cmd.Parameters.AddWithValue("@Role", comboRole.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                disp_data();
                MessageBox.Show("Users is Successfully Insert in the Database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TBL_USERS";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private bool isvalid()
        {
            if (comboRole.Text == String.Empty)
            {
                MessageBox.Show("Role is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            disp_data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete TBL_USERS where FirstName=@FirstName", con);
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Successfully Deleted");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update TBL_USERS set LastName=@LastName, Phone= @Phone, Email= @Email, UserName= @UserName, Password= @Password, NoIdentity= @NoIdentity, Role= @Role where FirstName= @FirstName", con);
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@NoIdentity", txtNoIdentity.Text);
            cmd.Parameters.AddWithValue("@Role", comboRole.Text);


            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Successfully Updated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S7GDND6F\MUMTAZ;Initial Catalog=DB_BOOKSHOOPMANAGEMENT;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from TBL_USERS where FirstName=@FirstName", con);
            cmd.Parameters.AddWithValue("FirstName", txtFirstName.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}

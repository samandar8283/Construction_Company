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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Construction_Company
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4OPOMV2\\SQLEXPRESS;Initial Catalog=Construction_Company;Integrated Security=True;Encrypt=False");
        private void Login_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from admins where (username=@username and password=@password)", connection);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                Form3 form3 = new Form3(textBox1.Text,textBox2.Text);
                form3.Show();
                this.Hide();
            }
            else
            {
                label2.Visible = true;
            }
            connection.Close();
        }

        private void PP_Click(object sender, EventArgs e)
        {
            Entering form = new Entering();
            form.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
        }
    }
}

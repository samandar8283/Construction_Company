using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Construction_Company
{
    public partial class Director_Enter : Form
    {
        public Director_Enter()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4OPOMV2\\SQLEXPRESS;Initial Catalog=Construction_Company;Integrated Security=True;Encrypt=False");
        private void Login_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from bofd where (surname=@username and name=@password)", connection);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                BoardofDirectors form3 = new BoardofDirectors();
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

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}

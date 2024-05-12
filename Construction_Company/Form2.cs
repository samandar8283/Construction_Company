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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Construction_Company
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4OPOMV2\\SQLEXPRESS;Initial Catalog=Construction_Company;Integrated Security=True;Encrypt=False");
        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
        }

        private void BacktoLogin_Click(object sender, EventArgs e)
        {
            Customer_Enter form1 = new Customer_Enter();
            form1.Show();
            this.Hide();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            bool checker = true;
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == ""))
            {
                label2.Visible = true;
                label2.Text = "* Please fill in all fields";
                label2.ForeColor = Color.Red;
            }
            else if (textBox4.Text != textBox5.Text)
            {
                label2.Visible = true;
                label2.Text = "* Passwords Do Not Match";
                label2.ForeColor = Color.Red;
            }

            else
            {
                if (checker)
                {
                    SqlCommand cmd = new SqlCommand("(select c.username from customers c where c.username=@username) union " +
                        "(select b.username from bofd b where b.username=@username) union " +
                        "(select a.username from admins a where a.username=@username)", connection);
                    cmd.Parameters.AddWithValue("@username", textBox3.Text);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        checker = false;
                    }
                    connection.Close();
                }
                if (checker)
                {
                    string query = "insert into customers values (@username,@password,@first_name,@last_name,getdate())";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", textBox3.Text);
                    command.Parameters.AddWithValue("@password", textBox4.Text);
                    command.Parameters.AddWithValue("@first_name", textBox1.Text);
                    command.Parameters.AddWithValue("@last_name", textBox2.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    label2.Visible = true;
                    label2.Text = "User Registered Successfully";
                    label2.ForeColor = Color.Lime;


                }
                else
                {
                    label2.Visible = true;
                    label2.Text = "* This username is not available";
                    label2.ForeColor = Color.Red;
                    checker = true;
                }

            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            label2.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = false;

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = false;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = false;

        }
    }
}

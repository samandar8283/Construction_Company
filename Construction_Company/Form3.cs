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
    public partial class Form3 : Form
    {
        string username1 = "";
        string password1 = "";
        public Form3(string username, string password)
        {
            InitializeComponent();
            textBox1.Text = username;
            textBox2.Text = password;
            username1 = username;
            password1 = password;
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4OPOMV2\\SQLEXPRESS;Initial Catalog=Construction_Company;Integrated Security=True;Encrypt=False");
        private void Form3_Load(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            staff1.Visible = false;
            customers_Info1.Visible = false;
            machinery1.Visible = false;
            projects1.Visible = false;
            material1.Visible = false;
            profil1.Visible = false;


            string query = "select * from admins where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            label2.Text = dt.Rows[0][0].ToString();
            label4.Text = dt.Rows[0][3].ToString();
            label6.Text = dt.Rows[0][4].ToString();
            label12.Text = ((DateTime)dt.Rows[0][5]).ToShortDateString();
            label16.Text = ((DateTime)dt.Rows[0][7]).ToShortDateString();
            label14.Text = dt.Rows[0][6].ToString();
            label17.Visible = false;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Value = new DateTime(2001, 01, 01);
            dateTimePicker1.MaxDate = DateTime.Now.Add(new TimeSpan(-6575, 0, 0, 0, 0, 0));
            dateTimePicker2.Value = DateTime.Now;
            label39.Visible = false;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }



        private void Dashboard_Click(object sender, EventArgs e)
        {
            Dashboard.BackColor = Color.Gray;
            Staff.BackColor = Color.White;
            Customers.BackColor = Color.White;
            Projects.BackColor = Color.White;
            Profil.BackColor = Color.White;
            Logout.BackColor = Color.White;
            Material.BackColor = Color.White;
            Machinary.BackColor = Color.White;

            dashboard1.Visible = true;
            dashboard1.BringToFront();
            staff1.Visible = false;
            customers_Info1.Visible = false;
            machinery1.Visible = false;
            material1.Visible = false;
            profil1.Visible = false;
            projects1.Visible = false;
        }

        private void Staff_Click(object sender, EventArgs e)
        {
            Dashboard.BackColor = Color.White;
            Staff.BackColor = Color.Gray;
            Customers.BackColor = Color.White;
            Projects.BackColor = Color.White;
            Logout.BackColor = Color.White;
            Profil.BackColor = Color.White;
            Material.BackColor = Color.White;
            Machinary.BackColor = Color.White;

            staff1.Visible = true;
            staff1.BringToFront();
            dashboard1.Visible = false;
            customers_Info1.Visible = false;
            machinery1.Visible = false;
            profil1.Visible = false;
            material1.Visible = false;
            projects1.Visible = false;
        }
        private void Customers_Click(object sender, EventArgs e)
        {
            Dashboard.BackColor = Color.White;
            Staff.BackColor = Color.White;
            Customers.BackColor = Color.Gray;
            Projects.BackColor = Color.White;
            Logout.BackColor = Color.White;
            Profil.BackColor = Color.White;
            Material.BackColor = Color.White;
            Machinary.BackColor = Color.White;

            customers_Info1.Visible = true;
            customers_Info1.BringToFront();
            dashboard1.Visible = false;
            machinery1.Visible = false;
            staff1.Visible = false;
            profil1.Visible = false;
            material1.Visible = false;
            projects1.Visible = false;
        }
        private void Projects_Click(object sender, EventArgs e)
        {
            Dashboard.BackColor = Color.White;
            Staff.BackColor = Color.White;
            Customers.BackColor = Color.White;
            Projects.BackColor = Color.Gray;
            Logout.BackColor = Color.White;
            Profil.BackColor = Color.White;
            Material.BackColor = Color.White;
            Machinary.BackColor = Color.White;

            projects1.Visible = true;
            projects1.BringToFront();
            dashboard1.Visible = false;
            staff1.Visible = false;
            customers_Info1.Visible = false;
            profil1.Visible = false;
            machinery1.Visible = false;
            material1.Visible = false;
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Dashboard.BackColor = Color.White;
            Staff.BackColor = Color.White;
            Customers.BackColor = Color.White;
            Projects.BackColor = Color.White;
            Logout.BackColor = Color.Gray;
            Profil.BackColor = Color.White;
            Material.BackColor = Color.White;
            Machinary.BackColor = Color.White;
            Entering entering = new Entering();
            entering.Show();
            this.Hide();
        }

        private void Profil_Click(object sender, EventArgs e)
        {
            Dashboard.BackColor = Color.White;
            Staff.BackColor = Color.White;
            Customers.BackColor = Color.White;
            Projects.BackColor = Color.White;
            Logout.BackColor = Color.White;
            Profil.BackColor = Color.Gray;
            Material.BackColor = Color.White;
            Machinary.BackColor = Color.White;

            profil1.Visible = true;
            profil1.BringToFront();
            material1.Visible = false;
            dashboard1.Visible = false;
            staff1.Visible = false;
            customers_Info1.Visible = false;
            projects1.Visible = false;
            machinery1.Visible = false;
        }



        private void Machinary_Click(object sender, EventArgs e)
        {
            Dashboard.BackColor = Color.White;
            Staff.BackColor = Color.White;
            Customers.BackColor = Color.White;
            Projects.BackColor = Color.White;
            Logout.BackColor = Color.White;
            Profil.BackColor = Color.White;
            Material.BackColor = Color.White;
            Machinary.BackColor = Color.Gray;

            machinery1.Visible = true;
            machinery1.BringToFront();
            dashboard1.Visible = false;
            staff1.Visible = false;
            profil1.Visible = false;
            customers_Info1.Visible = false;
            material1.Visible = false;
            projects1.Visible = false;
        }

        private void Material_Click(object sender, EventArgs e)
        {
            Dashboard.BackColor = Color.White;
            Staff.BackColor = Color.White;
            Customers.BackColor = Color.White;
            Projects.BackColor = Color.White;
            Logout.BackColor = Color.White;
            Profil.BackColor = Color.White;
            Material.BackColor = Color.Gray;
            Machinary.BackColor = Color.White;

            material1.Visible = true;
            material1.BringToFront();
            dashboard1.Visible = false;
            staff1.Visible = false;
            profil1.Visible = false;
            customers_Info1.Visible = false;
            projects1.Visible = false;
            machinery1.Visible = false;

        }

        private void tabControl1_VisibleChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            label17.Visible = false;
            textBox1.Text = username1;
            textBox2.Text = password1;
            label39.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                label17.Visible = true;
                label17.Text = "* Please fill in all fields";
                label17.ForeColor = Color.Red;
            }
            else
            {
                if ((textBox1.Text == username1) && (textBox2.Text == password1))
                {
                    label17.Visible = true;
                    label17.Text = "* Please change username or password";
                    label17.ForeColor = Color.Red;
                }
                else if((textBox1.Text==username1)&&(textBox2.Text!=password1))
                {
                    string update = "update admins set username=@username,password=@password where id_admin=@id";
                    SqlCommand command = new SqlCommand(update, connection);
                    command.Parameters.AddWithValue("@username", textBox1.Text);
                    command.Parameters.AddWithValue("@password", textBox2.Text);
                    command.Parameters.AddWithValue("@id", label2.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    string query = "select id_admin as ID from admins where username='" + textBox1.Text + "' union " +
                    "select id_customer as ID from customers where username='" + textBox1.Text + "' union " +
                    "select id_director as ID from bofd where username='" + textBox1.Text + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    bool checker = false;
                    foreach (DataRow dr in dt.Rows)
                    {
                        checker = true;
                    }
                    if (checker)
                    {
                        label17.Visible = true;
                        label17.Text = "* Username is not available";
                        label17.ForeColor = Color.Red;
                    }
                    else
                    {
                        string update = "update admins set username=@username,password=@password where id_admin=@id";
                        SqlCommand command = new SqlCommand(update, connection);
                        command.Parameters.AddWithValue("@username", textBox1.Text);
                        command.Parameters.AddWithValue("@password", textBox2.Text);
                        command.Parameters.AddWithValue("@id", label2.Text);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.PlaceholderText = "Username";
            }
            label17.Visible = false;
        }
        string gender = "Male";

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            label17.Visible = false;
            textBox1.Text = username1;
            textBox2.Text = password1;
            label39.Visible = false;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.PlaceholderText = "Password";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == "") || (textBox7.Text == ""))
            {
                label39.Visible = true;
                label39.Text = "* Please fill in all fields";
                label39.ForeColor = Color.Red;
            }
            else
            {
                string query = "select id_admin as ID from admins where username='" + textBox6.Text + "' union " +
                    "select id_customer as ID from customers where username='" + textBox6.Text + "' union " +
                    "select id_director as ID from bofd where username='" + textBox6.Text + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                bool checker = false;
                foreach (DataRow dr in dt.Rows)
                {
                    checker = true;
                }
                if (checker)
                {
                    label39.Visible = true;
                    label39.Text = "* Username is not available";
                    label39.ForeColor = Color.Red;
                }
                else
                {
                    string query1 = "insert into admins values (@username,@password,@surname,@name,@doe,@gender,@dob)";
                    SqlCommand command = new SqlCommand(query1, connection);
                    command.Parameters.AddWithValue("@surname", textBox4.Text.ToString()[0].ToString().ToUpper() + textBox4.Text.Substring(1));
                    command.Parameters.AddWithValue("@name", textBox5.Text.ToString()[0].ToString().ToUpper() + textBox5.Text.Substring(1));
                    command.Parameters.AddWithValue("@username", textBox6.Text);
                    command.Parameters.AddWithValue("@password", textBox7.Text);
                    command.Parameters.AddWithValue("@dob", dateTimePicker1.Text);
                    command.Parameters.AddWithValue("@doe", dateTimePicker2.Text);
                    command.Parameters.AddWithValue("@gender", gender);


                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    dateTimePicker1.Value = new DateTime(2001, 01, 01);
                    dateTimePicker1.MaxDate = DateTime.Now.Add(new TimeSpan(-6575, 0, 0, 0, 0, 0));
                    dateTimePicker2.Value = DateTime.Now;
                    label39.Visible = true;
                    label39.Text = "Admin Added Successfully";
                    label39.ForeColor = Color.Lime;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            dateTimePicker1.Value = new DateTime(2001, 01, 01);
            dateTimePicker1.MaxDate = DateTime.Now.Add(new TimeSpan(-6575, 0, 0, 0, 0, 0));
            dateTimePicker2.Value = DateTime.Now;
            label39.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label39.Visible=false;
        }
    }
}

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


//Congratulations on your new house


namespace Construction_Company
{
    public partial class Customer : Form
    {
        string username1 = "";
        string password1 = "";
        public Customer(string c_username, string c_password)
        {
            InitializeComponent();
            textBox14.Text = c_username;
            textBox13.Text = c_password;
            username1 = c_username;
            password1 = c_password;
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4OPOMV2\\SQLEXPRESS;Initial Catalog=Construction_Company;Integrated Security=True;Encrypt=False");
        private void Customer_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel8.BringToFront();
            panel8.Location = new Point(345, 175);
            //panel6.Location = new Point(345, 175);
            //panel5.Location = new Point(345, 175);
            //panel4.Location = new Point(345, 175);
            label63.Visible = false;
            label64.Visible = false;
            label80.Visible = false;
            label82.Visible = false;
            label65.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label70.Visible = false;
            label71.Visible = false;
            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label75.Visible = false;
            label76.Visible = false;
            label77.Visible = false;
            label87.Visible = false;
            label83.Visible = false;
            label85.Visible = false;
            label88.Visible = false;
            label78.Visible = false;
            label79.Visible = false;
            label80.Visible = false;
            label90.Visible = false;
            label82.Visible = false;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;


            string query = "select * from customers where username='" + textBox14.Text + "' and password='" + textBox13.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            label103.Text = dt.Rows[0][0].ToString();
            label101.Text = dt.Rows[0][4].ToString();
            label99.Text = dt.Rows[0][3].ToString();
            label95.Text = ((DateTime)dt.Rows[0][5]).ToShortDateString();
            connection.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            //Application.Exit();
        }

        private void label29_Click(object sender, EventArgs e)
        {
            Entering entering = new Entering();
            entering.Show();
            this.Hide();
        }

        private void label30_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            textBox1.Clear();
            textBox3.Clear();
            textBox8.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            label75.Visible = false;
            label76.Visible = false;
            label87.Visible = false;
            label88.Visible = false;
            label77.Visible = false;
            label78.Visible = false;
            label79.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel4.BringToFront();
        }

        private void label49_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            textBox2.Clear();
            textBox4.Clear();
            textBox9.Clear();
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            label63.Visible = false;
            label64.Visible = false;
            label65.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            label80.Visible = false;
            label82.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panel5.BringToFront();
        }

        private void label59_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            textBox6.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox12.Clear();
            comboBox6.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            label70.Visible = false;
            label71.Visible = false;
            label72.Visible = false;
            label73.Visible = false;
            label74.Visible = false;
            label83.Visible = false;
            label85.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel6.BringToFront();
        }
        //residential
        private void button5_Click(object sender, EventArgs e)
        {
            if ((textBox4.Text == "") || (textBox2.Text == ""))
            {
                if (textBox2.Text == "")
                {
                    label66.Visible = true;
                    label66.ForeColor = Color.Red;
                }
                else
                {
                    label66.Visible = false;
                }
                if (textBox4.Text == "")
                {
                    label65.Visible = true;
                    label65.ForeColor = Color.Red;
                }
                else
                {
                    label65.Visible = false;
                }
            }
            else
            {
                label65.Visible = false;
                label66.Visible = false;
            }
            bool checker = false;
            SqlDataAdapter adapter = new SqlDataAdapter("select username from customers where username='" + textBox9.Text + "' and password='" + textBox10.Text + "'", connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                checker = true;
            }
            if (!checker)
            {
                label64.Visible = true;
                label64.ForeColor = Color.Red;
                label80.Visible = true;
                label80.ForeColor = Color.Red;
                label82.Visible = true;
                label82.ForeColor = Color.Red;
            }


            else
            {
                label64.Visible = false;
                label80.Visible = false;
                label82.Visible = false;
            }
            if ((!label63.Visible) && (!label67.Visible) && (!label65.Visible) && (!label66.Visible) && (!label64.Visible))
            {
                panel8.Visible = true;
                panel8.BringToFront();
                string query = "insert into sales values (@username,@phone,@floor,@rooms,@project,@price,getdate())";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", textBox9.Text);
                command.Parameters.AddWithValue("@phone", textBox4.Text);
                command.Parameters.AddWithValue("@floor", comboBox4.SelectedItem);
                command.Parameters.AddWithValue("@rooms", comboBox3.SelectedItem);
                command.Parameters.AddWithValue("project", 2);
                command.Parameters.AddWithValue("@price", label42.Text.ToString().Split(" ")[0]);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                textBox2.Clear();
                textBox4.Clear();
                textBox9.Clear();
                textBox10.Clear();
                comboBox3.SelectedIndex = 0;
                comboBox4.SelectedIndex = 0;
                checker = false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox3.Text)
            {
                case "":
                    label42.Text = "Price";
                    label63.Visible = true;
                    label63.ForeColor = Color.Red;
                    break;
                case "1":
                    label63.Visible = false;
                    label42.Text = "100000 $";
                    break;
                case "2":
                    label63.Visible = false;
                    label42.Text = "120000 $";
                    break;
                case "3":
                    label63.Visible = false;
                    label42.Text = "140000 $";
                    break;
                case "4":
                    label63.Visible = false;
                    label42.Text = "160000 $";
                    break;
                case "5":
                    label63.Visible = false;
                    label42.Text = "200000 $";
                    break;
                default:
                    label42.Text = "Price";
                    label63.Visible = true;
                    label63.ForeColor = Color.Red;
                    break;
            }
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            bool checker = true;
            for(int i = 1; i < 16; i++)
            {
                if (comboBox4.Text == ""+i+"")
                {
                    checker = false;
                    
                }                
            }
            if (checker)
            {
                label67.Visible = true;
                label67.ForeColor = Color.Red;
            }
            else
            {
                label67.Visible = false;
            }
        }


        private void button7_Click_1(object sender, EventArgs e)
        {
            panel8.Visible = false;

        }

        private void panel8_VisibleChanged(object sender, EventArgs e)
        {
            if (panel8.Visible)
            {
                button5.Enabled = false;
                button4.Enabled = false;
                button6.Enabled = false;
            }
            else
            {
                button5.Enabled = true;
                button4.Enabled = true;
                button6.Enabled = true;
            }
        }
        //city
        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox3.Text == ""))
            {
                if (textBox1.Text == "")
                {
                    label79.Visible = true;
                    label79.ForeColor = Color.Red;
                }
                else
                {
                    label79.Visible = false;
                }
                if (textBox3.Text == "")
                {
                    label76.Visible = true;
                    label76.ForeColor = Color.Red;
                }
                else
                {
                    label76.Visible = false;
                }
            }
            else
            {
                label76.Visible = false;
                label79.Visible = false;
            }
            bool checker = false;
            SqlDataAdapter adapter = new SqlDataAdapter("select username from customers where username='" + textBox8.Text + "' and password='" + textBox11.Text + "'", connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                checker = true;
            }
            if (!checker)
            {
                label77.Visible = true;
                label77.ForeColor = Color.Red;
                label87.Visible = true;
                label87.ForeColor = Color.Red;
                label88.Visible = true;
                label88.ForeColor = Color.Red;
            }


            else
            {
                label77.Visible = false;
                label87.Visible = false;
                label88.Visible = false;
            }
            if ((!label75.Visible) && (!label78.Visible) && (!label76.Visible) && (!label79.Visible) && (!label77.Visible))
            {
                panel8.Visible = true;
                panel8.BringToFront();
                string query = "insert into sales values (@username,@phone,@floor,@rooms,@project,@price,getdate())";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", textBox8.Text);
                command.Parameters.AddWithValue("@phone", textBox3.Text);
                command.Parameters.AddWithValue("@floor", comboBox1.SelectedItem);
                command.Parameters.AddWithValue("@rooms", comboBox2.SelectedItem);
                command.Parameters.AddWithValue("project", 1);
                command.Parameters.AddWithValue("@price", label36.Text.ToString().Split(" ")[0]);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                textBox1.Clear();
                textBox3.Clear();
                textBox8.Clear();
                textBox11.Clear();
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                checker = false;
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "":
                    label36.Text = "Price";
                    label78.Visible = true;
                    label78.ForeColor = Color.Red;
                    break;
                case "1":
                    label36.Text = "200000 $";
                    label78.Visible = false;
                    break;
                case "2":
                    label78.Visible = false;
                    label36.Text = "250000 $";
                    break;
                case "3":
                    label78.Visible = false;
                    label36.Text = "300000 $";
                    break;
                case "4":
                    label78.Visible = false;
                    label36.Text = "400000 $";
                    break;
                case "5":
                    label78.Visible = false;
                    label36.Text = "500000 $";
                    break;
                default:
                    label36.Text = "Price";
                    label78.Visible = true;
                    label78.ForeColor = Color.Red;
                    break;
            }
        }
        //forest
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            bool checker = true;
            for (int i = 1;i<51;i++)
            {
                if(comboBox1.Text == "" + i + "")
                {
                    checker = false;
                }
            }
            if (checker)
            {
                label75.Visible = true;
                label75.ForeColor = Color.Red;
            }
            else
            {
                label75.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((textBox5.Text == "") || (textBox7.Text == ""))
            {
                if (textBox5.Text == "")
                {
                    label71.Visible = true;
                    label71.ForeColor = Color.Red;
                }
                else
                {
                    label71.Visible = false;
                }
                if (textBox7.Text == "")
                {
                    label74.Visible = true;
                    label74.ForeColor = Color.Red;
                }
                else
                {
                    label74.Visible = false;
                }
            }
            else
            {
                label71.Visible = false;
                label74.Visible = false;
            }
            bool checker = false;
            SqlDataAdapter adapter = new SqlDataAdapter("select username from customers where username='" + textBox6.Text + "' and password='" + textBox12.Text + "'", connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                checker = true;
            }
            if (!checker)
            {
                label72.Visible = true;
                label72.ForeColor = Color.Red;
                label83.Visible = true;
                label83.ForeColor = Color.Red;
                label85.Visible = true;
                label85.ForeColor = Color.Red;
            }


            else
            {
                label72.Visible = false;
                label83.Visible = false;
                label85.Visible = false;
            }
            if ((!label71.Visible) && (!label74.Visible) && (!label70.Visible) && (!label73.Visible) && (!label72.Visible))
            {
                panel8.Visible = true;
                panel8.BringToFront();
                string query = "insert into sales values (@username,@phone,@floor,@rooms,@project,@price,getdate())";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", textBox6.Text);
                command.Parameters.AddWithValue("@phone", textBox5.Text);
                command.Parameters.AddWithValue("@floor", comboBox6.SelectedItem);
                command.Parameters.AddWithValue("@rooms", comboBox5.SelectedItem);
                command.Parameters.AddWithValue("project", 3);
                command.Parameters.AddWithValue("@price", label52.Text.ToString().Split(" ")[0]);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                textBox6.Clear();
                textBox5.Clear();
                textBox7.Clear();
                textBox12.Clear();
                comboBox6.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
                checker = false;
            }
        }

        private void comboBox5_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox5.Text)
            {
                case "":
                    label52.Text = "Price";
                    label73.Visible = true;
                    label73.ForeColor = Color.Red;
                    break;
                case "4":
                    label73.Visible = false;
                    label52.Text = "200000 $";
                    break;
                case "5":
                    label73.Visible = false;
                    label52.Text = "250000 $";
                    break;
                case "6":
                    label73.Visible = false;
                    label52.Text = "300000 $";
                    break;
                case "7":
                    label73.Visible = false;
                    label52.Text = "400000 $";
                    break;
                case "8":
                    label73.Visible = false;
                    label52.Text = "500000 $";
                    break;
                case "9":
                    label73.Visible = false;
                    label52.Text = "600000 $";
                    break;
                case "10":
                    label73.Visible = false;
                    label52.Text = "700000 $";
                    break;
                default:
                    label52.Text = "Price";
                    label73.Visible = true;
                    label73.ForeColor = Color.Red;
                    break;
            }
        }

        private void comboBox6_TextChanged(object sender, EventArgs e)
        {
            if ((comboBox6.Text == "2") || (comboBox6.Text == "3"))
            {
                label70.Visible = false;
            }
            else
            {
                label70.Visible = true;
                label70.ForeColor = Color.Red;
            }
        }

        private void label91_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
            panel7.BringToFront();
        }

        private void panel7_VisibleChanged(object sender, EventArgs e)
        {
            if (panel7.Visible)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                label2.Enabled = false;
                label29.Enabled = false;
                label91.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                label2.Enabled = true;
                label29.Enabled = true;
                label91.Enabled = true;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            label90.Visible = false;
            panel7.Visible = false;
            textBox14.Text = username1;
            textBox13.Text = password1;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            label90.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if ((textBox13.Text == "") || (textBox14.Text == ""))
            {
                label90.Visible = true;
                label90.Text = "* Please fill in all fields";
                label90.ForeColor = Color.Red;
            }

            else
            {
                if (textBox13.Text == password1 && textBox14.Text == username1)
                {
                    label90.Visible = true;
                    label90.Text = "* Please change username or password";
                    label90.ForeColor = Color.Red;
                }
                else if (textBox14.Text == username1 && textBox13.Text != password1)
                {
                    string update = "update customers set username=@username,password=@password where id_customer=@id";
                    SqlCommand command = new SqlCommand(update, connection);
                    command.Parameters.AddWithValue("@username", textBox14.Text);
                    command.Parameters.AddWithValue("@password", textBox13.Text);
                    command.Parameters.AddWithValue("@id", label103.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Customer_Enter form1 = new Customer_Enter();
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    string query = "select id_admin as ID from admins where username='" + textBox14.Text + "' union " +
                    "select id_customer as ID from customers where username='" + textBox14.Text + "' union " +
                    "select id_director as ID from bofd where username='" + textBox14.Text + "'";
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
                        label90.Visible = true;
                        label90.Text = "* Username is not available";
                        label90.ForeColor = Color.Red;
                    }
                    else
                    {
                        string update = "update customers set username=@username,password=@password where id_customer=@id";
                        SqlCommand command = new SqlCommand(update, connection);
                        command.Parameters.AddWithValue("@username", textBox14.Text);
                        command.Parameters.AddWithValue("@password", textBox13.Text);
                        command.Parameters.AddWithValue("@id", label103.Text);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Customer_Enter form1 = new Customer_Enter();
                        form1.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void panel6_VisibleChanged(object sender, EventArgs e)
        {
            if (panel6.Visible)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                label2.Enabled = false;
                label29.Enabled = false;
                label91.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                label2.Enabled = true;
                label29.Enabled = true;
                label91.Enabled = true;
            }
        }

        private void panel5_VisibleChanged(object sender, EventArgs e)
        {
            if (panel5.Visible)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                label2.Enabled = false;
                label29.Enabled = false;
                label91.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                label2.Enabled = true;
                label29.Enabled = true;
                label91.Enabled = true;
            }
        }

        private void panel4_VisibleChanged(object sender, EventArgs e)
        {
            if (panel4.Visible)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                label2.Enabled = false;
                label29.Enabled = false;
                label91.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                label2.Enabled = true;
                label29.Enabled = true;
                label91.Enabled = true;
            }
        }
    }
}

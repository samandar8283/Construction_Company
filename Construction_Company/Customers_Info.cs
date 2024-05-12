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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Construction_Company
{
    public partial class Customers_Info : UserControl
    {
        public Customers_Info()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4OPOMV2\\SQLEXPRESS;Initial Catalog=Construction_Company;Integrated Security=True;Encrypt=False");
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void StaffControl_VisibleChanged(object sender, EventArgs e)
        {
            string query = "select id_customer as [Staff ID],surname as Surname,name as Name, username as Username, password as Password,reg_date as [Registration Date] from customers";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            comboBox1.SelectedIndex = 0;


            string sales = "select username as Username,phone as Phone,project_name as Project, (convert(varchar,floor)+' floor, '+convert(varchar,rooms)+' rooms') "+
                " as Apartment, convert(varchar,price)+' $' as Price,sale_date as [Sale Date] from sales,projects where project=id_project";
            DataTable dt1 = new DataTable();
            SqlDataAdapter adapter1 = new SqlDataAdapter(sales, connection);
            adapter1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            StaffControl.SelectedTab = tabPage4;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var n = e.RowIndex;
            if (n >= 0)
            {
                textBox1.Text = dataGridView1.Rows[n].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[n].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[n].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[n].Cells[4].Value.ToString();
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                string query = "select id_customer as [Staff ID],surname as Surname,name as Name, username as Username, password as Password,reg_date as [Registration Date] from customers";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                string name_combo = "";
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        name_combo = "id_customer";
                        break;
                    case 1:
                        name_combo = "surname";
                        break;
                    case 2:
                        name_combo = "name";
                        break;
                    case 3:
                        name_combo = "username";
                        break;
                    case 4:
                        name_combo = "password";
                        break;
                }
                string query = "(select id_customer as [Staff ID],surname as Surname,name as Name, username as Username, password as Password,reg_date as [Registration Date] from customers where " + name_combo + " like '%" + textBox6.Text + "%')";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //string sales = "select username as Username,phone as Phone,Project as project, (convert(varchar,floor)+' floor, '+convert(varchar,rooms)+' rooms') as Apartment, convert(varchar,price)+' $' as Price,sale_date as [Sale Date] from sales";
            string sales = "select username as Username,phone as Phone,project_name as Project, (convert(varchar,floor)+' floor, '+convert(varchar,rooms)+' rooms') " +
                " as Apartment, convert(varchar,price)+' $' as Price,sale_date as [Sale Date] from sales,projects where project=id_project";
            DataTable dt1 = new DataTable();
            SqlDataAdapter adapter1 = new SqlDataAdapter(sales, connection);
            adapter1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            button5.BackColor = Color.Gray;
            button6.BackColor = Color.White;
            button3.BackColor = Color.White;
            button2.BackColor = Color.White;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //string sales = "select username as Username,phone as Phone,Project as project, (convert(varchar,floor)+' floor, '+convert(varchar,rooms)+' rooms') as Apartment, convert(varchar,price)+' $' as Price,sale_date as [Sale Date] from sales " +
            //"where project='JAS City Complex'";
            string sales = "select username as Username,phone as Phone,project_name as Project, (convert(varchar,floor)+' floor, '+convert(varchar,rooms)+' rooms') " +
                " as Apartment, convert(varchar,price)+' $' as Price,sale_date as [Sale Date] from sales,projects where project=id_project and project=1";
            DataTable dt1 = new DataTable();
            SqlDataAdapter adapter1 = new SqlDataAdapter(sales, connection);
            adapter1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            button5.BackColor = Color.White;
            button6.BackColor = Color.Gray;
            button3.BackColor = Color.White;
            button2.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string sales = "select username as Username,phone as Phone,Project as project, (convert(varchar,floor)+' floor, '+convert(varchar,rooms)+' rooms') as Apartment, convert(varchar,price)+' $' as Price,sale_date as [Sale Date] from sales " +
            //    "where project='JAS Residential Complex'";
            string sales = "select username as Username,phone as Phone,project_name as Project, (convert(varchar,floor)+' floor, '+convert(varchar,rooms)+' rooms') " +
                " as Apartment, convert(varchar,price)+' $' as Price,sale_date as [Sale Date] from sales,projects where project=id_project and project=2";
            DataTable dt1 = new DataTable();
            SqlDataAdapter adapter1 = new SqlDataAdapter(sales, connection);
            adapter1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button3.BackColor = Color.Gray;
            button2.BackColor = Color.White;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //string sales = "select username as Username,phone as Phone,Project as project, (convert(varchar,floor)+' floor, '+convert(varchar,rooms)+' rooms') as Apartment, convert(varchar,price)+' $' as Price,sale_date as [Sale Date] from sales " +
            //    "where project='JAS Forest Houses'";
            string sales = "select username as Username,phone as Phone,project_name as Project, (convert(varchar,floor)+' floor, '+convert(varchar,rooms)+' rooms') " +
                " as Apartment, convert(varchar,price)+' $' as Price,sale_date as [Sale Date] from sales,projects where project=id_project and project=3";
            DataTable dt1 = new DataTable();
            SqlDataAdapter adapter1 = new SqlDataAdapter(sales, connection);
            adapter1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button3.BackColor = Color.White;
            button2.BackColor = Color.Gray;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var n = e.RowIndex;
            if (n >= 0)
            {
                textBox7.Text = dataGridView2.Rows[n].Cells[0].Value.ToString();
                textBox8.Text = dataGridView2.Rows[n].Cells[1].Value.ToString();
                textBox9.Text = dataGridView2.Rows[n].Cells[2].Value.ToString();
                textBox10.Text = dataGridView2.Rows[n].Cells[3].Value.ToString();
                textBox11.Text = dataGridView2.Rows[n].Cells[4].Value.ToString();
                textBox12.Text = dataGridView2.Rows[n].Cells[5].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
        }

        private void StaffControl_Selected(object sender, TabControlEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            //string sales = "select username as Username,phone as Phone,Project as project, (convert(varchar,floor)+' floor, '+convert(varchar,rooms)+' rooms') as Apartment, convert(varchar,price)+' $' as Price,sale_date as [Sale Date] from sales";
            string sales = "select username as Username,phone as Phone,project_name as Project, (convert(varchar,floor)+' floor, '+convert(varchar,rooms)+' rooms') " +
                " as Apartment, convert(varchar,price)+' $' as Price,sale_date as [Sale Date] from sales,projects where project=id_project";
            DataTable dt1 = new DataTable();
            SqlDataAdapter adapter1 = new SqlDataAdapter(sales, connection);
            adapter1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            button5.BackColor=Color.Gray;
            button6.BackColor = Color.White;
            button3.BackColor = Color.White;
            button2.BackColor = Color.White;

            string query = "select id_customer as [Staff ID],surname as Surname,name as Name, username as Username, password as Password,reg_date as [Registration Date] from customers";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            comboBox1.SelectedIndex = 0;
        }
    }
}

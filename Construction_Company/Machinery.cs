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
    public partial class Machinery : UserControl
    {
        public Machinery()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4OPOMV2\\SQLEXPRESS;Initial Catalog=Construction_Company;Integrated Security=True;Encrypt=False");

        private void tabControl1_VisibleChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            All.BackColor = Color.Gray;
            City.BackColor = Color.White;
            Residential.BackColor = Color.White;
            Houses.BackColor = Color.White;
            string query = "select id_expense as [Expense ID],project_name as Project,machinery_name as Name,amount as Amount, " +
                "convert(varchar,total_cost)+' $' as [Total Cost],expense_date as [Expense Date] from expense,projects,machinery " +
                "where expense.project=projects.id_project and expense.name=machinery.id_machinery and expense.type='mach'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            string query = "select * from projects";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            comboBox1.DataSource = dataTable;
            comboBox1.ValueMember = "id_project";
            comboBox1.DisplayMember = "project_name";
            comboBox1.SelectedIndex = 0;

            string query1 = "select* from machinery";
            SqlDataAdapter adapter1 = new SqlDataAdapter(query1, connection);
            DataTable dataTable1 = new DataTable();
            adapter1.Fill(dataTable1);
            comboBox2.DataSource = dataTable1;
            comboBox2.ValueMember = "id_machinery";
            comboBox2.DisplayMember = "machinery_name";
            comboBox2.SelectedIndex = 0;
            pictureBox10.Image = Image.FromFile("Machinery/machinery_1.png");

            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            label4.Visible = false;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            All.BackColor = Color.Gray;
            City.BackColor = Color.White;
            Residential.BackColor = Color.White;
            Houses.BackColor = Color.White;
            string query2 = "select id_expense as [Expense ID],project_name as Project,machinery_name as Name,amount as Amount, " +
                "convert(varchar,total_cost)+' $' as [Total Cost],expense_date as [Expense Date] from expense,projects,machinery " +
                "where expense.project=projects.id_project and expense.name=machinery.id_machinery and expense.type='mach'";
            SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            label4.Visible = false;
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
                textBox6.Text = ((DateTime)(dataGridView1.Rows[n].Cells[5].Value)).ToShortDateString();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string image = "Machinery/machinery_";


            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    pictureBox10.Image = Image.FromFile(image + "1.png");
                    break;
                case 1:
                    pictureBox10.Image = Image.FromFile(image + "2.png");
                    break;
                case 2:
                    pictureBox10.Image = Image.FromFile(image + "3.png");
                    break;
                case 3:
                    pictureBox10.Image = Image.FromFile(image + "4.png");
                    break;
                case 4:
                    pictureBox10.Image = Image.FromFile(image + "5.png");
                    break;
                case 5:
                    pictureBox10.Image = Image.FromFile(image + "6.png");
                    break;
                case 6:
                    pictureBox10.Image = Image.FromFile(image + "7.png");
                    break;
                case 7:
                    pictureBox10.Image = Image.FromFile(image + "8.png");
                    break;
                case 8:
                    pictureBox10.Image = Image.FromFile(image + "9.png");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox7.Text == "") || (textBox8.Text == ""))
            {
                label4.Visible = true;
                label4.Text = "* Please fill in all fields";
                label4.ForeColor = Color.Red;
            }
            else
            {
                string save = "insert into expense values(@project_id,'mach',@name_id,@amount,@total_cost,getdate())";
                SqlCommand sqlCommand = new SqlCommand(save, connection);
                sqlCommand.Parameters.AddWithValue("project_id", comboBox1.SelectedValue);
                sqlCommand.Parameters.AddWithValue("name_id", comboBox2.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@amount", textBox7.Text);
                sqlCommand.Parameters.AddWithValue("@total_cost", textBox9.Text);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                label4.Visible = true;
                label4.Text = "Expense Added Successfully";
                label4.ForeColor = Color.Lime;
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if ((textBox7.Text == "") || (textBox8.Text == ""))
            {
                textBox9.Text = "";
            }
            else
            {
                textBox9.Text = (Convert.ToInt32(textBox7.Text) * Convert.ToInt32(textBox8.Text)).ToString();
            }
            label4.Visible=false;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if ((textBox7.Text == "") || (textBox8.Text == ""))
            {
                textBox9.Text = "";
            }
            else
            {
                textBox9.Text = (Convert.ToInt32(textBox7.Text) * Convert.ToInt32(textBox8.Text)).ToString();
            }
            label4.Visible = false;
        }

        private void All_Click(object sender, EventArgs e)
        {
            string query2 = "select id_expense as [Expense ID],project_name as Project,machinery_name as Name,amount as Amount, " +
                "convert(varchar,total_cost)+' $' as [Total Cost],expense_date as [Expense Date] from expense,projects,machinery " +
                "where expense.project=projects.id_project and expense.name=machinery.id_machinery and expense.type='mach'";
            SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            All.BackColor = Color.Gray;
            City.BackColor = Color.White;
            Residential.BackColor = Color.White;
            Houses.BackColor = Color.White;
        }

        private void City_Click(object sender, EventArgs e)
        {
            string query2 = "select id_expense as [Expense ID],project_name as Project,machinery_name as Name,amount as Amount, " +
                "convert(varchar,total_cost)+' $' as [Total Cost],expense_date as [Expense Date] from expense,projects,machinery " +
                "where expense.project=projects.id_project and expense.name=machinery.id_machinery and expense.type='mach' and project=1";
            SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            All.BackColor = Color.White;
            City.BackColor = Color.Gray;
            Residential.BackColor = Color.White;
            Houses.BackColor = Color.White;
        }

        private void Residential_Click(object sender, EventArgs e)
        {
            string query2 = "select id_expense as [Expense ID],project_name as Project,machinery_name as Name,amount as Amount, " +
                "convert(varchar,total_cost)+' $' as [Total Cost],expense_date as [Expense Date] from expense,projects,machinery " +
                "where expense.project=projects.id_project and expense.name=machinery.id_machinery and expense.type='mach' and project=2";
            SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            All.BackColor = Color.White;
            City.BackColor = Color.White;
            Residential.BackColor = Color.Gray;
            Houses.BackColor = Color.White;
        }

        private void Houses_Click(object sender, EventArgs e)
        {
            string query2 = "select id_expense as [Expense ID],project_name as Project,machinery_name as Name,amount as Amount, " +
                "convert(varchar,total_cost)+' $' as [Total Cost],expense_date as [Expense Date] from expense,projects,machinery " +
                "where expense.project=projects.id_project and expense.name=machinery.id_machinery and expense.type='mach' and project=3";
            SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            All.BackColor = Color.White;
            City.BackColor = Color.White;
            Residential.BackColor = Color.White;
            Houses.BackColor = Color.Gray;
        }
    }
}

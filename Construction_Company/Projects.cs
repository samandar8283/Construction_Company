using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Construction_Company
{
    public partial class Projects : UserControl
    {
        public Projects()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4OPOMV2\\SQLEXPRESS;Initial Catalog=Construction_Company;Integrated Security=True;Encrypt=False");

        private void StaffControl_Selected(object sender, TabControlEventArgs e)
        {
            Inform.Visible = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            C_textBox1.Clear();
            C_textBox2.Clear();
            C_textBox3.Clear();
            C_textBox4.Clear();
            C_textBox5.Clear();
            C_textBox6.Clear();
            R_textBox1.Clear();
            R_textBox2.Clear();
            R_textBox3.Clear();
            R_textBox4.Clear();
            R_textBox5.Clear();
            R_textBox6.Clear();
            H_textBox1.Clear();
            H_textBox2.Clear();
            H_textBox3.Clear();
            H_textBox4.Clear();
            H_textBox5.Clear();
            H_textBox6.Clear();

            string combobox_data = "select id_project,project_name from projects";
            SqlDataAdapter adapter1 = new SqlDataAdapter(combobox_data, connection);
            DataTable dt2 = new DataTable();
            adapter1.Fill(dt2);
            comboBox2.DataSource = dt2;
            comboBox2.ValueMember = "id_project";
            comboBox2.DisplayMember = "project_name";
            label6.Visible = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Value = new DateTime(2001, 01, 01);
            dateTimePicker1.MaxDate = DateTime.Now.Add(new TimeSpan(-6575, 0, 0, 0, 0, 0));

            string query = "select id_contractor as [Contractor ID],last_name as Surname,first_name as Name, phone_number as Phone, email as Email,convert(varchar,contract_amount)+' $' as [Contract Amount],project_name as Project from contractors,Projects where project=id_project";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            string query_c = "select id_contractor as [Contractor ID],last_name as Surname,first_name as Name,phone_number as Phone, email as Email,convert(varchar,contract_amount)+' $' as [Contract Amount] from contractors,Projects where project=id_project and id_project=1";
            DataTable dt_c = new DataTable();
            SqlDataAdapter adapter_c = new SqlDataAdapter(query_c, connection);
            adapter_c.Fill(dt_c);
            dataGridView2.DataSource = dt_c;

            string query_r = "select id_contractor as [Contractor ID],last_name as Surname,first_name as Name,phone_number as Phone, email as Email,convert(varchar,contract_amount)+' $' as [Contract Amount] from contractors,Projects where project=id_project and id_project=2";
            DataTable dt_r = new DataTable();
            SqlDataAdapter adapter_r = new SqlDataAdapter(query_r, connection);
            adapter_r.Fill(dt_r);
            dataGridView4.DataSource = dt_r;

            string query_h = "select id_contractor as [Contractor ID],last_name as Surname,first_name as Name,phone_number as Phone, email as Email,convert(varchar,contract_amount)+' $' as [Contract Amount] from contractors,Projects where project=id_project and id_project=3";
            DataTable dt_h = new DataTable();
            SqlDataAdapter adapter_h = new SqlDataAdapter(query_h, connection);
            adapter_h.Fill(dt_h);
            dataGridView5.DataSource = dt_h;


            string sale_cs = " select sum(price) from Sales where project = 1";
            DataTable dt_cs = new DataTable();
            SqlDataAdapter adapter_cs = new SqlDataAdapter(sale_cs, connection);
            adapter_cs.Fill(dt_cs);
            C_Sales.Text = dt_cs.Rows[0][0].ToString() + " $";

            string sale_rs = " select sum(price) from Sales where project = 2";
            DataTable dt_rs = new DataTable();
            SqlDataAdapter adapter_rs = new SqlDataAdapter(sale_rs, connection);
            adapter_rs.Fill(dt_rs);
            R_Sales.Text = dt_rs.Rows[0][0].ToString() + " $";

            string sale_hs = " select sum(price) from Sales where project = 3";
            DataTable dt_hs = new DataTable();
            SqlDataAdapter adapter_hs = new SqlDataAdapter(sale_hs, connection);
            adapter_hs.Fill(dt_hs);
            H_Sales.Text = dt_hs.Rows[0][0].ToString() + " $";
        }

        private void StaffControl_VisibleChanged(object sender, EventArgs e)
        {
            string query = "select id_contractor as [Contractor ID],last_name as Surname,first_name as Name, phone_number as Phone, email as Email,convert(varchar,contract_amount)+' $' as [Contract Amount], project_name as Project from contractors,Projects where project=id_project";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            Inform.Visible = false;
            Inform.Visible = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            StaffControl.SelectedTab = tabPage4;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if ((textBox7.Text == "") || (textBox8.Text == "") || (textBox9.Text == "") || (textBox10.Text == "") || (textBox11.Text == ""))
            {
                label6.Visible = true;
                label6.Text = "* Please fill in all fields";
                label6.ForeColor = Color.Red;
            }
            else
            {
                //int id_staff = 0;
                string query = "insert into contractors values (@first_name,@last_name,@dob,@doe,@phone,@email,@gender,@contract_amount,@project)";
                SqlCommand command = new SqlCommand(query, connection);
                //command.Parameters.AddWithValue("@first_name", textBox8.Text);
                command.Parameters.AddWithValue("@first_name", textBox8.Text.ToString()[0].ToString().ToUpper() + textBox8.Text.Substring(1));
                command.Parameters.AddWithValue("@last_name", textBox7.Text.ToString()[0].ToString().ToUpper() + textBox7.Text.Substring(1));
                //command.Parameters.AddWithValue("@last_name", textBox7.Text);
                command.Parameters.AddWithValue("@phone", textBox9.Text);
                command.Parameters.AddWithValue("@dob", dateTimePicker1.Text);
                command.Parameters.AddWithValue("@doe", dateTimePicker2.Text);
                command.Parameters.AddWithValue("@gender", gender);
                command.Parameters.AddWithValue("@project", comboBox2.SelectedValue);
                command.Parameters.AddWithValue("@email", textBox10.Text);
                command.Parameters.AddWithValue("@contract_amount", int.Parse(textBox11.Text));


                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                label6.Visible = true;
                label6.Text = "Contractor Added Successfully";
                label6.ForeColor = Color.Lime;
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                dateTimePicker1.Value = new DateTime(2001, 01, 01);
                dateTimePicker1.MaxDate = DateTime.Now.Add(new TimeSpan(-6575, 0, 0, 0, 0, 0));
            }
        }
        string gender = "Male";
        private void Male_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void Female_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            dateTimePicker1.Value = new DateTime(2001, 01, 01);
            dateTimePicker1.MaxDate = DateTime.Now.Add(new TimeSpan(-6575, 0, 0, 0, 0, 0));
            label6.Visible = false;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Inform.Visible = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void C_Reset_Click(object sender, EventArgs e)
        {
            C_textBox1.Clear();
            C_textBox2.Clear();
            C_textBox3.Clear();
            C_textBox4.Clear();
            C_textBox5.Clear();
            C_textBox6.Clear();
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
                textBox6.Text = dataGridView1.Rows[n].Cells[5].Value.ToString();
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                Inform.Visible = true;
                Inform.Text = "* Please Select Contractor";
                Inform.ForeColor = Color.Red;
            }
            else if ((textBox4.Text == "") || (textBox5.Text == ""))
            {
                Inform.Visible = true;
                Inform.Text = "* Please fill in all fields";
                Inform.ForeColor = Color.Red;
            }
            else
            {
                string query1 = "update contractors set  first_name=@ism, last_name=@fam, phone_number=@tel, email=@email,contract_amount=@amount where id_contractor=@id";

                SqlCommand cmd = new SqlCommand(query1, connection);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@ism", textBox3.Text);
                cmd.Parameters.AddWithValue("@fam", textBox2.Text);
                cmd.Parameters.AddWithValue("@tel", textBox4.Text);
                cmd.Parameters.AddWithValue("@email", textBox5.Text);
                cmd.Parameters.AddWithValue("@amount", textBox6.Text.ToString().Split(" ")[0]);
                connection.Open();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                cmd.ExecuteNonQuery();
                connection.Close();
                Inform.Visible = true;
                Inform.Text = "Contractor Updated Successfully";
                Inform.ForeColor = Color.Lime;
                string query = "select id_contractor as [Contractor ID],last_name as Surname,first_name as Name, phone_number as Phone, email as Email,convert(varchar,contract_amount)+' $' as [Contract Amount],project_name as Project from contractors,Projects where project=id_project";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var n = e.RowIndex;
            if (n >= 0)
            {
                C_textBox1.Text = dataGridView2.Rows[n].Cells[0].Value.ToString();
                C_textBox2.Text = dataGridView2.Rows[n].Cells[1].Value.ToString();
                C_textBox3.Text = dataGridView2.Rows[n].Cells[2].Value.ToString();
                C_textBox4.Text = dataGridView2.Rows[n].Cells[3].Value.ToString();
                C_textBox5.Text = dataGridView2.Rows[n].Cells[4].Value.ToString();
                C_textBox6.Text = dataGridView2.Rows[n].Cells[5].Value.ToString();
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var n = e.RowIndex;
            if (n >= 0)
            {
                R_textBox1.Text = dataGridView4.Rows[n].Cells[0].Value.ToString();
                R_textBox2.Text = dataGridView4.Rows[n].Cells[1].Value.ToString();
                R_textBox3.Text = dataGridView4.Rows[n].Cells[2].Value.ToString();
                R_textBox4.Text = dataGridView4.Rows[n].Cells[3].Value.ToString();
                R_textBox5.Text = dataGridView4.Rows[n].Cells[4].Value.ToString();
                R_textBox6.Text = dataGridView4.Rows[n].Cells[5].Value.ToString();
            }
        }

        private void R_Reset_Click(object sender, EventArgs e)
        {
            R_textBox1.Clear();
            R_textBox2.Clear();
            R_textBox3.Clear();
            R_textBox4.Clear();
            R_textBox5.Clear();
            R_textBox6.Clear();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var n = e.RowIndex;
            if (n >= 0)
            {
                H_textBox1.Text = dataGridView5.Rows[n].Cells[0].Value.ToString();
                H_textBox2.Text = dataGridView5.Rows[n].Cells[1].Value.ToString();
                H_textBox3.Text = dataGridView5.Rows[n].Cells[2].Value.ToString();
                H_textBox4.Text = dataGridView5.Rows[n].Cells[3].Value.ToString();
                H_textBox5.Text = dataGridView5.Rows[n].Cells[4].Value.ToString();
                H_textBox6.Text = dataGridView5.Rows[n].Cells[5].Value.ToString();
            }
        }

        private void H_Reset_Click(object sender, EventArgs e)
        {
            H_textBox1.Clear();
            H_textBox2.Clear();
            H_textBox3.Clear();
            H_textBox4.Clear();
            H_textBox5.Clear();
            H_textBox6.Clear();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Inform.Visible = false;
        }
    }
}

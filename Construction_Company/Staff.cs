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
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace Construction_Company
{
    public partial class Staff : UserControl
    {
        public Staff()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4OPOMV2\\SQLEXPRESS;Initial Catalog=Construction_Company;Integrated Security=True;Encrypt=False");
        private void StaffControl_Selected(object sender, TabControlEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker1.Value = new DateTime(2001, 01, 01);
            dateTimePicker1.MaxDate = DateTime.Now.Add(new TimeSpan(-6575, 0, 0, 0, 0, 0));
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            Staffid.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox23.Clear();
            textBox24.Clear();
            textBox25.Clear();
            textBox26.Clear();
            textBox27.Clear();
            textBox22.Clear();
            textBox28.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            label7.Visible = false;
            string query = "select id_staff as [Staff ID],last_name as Surname,first_name as Name, phone as Phone, email as Email,dob as DateofBirth,doe as [DateofEmployee ] from staff";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            comboBox2.SelectedIndex = 0;
            string combobox_data = "select id_pos,name_pos from positions";
            SqlDataAdapter adapter1 = new SqlDataAdapter(combobox_data, connection);
            DataTable dt2 = new DataTable();
            adapter1.Fill(dt2);
            comboBox1.DataSource = dt2;
            comboBox1.ValueMember = "id_pos";
            comboBox1.DisplayMember = "name_pos";
            label6.Visible = false;
            label50.Visible = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "M";
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            //dateTimePicker1.Format=dateTimePicker1.CustomFormat;



            string salary = "select s.id_staff  as [Staff ID],s.last_name as Surname,s.first_name as Name,Convert(varchar,p.salary)+' $' " +
                    "as Salary, Convert(varchar, sum(b.bonus))+' $' as [Total Bonuses],Convert(varchar, datediff(month, s.doe, getdate()) * p.salary + sum(b.bonus)) + ' $' as [Total Salary] " +
                    "from staff s,Positions p, Bonus b where s.id_staff = b.id_staff and s.position = p.id_pos and s.id_staff = b.id_staff " +
                    "group by b.id_staff,s.id_staff,s.last_name,s.first_name,p.salary,s.doe";
            DataTable dt1 = new DataTable();
            SqlDataAdapter adapter2 = new SqlDataAdapter(salary, connection);
            adapter2.Fill(dt1);
            dataGridView2.DataSource = dt1;


            string ex_staff = "select id_ex_staffer as [Ex-Staff ID],last_name as Surname,first_name as Name, phone as Phone, email as Email,convert(varchar,total_salary)+' $' as [Total Salary] from ex_staffers";
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter2 = new SqlDataAdapter(ex_staff, connection);
            dataAdapter2.Fill(dataTable);
            dataGridView4.DataSource = dataTable;

            string bonus = "select b.id_staff as [Staff ID],s.last_name as Surname,s.first_name as Name,Convert(varchar,b.bonus)+' $' as Bonus,b.bonus_date as [Bonus Date] from staff s, bonus b where s.id_staff=b.id_staff and b.bonus!=0";
            DataTable bonusTable = new DataTable();
            SqlDataAdapter bonusadapter = new SqlDataAdapter(bonus, connection);
            bonusadapter.Fill(bonusTable);
            dataGridView5.DataSource = bonusTable;

            button11.Visible = false;
            button14.Visible = false;
            textBox29.Visible = false;
            pictureBox125.Visible = false;
            pictureBox126.Visible = false;
            pictureBox127.Visible = false;
            pictureBox128.Visible = false;
            label35.Text = "Staff ID";
            label34.Text = "Last Name";
            label33.Text = "First Name";
            label30.Text = "Bonus Amount";
            label32.Text = "Tax";
            label26.Text = "Net Bonus";
            label24.Text = "Payment Date";
            label15.Text = "Staff ID";
            label14.Text = "Last Name";
            label12.Text = "First Name";
            label13.Text = "Salary";
            label17.Text = "Tax";
            label20.Text = "Net Salary";
            label22.Text = "Payment Date";
            textBox30.Clear();
            textBox29.Clear();
            Default.BringToFront();
            label42.Visible = false;
            label43.Visible = false;

            string query4 = "select count(id_staff) from staff";
            DataTable dt4 = new DataTable();
            SqlDataAdapter adapter4 = new SqlDataAdapter(query4, connection);
            adapter4.Fill(dt4);
            label44.Text = dt4.Rows[0][0].ToString();
            string query5 = "select sum(b.bonus) as [TB] from staff s,bonus b where s.id_staff=b.id_staff";
            DataTable dt5 = new DataTable();
            SqlDataAdapter adapter5 = new SqlDataAdapter(query5, connection);
            adapter5.Fill(dt5);
            int total_bonus = 0;
            if (dt5.Rows[0][0].ToString() != "")
            {
                total_bonus = int.Parse(dt5.Rows[0][0].ToString());
            }
            string query6 = "select sum(datediff(month, s.doe, getdate()) * p.salary) as [TS] from staff s,Positions p where s.position=p.id_pos";
            DataTable dt6 = new DataTable();
            SqlDataAdapter adapter6 = new SqlDataAdapter(query6, connection);
            adapter6.Fill(dt6);
            int total_salary = 0;
            if (dt6.Rows[0][0].ToString() != "")
            {
                total_salary = int.Parse(dt6.Rows[0][0].ToString());
            }
            string query3 = "select sum(total_salary) from Ex_staffers";
            DataTable dt3 = new DataTable();
            SqlDataAdapter adapter3 = new SqlDataAdapter(query3, connection);
            adapter3.Fill(dt3);
            int ex_salary = 0;
            if (dt3.Rows[0][0].ToString() != "")
            {
                ex_salary = int.Parse(dt3.Rows[0][0].ToString());
            }
            label49.Text = (total_bonus + total_salary + ex_salary).ToString() + " $";
        }

        private void StaffControl_VisibleChanged(object sender, EventArgs e)
        {
            string query = "select count(id_staff) from staff";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dt);
            label44.Text = dt.Rows[0][0].ToString();
            string query1 = "select sum(b.bonus) as [TB] from staff s,bonus b where s.id_staff=b.id_staff";
            DataTable dt1 = new DataTable();
            SqlDataAdapter adapter1 = new SqlDataAdapter(query1, connection);
            adapter1.Fill(dt1);
            int total_bonus = 0;
            if (dt1.Rows[0][0].ToString() != "")
            {
                total_bonus = int.Parse(dt1.Rows[0][0].ToString());
            }
            string query2 = "select sum(datediff(month, s.doe, getdate()) * p.salary) as [TS] from staff s,Positions p where s.position=p.id_pos";
            DataTable dt2 = new DataTable();
            SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
            adapter2.Fill(dt2);
            int total_salary = 0;
            if (dt2.Rows[0][0].ToString() != "")
            {
                total_salary = int.Parse(dt2.Rows[0][0].ToString());
            }
            string query3 = "select sum(total_salary) from Ex_staffers";
            DataTable dt3 = new DataTable();
            SqlDataAdapter adapter3 = new SqlDataAdapter(query3, connection);
            adapter3.Fill(dt3);
            int ex_salary = 0;
            if (dt3.Rows[0][0].ToString() != "")
            {
                ex_salary = int.Parse(dt3.Rows[0][0].ToString());
            }
            label49.Text = (total_bonus + total_salary + ex_salary).ToString() + " $";
            StaffControl.SelectedTab = tabPage7;
        }



        private void Staff_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == ""))
            {
                label6.Visible = true;
                label6.Text = "* Please fill in all fields";
                label6.ForeColor = Color.Red;
            }
            else
            {
                int id_staff = 0;
                string query = "insert into staff values (@first_name,@last_name,@phone,@dob,@doe,@gender,@pos,@email)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@first_name", textBox1.Text.ToString()[0].ToString().ToUpper() + textBox1.Text.Substring(1));
                command.Parameters.AddWithValue("@last_name", textBox2.Text.ToString()[0].ToString().ToUpper() + textBox2.Text.Substring(1));
                command.Parameters.AddWithValue("@phone", textBox3.Text);
                command.Parameters.AddWithValue("@dob", dateTimePicker1.Text);
                command.Parameters.AddWithValue("@doe", dateTimePicker2.Text);
                command.Parameters.AddWithValue("@gender", gender);
                command.Parameters.AddWithValue("@pos", comboBox1.SelectedValue);
                command.Parameters.AddWithValue("@email", textBox4.Text);


                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                dateTimePicker1.Value = new DateTime(2001, 01, 01);
                dateTimePicker1.MaxDate = DateTime.Now.Add(new TimeSpan(-6575, 0, 0, 0, 0, 0));
                string staff = "select id_staff from staff";
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(staff, connection);
                adapter.Fill(table);
                dataGridView3.DataSource = table;
                foreach (DataGridViewRow row1 in dataGridView3.Rows)
                {
                    id_staff++;
                }
                int index = int.Parse(dataGridView3.Rows[id_staff - 1].Cells[0].Value.ToString());
                string bonus = "insert into bonus values (@id,0,GETDATE())";
                SqlCommand command2 = new SqlCommand(bonus, connection);
                command2.Parameters.AddWithValue("@id", index);
                connection.Open();
                command2.ExecuteNonQuery();
                connection.Close();
                label6.Visible = true;
                label6.Text = "Staff Added Successfully";
                label6.ForeColor = Color.Lime;
                id_staff = 0;
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker1.Value = new DateTime(2001, 01, 01);
            label6.Visible = false;
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            Staffid.Clear();
            label7.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Staffid.Text == "")
            {
                label7.Visible = true;
                label7.Text = "* Please Select Staff to Update";
                label7.ForeColor = Color.Red;
            }
            else if ((Staffid.Text == "") || (textBox5.Text == "") || (textBox6.Text == "") || (textBox7.Text == "") || (textBox8.Text == ""))
            {
                label7.Visible = true;
                label7.Text = "* Please fill in all fields";
                label7.ForeColor = Color.Red;
            }
            else
            {
                string query = "update staff set  first_name=@ism, last_name=@fam, phone=@tel, email=@email where id_staff=@id";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", Staffid.Text);
                cmd.Parameters.AddWithValue("@ism", textBox8.Text);
                cmd.Parameters.AddWithValue("@fam", textBox7.Text);
                cmd.Parameters.AddWithValue("@tel", textBox6.Text);
                cmd.Parameters.AddWithValue("@email", textBox5.Text);
                connection.Open();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox5.Clear();
                Staffid.Clear();
                //MessageBox.Show("Data updated");
                cmd.ExecuteNonQuery();
                connection.Close();
                label7.Visible = true;
                label7.Text = "Staff Updated Successfully";
                label7.ForeColor = Color.Lime;
                string query1 = "select id_staff as [Staff ID],last_name as Surname,first_name as Name, phone as Phone, email as Email,dob as DateofBirth,doe as [DateofEmployee ] from staff";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query1, connection);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            //textBox5.Clear();
            //textBox6.Clear();
            //textBox7.Clear();
            //textBox8.Clear();
            //textBox9.Clear();
            //Staffid.Clear();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (Staffid.Text == "")
            {
                label7.Visible = true;
                label7.Text = "* Please Select Staff To Delete";
                label7.ForeColor = Color.Red;
            }
            else
            {
                string query = "insert into ex_staffers (first_name,last_name,phone,email,total_salary) " +
                    "select s.first_name,s.last_name,s.phone,s.email,(datediff(month, s.doe, getdate()) * p.salary + sum(b.bonus)) " +
                    "from staff s,bonus b,Positions p where s.id_staff = b.id_staff and s.position=p.id_pos and s.id_staff=b.id_staff and s.id_staff=@id " +
                    "group by s.doe,p.salary,b.id_staff,s.id_staff,s.first_name,s.last_name,s.phone,s.email " +
                    "delete from bonus where id_staff=@id " +
                    "delete from staff where id_staff=@id ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", int.Parse(Staffid.Text));
                connection.Open();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox5.Clear();
                Staffid.Clear();
                //MessageBox.Show("Data updated");
                command.ExecuteNonQuery();
                connection.Close();
                label7.Visible = true;
                label7.Text = "Staff Deleted Successfully";
                label7.ForeColor = Color.Lime;
                string query1 = "select id_staff as [Staff ID],last_name as Surname,first_name as Name, phone as Phone, email as Email,dob as DateofBirth,doe as [DateofEmployee ] from staff";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query1, connection);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void StaffControl_Deselected(object sender, TabControlEventArgs e)
        {

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var n = e.RowIndex;
            if (n >= 0)
            {
                Staffid.Text = dataGridView1.Rows[n].Cells[0].Value.ToString();
                textBox8.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
                textBox7.Text = dataGridView1.Rows[n].Cells[1].Value.ToString();
                textBox6.Text = dataGridView1.Rows[n].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[n].Cells[4].Value.ToString();
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var n = e.RowIndex;
            if (n >= 0)
            {
                textBox11.Text = dataGridView2.Rows[n].Cells[0].Value.ToString();
                textBox14.Text = dataGridView2.Rows[n].Cells[1].Value.ToString();
                textBox15.Text = dataGridView2.Rows[n].Cells[2].Value.ToString();
                textBox13.Text = dataGridView2.Rows[n].Cells[3].Value.ToString();
                textBox12.Text = dataGridView2.Rows[n].Cells[4].Value.ToString();
                textBox10.Text = dataGridView2.Rows[n].Cells[5].Value.ToString();
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var n = e.RowIndex;
            if (n >= 0)
            {
                textBox17.Text = dataGridView4.Rows[n].Cells[0].Value.ToString();
                textBox20.Text = dataGridView4.Rows[n].Cells[1].Value.ToString();
                textBox21.Text = dataGridView4.Rows[n].Cells[2].Value.ToString();
                textBox19.Text = dataGridView4.Rows[n].Cells[3].Value.ToString();
                textBox18.Text = dataGridView4.Rows[n].Cells[4].Value.ToString();
                textBox16.Text = dataGridView4.Rows[n].Cells[5].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox23.Clear();
            textBox24.Clear();
            textBox25.Clear();
            textBox26.Clear();
            textBox27.Clear();
            textBox22.Clear();
            textBox28.Clear();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            label50.Visible = false;
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var n = e.RowIndex;
            if (n >= 0)
            {
                textBox23.Text = dataGridView5.Rows[n].Cells[0].Value.ToString();
                textBox26.Text = dataGridView5.Rows[n].Cells[1].Value.ToString();
                textBox27.Text = dataGridView5.Rows[n].Cells[2].Value.ToString();
                textBox25.Text = dataGridView5.Rows[n].Cells[3].Value.ToString();
                textBox24.Text = ((DateTime)dataGridView5.Rows[n].Cells[4].Value).ToShortDateString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bool check = true;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value.ToString() == textBox22.Text)
                {
                    check = false;
                }
            }
            if (check)
            {
                textBox22.Text = "Staff ID Not Found";
            }
            else
            {
                if (textBox28.Text == "Enter Bonus")
                {
                    textBox28.Text = "";
                }
                else if (textBox28.Text != "")
                {
                    string bonus = "insert into bonus values (@id,@bonus,GETDATE())";
                    SqlCommand command2 = new SqlCommand(bonus, connection);
                    command2.Parameters.AddWithValue("@id", textBox22.Text);
                    command2.Parameters.AddWithValue("@bonus", textBox28.Text);
                    connection.Open();
                    command2.ExecuteNonQuery();
                    connection.Close();

                    string bonus1 = "select b.id_staff as [Staff ID],s.last_name as Surname,s.first_name as Name,Convert(varchar,b.bonus)+' $' as Bonus,b.bonus_date as [Bonus Date] from staff s, bonus b where s.id_staff=b.id_staff and b.bonus!=0";
                    DataTable bonusTable = new DataTable();
                    SqlDataAdapter bonusadapter = new SqlDataAdapter(bonus1, connection);
                    bonusadapter.Fill(bonusTable);
                    dataGridView5.DataSource = bonusTable;
                    textBox22.Clear();
                    textBox28.Clear();
                }
                else
                {
                    textBox28.Text = "Enter Bonus";
                }
            }



        }

        private void textBox22_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            bool check = true;
            int index = 0;
            int i = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[0].Value.ToString() == textBox29.Text)
                {
                    check = false;
                    i = index;
                }
                else
                {
                    index++;
                }
            }
            if (check)
            {
                textBox29.Text = "Staff ID Not Found";
            }
            else
            {
                label15.Text = dataGridView2.Rows[i].Cells[0].Value.ToString();
                label14.Text = dataGridView2.Rows[i].Cells[1].Value.ToString();
                label13.Text = dataGridView2.Rows[i].Cells[2].Value.ToString();
                label12.Text = dataGridView2.Rows[i].Cells[3].Value.ToString();
                label17.Text = (int.Parse((dataGridView2.Rows[i].Cells[3].Value.ToString()).Split(" ")[0]) * (0.12)).ToString() + " $";
                label20.Text = (int.Parse((dataGridView2.Rows[i].Cells[3].Value.ToString()).Split(" ")[0]) * (0.88)).ToString() + " $";
                label22.Text = DateTime.Now.ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Salary.BringToFront();
            button11.Visible = true;
            button14.Visible = false;
            textBox29.Visible = true;
            pictureBox125.Visible = true;
            pictureBox126.Visible = true;
            pictureBox127.Visible = true;
            pictureBox128.Visible = true;
            label35.Text = "Staff ID";
            label34.Text = "Last Name";
            label33.Text = "First Name";
            label30.Text = "Bonus Amount";
            label32.Text = "Tax";
            label26.Text = "Net Bonus";
            label24.Text = "Payment Date";
            label42.Visible = false;
            textBox30.Clear();
            textBox29.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bonus.BringToFront();
            button11.Visible = false;
            button14.Visible = true;
            textBox29.Visible = true;
            pictureBox125.Visible = true;
            pictureBox126.Visible = true;
            pictureBox127.Visible = true;
            pictureBox128.Visible = true;
            label15.Text = "Staff ID";
            label14.Text = "Last Name";
            label12.Text = "First Name";
            label13.Text = "Salary";
            label17.Text = "Tax";
            label20.Text = "Net Salary";
            label22.Text = "Payment Date";
            label43.Visible = false;
            textBox29.Clear();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            bool check = true;
            int index = 0;
            int i = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[0].Value.ToString() == textBox29.Text)
                {
                    check = false;
                    i = index;
                }
                else
                {
                    index++;
                }
            }
            if (check)
            {
                textBox29.Text = "Staff ID Not Found";
            }
            else
            {
                label35.Text = dataGridView2.Rows[i].Cells[0].Value.ToString();
                label34.Text = dataGridView2.Rows[i].Cells[1].Value.ToString();
                label33.Text = dataGridView2.Rows[i].Cells[2].Value.ToString();
                label24.Text = DateTime.Now.ToString();

            }
        }

        private void textBox29_Click(object sender, EventArgs e)
        {
            if (textBox29.Text == "Staff ID Not Found")
            {
                textBox29.Clear();
            }
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            if (textBox30.Text != "")
            {
                label32.Text = textBox30.Text + " $";
                label30.Text = (int.Parse(textBox30.Text.ToString()) * (0.12)).ToString() + " $";
                label26.Text = (int.Parse(textBox30.Text.ToString()) * (0.88)).ToString() + " $";
            }
            else
            {
                label32.Text = "0 $";
                label30.Text = "0 $";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            label42.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label43.Visible = true;
        }

        private void textBox22_Click(object sender, EventArgs e)
        {
            if (textBox22.Text == "Staff ID Not Found")
            {
                textBox22.Clear();
            }
        }

        private void textBox28_Click(object sender, EventArgs e)
        {
            if (textBox28.Text == "Enter Bonus")
            {
                textBox28.Clear();
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                string query = "select id_staff as [Staff ID],last_name as Surname,first_name as Name, phone as Phone, email as Email,dob as DateofBirth,doe as [DateofEmployee ] from staff";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                string name_combo = "";
                switch (comboBox2.SelectedIndex)
                {
                    case 0:
                        name_combo = "id_staff";
                        break;
                    case 1:
                        name_combo = "last_name";
                        break;
                    case 2:
                        name_combo = "first_name";
                        break;
                    case 3:
                        name_combo = "phone";
                        break;
                    case 4:
                        name_combo = "email";
                        break;
                }
                string query = "(select id_staff as [Staff ID],last_name as Surname,first_name as Name, phone as Phone, email as Email,dob as DateofBirth,doe as [DateofEmployee ] from staff where " + name_combo + " like '%" + textBox9.Text + "%')";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            if (textBox29.Text == "Staff ID Not Found")
            {
                label35.Text = "Staff ID";
                label34.Text = "Last Name";
                label33.Text = "First Name";
                //label30.Text = "Bonus Amount";
                //label32.Text = "Tax";
                //label26.Text = "Net Bonus";
                label24.Text = "Payment Date";
                label15.Text = "Staff ID";
                label14.Text = "Last Name";
                label12.Text = "First Name";
                label13.Text = "Salary";
                label17.Text = "Tax";
                label20.Text = "Net Salary";
                label22.Text = "Payment Date";
                //textBox30.Clear();
                //textBox29.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox17.Text == "")
            {
                label50.Visible = true;
                label50.Text = "* Please Select Ex-Staff to Delete";
                label50.ForeColor = Color.Red;
            }
            else
            {
                string query = "delete from ex_staffers where id_ex_staffer=@id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", textBox17.Text);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                string ex_staff = "select id_ex_staffer as [Ex-Staff ID],last_name as Surname,first_name as Name, phone as Phone, email as Email,convert(varchar,total_salary)+' $' as [Total Salary] from ex_staffers";
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter2 = new SqlDataAdapter(ex_staff, connection);
                dataAdapter2.Fill(dataTable);
                dataGridView4.DataSource = dataTable;

                textBox16.Clear();
                textBox17.Clear();
                textBox18.Clear();
                textBox19.Clear();
                textBox20.Clear();
                textBox21.Clear();
                label50.Visible = true;
                label50.ForeColor = Color.Lime;
                label50.Text = "Ex-Staff Deleted Successfully";
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            label50.Visible = false;
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class BoardofDirectors : Form
    {
        public BoardofDirectors()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4OPOMV2\\SQLEXPRESS;Initial Catalog=Construction_Company;Integrated Security=True;Encrypt=False");
        private void Exit_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            //Application.ExitThread();
            //Environment.Exit(0);
            Environment.Exit(Environment.ExitCode);
        }

        private void BoardofDirectors_Load(object sender, EventArgs e)
        {

            string query6 = "select sum(price) from sales";
            DataTable dt6 = new DataTable();
            SqlDataAdapter adapter6 = new SqlDataAdapter(query6, connection);
            adapter6.Fill(dt6);
            label4.Text = dt6.Rows[0][0].ToString() + " $";

            string query8 = "select count(id_staff) from staff";
            DataTable dt8 = new DataTable();
            SqlDataAdapter adapter8 = new SqlDataAdapter(query8, connection);
            adapter8.Fill(dt8);
            label10.Text = dt8.Rows[0][0].ToString();


            string query1 = "select sum(b.bonus) as [TB] from staff s,bonus b where s.id_staff=b.id_staff";
            DataTable dt1 = new DataTable();
            SqlDataAdapter adapter1 = new SqlDataAdapter(query1, connection);
            adapter1.Fill(dt1);
            int total_bonus = 0;
            if (dt1.Rows[0][0].ToString() != "")
            {
                total_bonus = int.Parse(dt1.Rows[0][0].ToString());
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
            string query2 = "select sum(datediff(month, s.doe, getdate()) * p.salary) as [TS] from staff s,Positions p where s.position=p.id_pos";
            DataTable dt2 = new DataTable();
            SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
            adapter2.Fill(dt2);
            int total_salary = 0;
            if (dt2.Rows[0][0].ToString() != "")
            {
                total_salary = int.Parse(dt2.Rows[0][0].ToString());
            }


            string query4 = "select count(id_contractor) from contractors";
            DataTable dt4 = new DataTable();
            SqlDataAdapter adapter4 = new SqlDataAdapter(query4, connection);
            adapter4.Fill(dt4);
            label8.Text = dt4.Rows[0][0].ToString();

            string query5 = "select sum(contract_amount) from contractors";
            DataTable dt5 = new DataTable();
            SqlDataAdapter adapter5 = new SqlDataAdapter(query5, connection);
            adapter5.Fill(dt5);
            int contractor_amount = 0;
            if (dt5.Rows[0][0].ToString() != "")
            {
                contractor_amount = int.Parse(dt5.Rows[0][0].ToString());
            }

            string query7 = "select sum(total_cost) from expense";
            DataTable dt7 = new DataTable();
            SqlDataAdapter adapter7 = new SqlDataAdapter(query7, connection);
            adapter7.Fill(dt7);
            int expense = 0;
            if (dt7.Rows[0][0].ToString() != "")
            {
                expense = int.Parse(dt7.Rows[0][0].ToString());
            }
            label6.Text = (expense + total_salary + total_bonus + ex_salary + contractor_amount).ToString() + " $";


            string query10 = "select sum(amount) from expense where type='mach'";
            DataTable dt10 = new DataTable();
            SqlDataAdapter adapter10 = new SqlDataAdapter(query10, connection);
            adapter10.Fill(dt10);
            label17.Text = dt10.Rows[0][0].ToString();



            string query = "select * from bofd";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                switch (i)
                {
                    case 1:
                        label11.Text = dt.Rows[i]["Surname"].ToString();
                        label12.Text = dt.Rows[i][2].ToString();
                        label13.Text = "800 000 000 $";
                        label14.Text = (Convert.ToInt32(label4.Text.ToString().Split(" ")[0]) * 0.01 * (Convert.ToInt32(dt.Rows[i][4].ToString().Split(" ")[0]))).ToString() + " $";
                        break;
                    case 2:
                        label21.Text = dt.Rows[i]["Surname"].ToString();
                        label22.Text = dt.Rows[i][2].ToString();
                        label23.Text = "400 000 000 $";
                        label24.Text = (Convert.ToInt32(label4.Text.ToString().Split(" ")[0]) * 0.01 * (Convert.ToInt32(dt.Rows[i][4].ToString().Split(" ")[0]))).ToString() + " $";
                        break;
                    case 3:
                        label31.Text = dt.Rows[i]["Surname"].ToString();
                        label32.Text = dt.Rows[i][2].ToString();
                        label33.Text = "300 000 000 $";
                        label34.Text = (Convert.ToInt32(label4.Text.ToString().Split(" ")[0]) * 0.01 * (Convert.ToInt32(dt.Rows[i][4].ToString().Split(" ")[0]))).ToString() + " $";
                        break;
                    case 4:
                        label41.Text = dt.Rows[i]["Surname"].ToString();
                        label42.Text = dt.Rows[i][2].ToString();
                        label43.Text = "300 000 000 $";
                        label44.Text = (Convert.ToInt32(label4.Text.ToString().Split(" ")[0]) * 0.01 * (Convert.ToInt32(dt.Rows[i][4].ToString().Split(" ")[0]))).ToString() + " $";
                        break;
                }
            }
            label2.Text = "1 800 000 000 $";

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Entering entering = new Entering();
            entering.Show();
            this.Hide();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

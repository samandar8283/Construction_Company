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
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4OPOMV2\\SQLEXPRESS;Initial Catalog=Construction_Company;Integrated Security=True;Encrypt=False");
        private void Dashboard_VisibleChanged(object sender, EventArgs e)
        {
            string query = "select count(id_staff) from staff";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dt);
            label17.Text = dt.Rows[0][0].ToString();


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
            label19.Text = (total_bonus + ex_salary + total_salary).ToString() + " $";


            string query4 = "select count(id_contractor) from contractors";
            DataTable dt4 = new DataTable();
            SqlDataAdapter adapter4 = new SqlDataAdapter(query4, connection);
            adapter4.Fill(dt4);
            label16.Text = dt4.Rows[0][0].ToString();

            string query5 = "select sum(contract_amount) from contractors";
            DataTable dt5 = new DataTable();
            SqlDataAdapter adapter5 = new SqlDataAdapter(query5, connection);
            adapter5.Fill(dt5);
            int contractor_amount = 0;
            if (dt5.Rows[0][0].ToString() != "")
            {
                contractor_amount = int.Parse(dt5.Rows[0][0].ToString());
            }
            label15.Text = contractor_amount.ToString()+" $";

            string query6 = "select sum(price) from sales";
            DataTable dt6 = new DataTable();
            SqlDataAdapter adapter6 = new SqlDataAdapter(query6, connection);
            adapter6.Fill(dt6);
            int income = 0;
            if (dt6.Rows[0][0].ToString() != "")
            {
                income = int.Parse(dt6.Rows[0][0].ToString());
            }
            label11.Text = income.ToString() + " $";

            string query7 = "select sum(total_cost) from expense";
            DataTable dt7 = new DataTable();
            SqlDataAdapter adapter7 = new SqlDataAdapter(query7, connection);
            adapter7.Fill(dt7);
            int expense = 0;
            if (dt7.Rows[0][0].ToString() != "")
            {
                expense = int.Parse(dt7.Rows[0][0].ToString());
            }
            label12.Text = (expense+total_salary+total_bonus+ex_salary+contractor_amount).ToString() + " $";

            string query8 = "select sum(total_cost) from expense where type='mach'";
            DataTable dt8 = new DataTable();
            SqlDataAdapter adapter8 = new SqlDataAdapter(query8, connection);
            adapter8.Fill(dt8);
            int expense_mach = 0;
            if (dt8.Rows[0][0].ToString() != "")
            {
                expense_mach = int.Parse(dt8.Rows[0][0].ToString());
            }
            label13.Text = expense_mach.ToString() + " $";

            string query9 = "select sum(total_cost) from expense where type='mat'";
            DataTable dt9 = new DataTable();
            SqlDataAdapter adapter9 = new SqlDataAdapter(query9, connection);
            adapter9.Fill(dt9);
            int expense_mat = 0;
            if (dt9.Rows[0][0].ToString() != "")
            {
                expense_mat = int.Parse(dt9.Rows[0][0].ToString());
            }
            label14.Text = expense_mat.ToString() + " $";

            string query10 = "select sum(amount) from expense where type='mach'";
            DataTable dt10 = new DataTable();
            SqlDataAdapter adapter10 = new SqlDataAdapter(query10, connection);
            adapter10.Fill(dt10);
            label18.Text = dt10.Rows[0][0].ToString();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}

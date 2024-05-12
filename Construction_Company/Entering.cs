using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Construction_Company
{
    public partial class Entering : Form
    {
        public Entering()
        {
            InitializeComponent();
        }

        private void Entering_Load(object sender, EventArgs e)
        {

        }

        private void Admin_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            //System.Diagnostics.Process.GetCurrentProcess().Kill();
            //Application.Exit();
        }

        private void BOD_Click(object sender, EventArgs e)
        {
            Director_Enter form = new Director_Enter();
            form.Show();
            this.Hide();
        }

        private void Customer_Click(object sender, EventArgs e)
        {
            Customer_Enter form = new Customer_Enter();
            form.Show();
            this.Hide();
        }
    }
}

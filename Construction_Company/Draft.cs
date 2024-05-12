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
    public partial class Draft : Form
    {
        public Draft()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = (Convert.ToInt32(label1.Text) + 1).ToString();
            if(label1.Text == "5")
            {
                comboBox1.Items.RemoveAt(10);
            }
            comboBox1.Items.Remove("10");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void Draft_Load(object sender, EventArgs e)
        {
            label1.Text = "0";
        }
    }
}

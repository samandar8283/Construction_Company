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
    public partial class Presentation : Form
    {
        public Presentation()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Entering entering = new Entering();
            entering.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJackSolution
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            MainPanel.Hide();
            LoginPanel.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

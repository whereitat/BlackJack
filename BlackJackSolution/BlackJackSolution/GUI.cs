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

        private void DealButton_Click(object sender, EventArgs e)
        {
            int trying;
            if (String.IsNullOrWhiteSpace(BetAmountText.Text) && int.TryParse(BetAmountText.Text, out trying)) //Kanske för många steg att parsa och if och kolla samtidigt
            {
                HitButton.Show();
                StandButton.Show();
                DealButton.Hide();
                LeaveButton.Hide();
                BetAmountText.Hide();
                BetLabelAmount.Text = BetAmountText.Text;
                BetLabelAmount.Show();
                //Fattas deal
            }
            else
            {
                Console.WriteLine("Inget bet"); // fixa info ruta
            }
          
        }

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            GamePanel.Hide();
            MainPanel.Show();
        }
    }
}

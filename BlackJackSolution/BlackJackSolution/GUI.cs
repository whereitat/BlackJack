using BlackJackSolution.Model;
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
            try {
                //int trying; && int.TryParse(BetAmountText.Text, out trying)
                if (!String.IsNullOrWhiteSpace(BetAmountText.Text)) //Kanske för många steg att parsa och if och kolla samtidigt
                {
                    HitButton.Show();
                    StandButton.Show();
                    DealButton.Hide();
                    LeaveButton.Hide();
                    BetAmountText.Hide();
                    BetLabelAmount.Text = BetAmountText.Text;
                    BetLabelAmount.Show();
                    InfoLabel.Text = "You bet " + BetAmountText.Text;
                    //Börjar dela kort
                    Deck deck = Control.Controller.CreateDeck();
                    Hand dealerHand = new Hand();
                    Hand myHand = new Hand();
                    dealerHand.AddCard(deck);
                    myHand.AddCard(deck);
                    dealerHand.AddCard(deck);
                    myHand.AddCard(deck);
                    displayMyCards(myHand);
                    displayDealerCards(dealerHand);
                    //Båda händer har 2 kort var
                }
                else
                {
                    InfoLabel.Text = "Please place a bet";
                    Console.WriteLine("Inget bet"); // fixa info ruta
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
          
        }

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            GamePanel.Hide();
            MainPanel.Show();
        }
        public void displayMyCards(Hand hand) //måste fixa om hur suit och value läses
        {
            try {
                String picture = "";
                if (hand != null && hand.handCards != null)
                {
                    for (int i = 0; i < hand.handCards.Count; i++)
                    {
                        //Sätta string picture till rätt image
                        if (hand.handCards[i].value < 10)
                        {
                            picture = "_0" + hand.handCards[i].value + "_" + hand.handCards[i].suit;
                        }
                        else if (hand.handCards[i].value == 10)
                        {
                            picture = "_" + hand.handCards[i].value + "_" + hand.handCards[i].suit;
                        }
                        else if (hand.handCards[i].value == 11) //ess eller jack?
                        {
                            picture = "_" + hand.handCards[i].value + "_" + hand.handCards[i].suit;
                        }
                        else if (hand.handCards[i].value == 12)
                        {
                            picture = "_" + hand.handCards[i].value + "_" + hand.handCards[i].suit;
                        }
                        else if (hand.handCards[i].value == 13)
                        {
                            picture = "_" + hand.handCards[i].value + "_" + hand.handCards[i].suit;
                        }
                        //Hämta samt visa korten
                        if (i == 0)
                        {
                            YourHandPictureBox1.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            YourHandPictureBox1.Image = pic;
                            YourHandPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            YourHandPictureBox1.BringToFront();
                        }
                        else if (i == 1)
                        {
                            YourHandPictureBox2.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            YourHandPictureBox2.Image = pic;
                            YourHandPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                            YourHandPictureBox2.BringToFront();
                        }
                        else if (i == 2)
                        {
                            YourHandPictureBox3.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            YourHandPictureBox3.Image = pic;
                            YourHandPictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                            YourHandPictureBox3.BringToFront();
                        }
                        else if (i == 3)
                        {
                            YourHandPictureBox4.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            YourHandPictureBox4.Image = pic;
                            YourHandPictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                            YourHandPictureBox4.BringToFront();
                        }
                        else if (i == 4)
                        {
                            YourHandPictureBox5.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            YourHandPictureBox5.Image = pic;
                            YourHandPictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                            YourHandPictureBox5.BringToFront();
                        }
                        else if (i == 5)
                        {
                            YourHandPictureBox6.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            YourHandPictureBox6.Image = pic;
                            YourHandPictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                            YourHandPictureBox6.BringToFront();
                        }
                        else if (i == 6)
                        {
                            YourHandPictureBox7.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            YourHandPictureBox7.Image = pic;
                            YourHandPictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
                            YourHandPictureBox7.BringToFront();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }
        public void displayDealerCards(Hand hand)
        {
            try {
                String picture = "";
                if (hand != null && hand.handCards != null)
                {
                    for (int i = 0; i < hand.handCards.Count; i++)
                    {
                        //Sätta string picture till rätt image
                        if (hand.handCards[i].value < 10)
                        {
                            picture = "_0" + hand.handCards[i].value + "_" + hand.handCards[i].suit;
                        }
                        else if (hand.handCards[i].value == 10)
                        {
                            picture = "_" + hand.handCards[i].value + "_" + hand.handCards[i].suit;
                        }
                        else if (hand.handCards[i].value == 11) //ess eller jack?
                        {
                            picture = "_" + hand.handCards[i].value + "_" + hand.handCards[i].suit;
                        }
                        else if (hand.handCards[i].value == 12)
                        {
                            picture = "_" + hand.handCards[i].value + "_" + hand.handCards[i].suit;
                        }
                        else if (hand.handCards[i].value == 13)
                        {
                            picture = "_" + hand.handCards[i].value + "_" + hand.handCards[i].suit;
                        }
                        //Hämta samt visa korten
                        if (i == 0)
                        {
                            DealerPictureBox1.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            DealerPictureBox1.Image = pic;
                            DealerPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            DealerPictureBox1.BringToFront();
                        }
                        else if (i == 1)
                        {
                            DealerPictureBox2.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            DealerPictureBox2.Image = pic;
                            DealerPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                            DealerPictureBox2.BringToFront();
                        }
                        else if (i == 2)
                        {
                            DealerPictureBox3.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            DealerPictureBox3.Image = pic;
                            DealerPictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                            DealerPictureBox3.BringToFront();
                        }
                        else if (i == 3)
                        {
                            DealerPictureBox4.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            DealerPictureBox4.Image = pic;
                            DealerPictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                            DealerPictureBox4.BringToFront();
                        }
                        else if (i == 4)
                        {
                            DealerPictureBox5.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            DealerPictureBox5.Image = pic;
                            DealerPictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                            DealerPictureBox5.BringToFront();
                        }
                        else if (i == 5)
                        {
                            DealerPictureBox6.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            DealerPictureBox6.Image = pic;
                            DealerPictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                            DealerPictureBox6.BringToFront();
                        }
                        else if (i == 6)
                        {
                            DealerPictureBox7.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            DealerPictureBox7.Image = pic;
                            DealerPictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
                            DealerPictureBox7.BringToFront();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }
    }
}

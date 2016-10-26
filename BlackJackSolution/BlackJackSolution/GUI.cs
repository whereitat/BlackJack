using BlackJackSolution.Control;
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
        private static Controller control = new Controller();
        private double bet;
        private String betString;
        private String myTotal;
        private String dealerTotal;
        public GUI()
        {
            InitializeComponent();
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            try
            {
                MainPanel.Hide();
                LoginPanel.Show();
            }
            catch (Exception eLOB)
            {
                //Fattas
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DealButton_Click(object sender, EventArgs e)
        {
            try {
                clearCards();
                if (bet > 0)
                {
                    control.DealButtonPush();
                    HitButton.Show();
                    StandButton.Show();
                    DealButton.Hide();
                    LeaveButton.Hide();
                    MinBetBtn.Hide();
                    MaxBetBtn.Hide();
                    //Fattas visa kort
                    int myHandCheck = control.CheckMyHand();
                    int dealerHandCheck = control.CheckDealerHand();
                    if (myHandCheck == 21)
                    {
                        double winnings = bet * 1.5; 
                        InfoLabel.Text = "BLACKJACK! You win : " + winnings + "\n" + "Please enter a new bet to play again";
                        //UPDATE SALDO +user*1.5 -bank
                        control.ClearHands();
                        bet = 0;//Måste skicka till DB först
                        HitButton.Hide();
                        StandButton.Hide();
                        DealButton.Show();
                        LeaveButton.Show();
                        MinBetBtn.Show();
                        MaxBetBtn.Show();
                    }
                    else
                    {
                        myTotal = "Your handtotal is : " + myHandCheck + "\n";
                        dealerTotal = "Dealer handtotal is : " + dealerHandCheck;
                        betString = "You bet " + bet + "\n"; //ÄNDRA TILL KNAPP
                        InfoLabel.Text = betString + myTotal + dealerTotal;
                    }
                }
                else
                {
                    InfoLabel.Text = "Please choose a bet first";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }
        private void LeaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                GamePanel.Hide();
                MainPanel.Show();
            }
            catch(Exception eLB)
            {
                //Fattas
            }
        }
        public void clearCards()
        {
            try
            {
                YourHandPictureBox1.Image = null;
                YourHandPictureBox2.Image = null;
                YourHandPictureBox3.Image = null;
                YourHandPictureBox4.Image = null;
                YourHandPictureBox5.Image = null;
                YourHandPictureBox6.Image = null;
                YourHandPictureBox7.Image = null;
                DealerPictureBox1.Image = null;
                DealerPictureBox2.Image = null;
                DealerPictureBox3.Image = null;
                DealerPictureBox4.Image = null;
                DealerPictureBox5.Image = null;
                DealerPictureBox6.Image = null;
                DealerPictureBox7.Image = null;
            }
            catch(Exception eCC)
            {
                //Fattas
            }
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
                        if (hand.handCards[i].getValue() < 10)
                        {
                            picture = "_0" + hand.handCards[i].getValue() + "_" + hand.handCards[i].getSuit();
                        }
                        else if (hand.handCards[i].getValue() == 10)
                        {
                            picture = "_" + hand.handCards[i].getValue() + "_" + hand.handCards[i].getSuit();
                        }
                        else if (hand.handCards[i].getValue() == 11) //ess eller jack?
                        {
                            picture = "_" + hand.handCards[i].getValue() + "_" + hand.handCards[i].getSuit();
                        }
                        else if (hand.handCards[i].getValue() == 12)
                        {
                            picture = "_" + hand.handCards[i].getValue() + "_" + hand.handCards[i].getSuit();
                        }
                        else if (hand.handCards[i].getValue() == 13)
                        {
                            picture = "_" + hand.handCards[i].getValue() + "_" + hand.handCards[i].getSuit();
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
            catch (Exception eDMH)
            {
                Console.WriteLine("Error : " + eDMH.Message);
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
                        if (hand.handCards[i].getValue() < 10)
                        {
                            picture = "_0" + hand.handCards[i].getValue() + "_" + hand.handCards[i].getSuit();
                        }
                        else if (hand.handCards[i].getValue() == 10)
                        {
                            picture = "_" + hand.handCards[i].getValue() + "_" + hand.handCards[i].getSuit();
                        }
                        else if (hand.handCards[i].getValue() == 11) //ess eller jack?
                        {
                            picture = "_" + hand.handCards[i].getValue() + "_" + hand.handCards[i].getSuit();
                        }
                        else if (hand.handCards[i].getValue() == 12)
                        {
                            picture = "_" + hand.handCards[i].getValue() + "_" + hand.handCards[i].getSuit();
                        }
                        else if (hand.handCards[i].getValue() == 13)
                        {
                            picture = "_" + hand.handCards[i].getValue() + "_" + hand.handCards[i].getSuit();
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
            catch (Exception eDDH)
            {
                Console.WriteLine("Error : " + eDDH.Message);
            }
        }

        private void HitButton_Click(object sender, EventArgs e)
        {
            try {
                if (myHand.getTotal() < 21)
                {
                    control.AddCard(deck, myHand);
                    control.AddCard(deck, dealerHand);
                    if (myHand.getTotal() < 21)
                    {
                        myTotal = "Your handtotal is : " + myHand.getTotal() + "\n";
                        dealerTotal = "Dealer handtotal is : " + dealerHand.getTotal();
                        bet = "You bet " + BetLabelAmount.Text + "\n";
                        InfoLabel.Text = bet + myTotal + dealerTotal;
                    } else if (myHand.getTotal() > 21)
                    {
                        InfoLabel.Text = "You are bust, dealer wins " + BetLabelAmount.Text + "\n" + "Please enter a new bet to play again";
                        HitButton.Hide();
                        StandButton.Hide();
                        DealButton.Show();
                        LeaveButton.Show();
                        BetAmountText.Clear();
                        BetAmountText.Show();
                        BetLabelAmount.Hide();
                        //UPDATE SALDO FÖR USER / BANK -user + dealer
                        control.ClearHand(myHand);//----------------------------------
                        control.ClearHand(dealerHand);//--------------------
                    } else if (myHand.getTotal() == 21)
                    {
                        InfoLabel.Text = "You have 21";
                        HitButton.Hide();
                    }
                }
            }
            catch (Exception e1)
            {

            }
        }

        private void StandButton_Click(object sender, EventArgs e)
        {
            try {
                while (true)
                {
                    if (dealerHand.getTotal() < 17)
                    {
                        control.AddCard(deck, dealerHand);
                        displayDealerCards(dealerHand);
                    }
                    else
                    {
                        break;
                    }
                }
                if (dealerHand.getTotal() >= myHand.getTotal() && dealerHand.getTotal() < 22)
                {
                    InfoLabel.Text = "The dealer has : " + dealerHand.getTotal() + "\n" + "You have : " + myHand.getTotal() + "\n" + "The dealer wins : " + BetAmountText.Text;
                    control.ClearHand(myHand);//----------------------------------
                    control.ClearHand(dealerHand);//----------------------------
                    //UPDATE SALDO FÖR USER/BANK dealer + user -
                }
                else if (dealerHand.getTotal() > 21)
                {
                    InfoLabel.Text = "The dealer is bust " + "\n" + "You have : " + myHand.getTotal() + "\n" + "You win : " + BetAmountText.Text;
                    control.ClearHand(myHand);//----------------------------------
                    control.ClearHand(dealerHand);//--------------------------
                    //UPDATE SALDO FÖR USER/BANK dealer - user +
                }
                else if (myHand.getTotal() > dealerHand.getTotal())
                {
                    InfoLabel.Text = "The dealer has " + dealerHand.getTotal() + "\n" + "You have : " + myHand.getTotal() + "\n" + "You win : " + BetAmountText.Text;
                    control.ClearHand(myHand);//----------------------------------
                    control.ClearHand(dealerHand);//------------------------------
                    //UPDATE SALDO FÖR USER/BANK dealer - user +
                }
                HitButton.Hide();
                StandButton.Hide();
                LeaveButton.Show();
                DealButton.Show();
                BetAmountText.Clear();
                BetAmountText.Show();
                BetLabelAmount.Hide();
            } catch (Exception eSB)
            {
                //Fattas
            }
        }

        private void LoginLoginButton_Click(object sender, EventArgs e)
        {
            MainPanel.Show();
            LoginPanel.Hide();
            MainTableGroupBox.Show();

            MainTableOnePictureBox.Visible = true;
            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
            Bitmap picSt = (Bitmap)rm.GetObject("Standard_Table_Btn");
            MainTableOnePictureBox.Image = picSt;
            MainTableOnePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            MainTableOnePictureBox.BringToFront();

            MainTableTwoPictureBox.Visible = true;
            Bitmap picSt2 = (Bitmap)rm.GetObject("Standard_Table_Btn");
            MainTableTwoPictureBox.Image = picSt2;
            MainTableTwoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            MainTableTwoPictureBox.BringToFront();

            MainTableThreePictureBox.Visible = true;
            Bitmap picVIP = (Bitmap)rm.GetObject("VIP_Table_Btn");
            MainTableThreePictureBox.Image = picVIP;
            MainTableThreePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            MainTableThreePictureBox.BringToFront();
        }

        private void MainTableOnePictureBox_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Erik heja heja");
        }

        private void LoginExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinBetBtn_Click(object sender, EventArgs e)
        {
            bet = double.Parse(MinBetBtn.Text);
            MinBetBtn.Hide();
            MaxBetBtn.Hide();
        }

        private void MaxBetBtn_Click(object sender, EventArgs e)
        {
            bet = double.Parse(MaxBetBtn.Text);
            MinBetBtn.Hide();
            MaxBetBtn.Hide();
        }
    }
}

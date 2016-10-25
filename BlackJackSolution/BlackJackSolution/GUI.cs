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
        private static Deck deck = Control.Controller.CreateDeck();
        private static Hand myHand = new Hand();
        private static Hand dealerHand = new Hand();
        private String bet;
        private String myTotal;
        private String dealerTotal;
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
                clearCards();
                int betInt = 0;
                bool tryParse = Int32.TryParse(BetAmountText.Text, out betInt);
                if (tryParse == true)
                {
                    betInt = Int32.Parse(BetAmountText.Text);
                    if (betInt <= 0)
                    {
                        InfoLabel.Text = "Please enter a valid bet (Not 0 or negative numbers)";
                    }
                    else
                    {
                        HitButton.Show();
                        StandButton.Show();
                        DealButton.Hide();
                        LeaveButton.Hide();
                        BetAmountText.Hide();
                        BetLabelAmount.Text = BetAmountText.Text;
                        BetLabelAmount.Show();
                        //Börjar dela kort
                        dealerHand.AddCard(deck);
                        myHand.AddCard(deck);
                        myHand.AddCard(deck);
                        displayMyCards(myHand);
                        displayDealerCards(dealerHand);
                        myHand.CheckHand();
                        dealerHand.CheckHand();
                        if (myHand.total == 21)
                        {
                            int winnings = Int32.Parse(BetLabelAmount.Text);
                            InfoLabel.Text = "BLACKJACK! You win : " + winnings * 1.5 + "\n" + "Please enter a new bet to play again";
                            //UPDATE SALDO +user*1.5 -bank
                            myHand.clearHand();
                            dealerHand.clearHand();
                            HitButton.Hide();
                            StandButton.Hide();
                            DealButton.Show();
                            LeaveButton.Show();
                            BetAmountText.Clear();
                            BetAmountText.Show();
                            BetLabelAmount.Hide();
                        }
                        else
                        {
                            myTotal = "Your handtotal is : " + myHand.total + "\n";
                            dealerTotal = "Dealer handtotal is : " + dealerHand.total;
                            bet = "You bet " + BetLabelAmount.Text + "\n";
                            InfoLabel.Text = bet + myTotal + dealerTotal;
                        }
                    }
                }
                else if(!String.IsNullOrWhiteSpace(BetAmountText.Text))
                {
                    InfoLabel.Text = "Please place a bet";
                }
                else if(tryParse == false)
                {
                    InfoLabel.Text = "Please enter a number as your bet";
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
        public void clearCards()
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

        private void HitButton_Click(object sender, EventArgs e)
        {
            if(myHand.total < 21)
            {
                myHand.AddCard(deck);
                displayMyCards(myHand);
                if(myHand.total < 21)
                {
                    myTotal = "Your handtotal is : " + myHand.total + "\n";
                    dealerTotal = "Dealer handtotal is : " + dealerHand.total;
                    bet = "You bet " + BetLabelAmount.Text + "\n";
                    InfoLabel.Text = bet + myTotal + dealerTotal;
                }else if(myHand.total > 21)
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
                    myHand.clearHand();
                    dealerHand.clearHand();
                }else if(myHand.total == 21)
                {
                    InfoLabel.Text = "You have 21";
                    HitButton.Hide();
                }
            }
        }

        private void StandButton_Click(object sender, EventArgs e)
        {
            while (true)
            {
                if(dealerHand.total < 17)
                {
                    dealerHand.AddCard(deck);
                    displayDealerCards(dealerHand);
                }
                else
                {
                    break;
                }
            }
            if(dealerHand.total >= myHand.total && dealerHand.total < 22)
            {
                InfoLabel.Text = "The dealer has : " + dealerHand.total + "\n" + "You have : " + myHand.total + "\n" + "The dealer wins : " + BetAmountText.Text;
                myHand.clearHand();
                dealerHand.clearHand();
                //UPDATE SALDO FÖR USER/BANK dealer + user -
            }
            else if (dealerHand.total > 21)
            {
                InfoLabel.Text = "The dealer is bust " + "\n" +  "You have : " + myHand.total + "\n" + "You win : " + BetAmountText.Text;
                myHand.clearHand();
                dealerHand.clearHand();
                //UPDATE SALDO FÖR USER/BANK dealer - user +
            }
            else if (myHand.total > dealerHand.total)
            {
                InfoLabel.Text = "The dealer has " + dealerHand.total + "\n" + "You have : " + myHand.total + "\n" + "You win : " + BetAmountText.Text;
                myHand.clearHand();
                dealerHand.clearHand();
                //UPDATE SALDO FÖR USER/BANK dealer - user +
            }
            HitButton.Hide();
            StandButton.Hide();
            LeaveButton.Show();
            DealButton.Show();
            BetAmountText.Clear();
            BetAmountText.Show();
            BetLabelAmount.Hide();

        }
    }
}

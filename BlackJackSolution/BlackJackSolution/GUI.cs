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
        private string betString;
        private string myTotal;
        private string dealerTotal;
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
                control.LogOut();
                bet = 0;
                betString = "";
                myTotal = "";
                dealerTotal = "";
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
                    displayMyCards(control.GetMyPictureStrings());
                    displayDealerCards(control.GetDealerPictureStrings());
                    int myHandCheck = control.CheckMyHand();
                    int dealerHandCheck = control.CheckDealerHand();
                    if (myHandCheck == 21)
                    {
                        double winnings = bet * 1.5; 
                        InfoLabel.Text = "BLACKJACK! You win : " + winnings + "\n" + "Please enter a new bet to play again";
                        //UPDATE SALDO +user*1.5 -bank
                        control.Transaction(Convert.ToInt32(bet), Convert.ToInt32(winnings));
                        control.ClearHands();
                        bet = 0;
                        HitButton.Hide();
                        StandButton.Hide();
                        DealButton.Show();
                        LeaveButton.Show();
                        MinBetBtn.Show();
                        MaxBetBtn.Show();
                        BetLabel.Show();
                        GameBalanceLabel.Text = control.GetBalance().ToString();
                    }
                    else
                    {
                        myTotal = "Your handtotal is : " + myHandCheck + "\n";
                        dealerTotal = "Dealer handtotal is : " + dealerHandCheck;
                        betString = "You bet " + bet + "\n"; 
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
        public void displayMyCards(List<string> list) //måste fixa om hur suit och value läses
        {
            try {
                string picture;
                if (list != null && list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i == 0)
                        {
                            picture = list[i];
                            YourHandPictureBox1.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            YourHandPictureBox1.Image = pic;
                            YourHandPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            YourHandPictureBox1.BringToFront();
                        }
                        else if (i == 1)
                        {
                            picture = list[i];
                            YourHandPictureBox2.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            YourHandPictureBox2.Image = pic;
                            YourHandPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                            YourHandPictureBox2.BringToFront();
                        }
                        else if (i == 2)
                        {
                            picture = list[i];
                            YourHandPictureBox3.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            YourHandPictureBox3.Image = pic;
                            YourHandPictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                            YourHandPictureBox3.BringToFront();
                        }
                        else if (i == 3)
                        {
                            picture = list[i];
                            YourHandPictureBox4.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            YourHandPictureBox4.Image = pic;
                            YourHandPictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                            YourHandPictureBox4.BringToFront();
                        }
                        else if (i == 4)
                        {
                            picture = list[i];
                            YourHandPictureBox5.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            YourHandPictureBox5.Image = pic;
                            YourHandPictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                            YourHandPictureBox5.BringToFront();
                        }
                        else if (i == 5)
                        {
                            picture = list[i];
                            YourHandPictureBox6.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            YourHandPictureBox6.Image = pic;
                            YourHandPictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                            YourHandPictureBox6.BringToFront();
                        }
                        else if (i == 6)
                        {
                            picture = list[i];
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
        public void displayDealerCards(List<string> list)
        {
            try {
                string picture;
                if (list != null && list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i == 0)
                        {
                            picture = list[i];
                            DealerPictureBox1.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            DealerPictureBox1.Image = pic;
                            DealerPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            DealerPictureBox1.BringToFront();
                        }
                        else if (i == 1)
                        {
                            picture = list[i];
                            DealerPictureBox2.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            DealerPictureBox2.Image = pic;
                            DealerPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                            DealerPictureBox2.BringToFront();
                        }
                        else if (i == 2)
                        {
                            picture = list[i];
                            DealerPictureBox3.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            DealerPictureBox3.Image = pic;
                            DealerPictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                            DealerPictureBox3.BringToFront();
                        }
                        else if (i == 3)
                        {
                            picture = list[i];
                            DealerPictureBox4.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            DealerPictureBox4.Image = pic;
                            DealerPictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                            DealerPictureBox4.BringToFront();
                        }
                        else if (i == 4)
                        {
                            picture = list[i];
                            DealerPictureBox5.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            DealerPictureBox5.Image = pic;
                            DealerPictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                            DealerPictureBox5.BringToFront();
                        }
                        else if (i == 5)
                        {
                            picture = list[i];
                            DealerPictureBox6.Visible = true;
                            System.Resources.ResourceManager rm = BlackJackSolution.Properties.Resources.ResourceManager;
                            Bitmap pic = (Bitmap)rm.GetObject(picture);
                            DealerPictureBox6.Image = pic;
                            DealerPictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                            DealerPictureBox6.BringToFront();
                        }
                        else if (i == 6)
                        {
                            picture = list[i];
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
                int myHandTot = control.CheckMyHand();
                if (myHandTot < 21)
                {
                    control.HitBtnPush();
                    myHandTot = control.CheckMyHand();
                    int dealerHandTot = control.CheckDealerHand();
                    if (myHandTot < 21)
                    {
                        myTotal = "Your handtotal is : " + myHandTot + "\n";
                        dealerTotal = "Dealer handtotal is : " + dealerHandTot;
                        betString = "You bet " + bet + "\n";
                        InfoLabel.Text = betString + myTotal + dealerTotal;
                        displayMyCards(control.GetMyPictureStrings());
                    } else if (myHandTot > 21)
                    {
                        InfoLabel.Text = "You are bust, dealer wins " + bet + "\n" + "Please enter a new bet to play again";
                        displayMyCards(control.GetMyPictureStrings());
                        HitButton.Hide();
                        StandButton.Hide();
                        DealButton.Show();
                        LeaveButton.Show();
                        MinBetBtn.Show();
                        MaxBetBtn.Show();
                        BetLabel.Show();
                        control.ClearHands();
                        control.Transaction(Convert.ToInt32(bet), Convert.ToInt32(bet-bet*2));
                        GameBalanceLabel.Text = control.GetBalance().ToString();
                        //UPDATE SALDO FÖR USER / BANK -user + dealer

                    } else if (myHandTot == 21)
                    {
                        InfoLabel.Text = "You have 21";
                        displayMyCards(control.GetMyPictureStrings());
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
                int Htot = control.CheckMyHand();
                control.StandBtnPush();
                int Dtot = control.CheckDealerHand();
                if (Dtot < 22)
                {
                    if (Htot > Dtot)
                    {
                        InfoLabel.Text = "The dealer has: " + Dtot + "\n" + "You have: " + Htot + "\n" + "You win: " + bet;
                        displayMyCards(control.GetMyPictureStrings());
                        displayDealerCards(control.GetDealerPictureStrings());
                        control.Transaction(Convert.ToInt32(bet), Convert.ToInt32(bet));
                        GameBalanceLabel.Text = control.GetBalance().ToString();
                        //UPDATE SALDO +user - bank
                    }
                    else if (Dtot > Htot)
                    {
                        InfoLabel.Text = "The dealer has: " + Dtot + "\n" + "You have: " + Htot + "\n" + "Dealer wins: " + bet;
                        displayMyCards(control.GetMyPictureStrings());
                        displayDealerCards(control.GetDealerPictureStrings());
                        control.Transaction(Convert.ToInt32(bet), Convert.ToInt32(bet - bet * 2));
                        GameBalanceLabel.Text = control.GetBalance().ToString();
                        //UPDATE SALDO -Bank +user
                    }
                    else if (Dtot == Htot)
                    {
                        InfoLabel.Text = "The dealer has: " + Dtot + "\n" + "You have: " + Htot + "\n" + "Dealer wins: " + bet;
                        displayMyCards(control.GetMyPictureStrings());
                        displayDealerCards(control.GetDealerPictureStrings());
                        control.Transaction(Convert.ToInt32(bet), Convert.ToInt32(bet - bet * 2));
                        GameBalanceLabel.Text = control.GetBalance().ToString();
                        //UPDATE SALDO -user +bank
                    }
                }
                else
                {
                    InfoLabel.Text = "The dealer is bust: " + Dtot + "\n" + "You have: " + Htot + "\n" + "You win: " + bet;
                    displayMyCards(control.GetMyPictureStrings());
                    displayDealerCards(control.GetDealerPictureStrings());
                    control.Transaction(Convert.ToInt32(bet), Convert.ToInt32(bet));
                    GameBalanceLabel.Text = control.GetBalance().ToString();
                    //UPDATE SALDO +user -bank
                }
                control.ClearHands();
                HitButton.Hide();
                StandButton.Hide();
                LeaveButton.Show();
                DealButton.Show();
                MinBetBtn.Show();
                MaxBetBtn.Show();
                BetLabel.Show();
            } catch (Exception eSB)
            {
                //Fattas
            }
        }

        private void LoginLoginButton_Click(object sender, EventArgs e)
        {
            try {
                bool loginOK;
                loginOK = control.Login(LoginUsernameTextBox.Text, LoginPasswordTextBox.Text);
                if (loginOK == true)
                {
                    MainPanel.Show();
                    LoginPanel.Hide();
                    GamePanel.Hide();
                    MainTableGroupBox.Show();
                    LoginPasswordTextBox.Clear();
                    LoginUsernameTextBox.Clear();
                    LoginCreatePWTextBox.Clear();
                    LoginCreateUnameTextBox.Clear();
                    LoginInfoLabel.Text = "";

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
                    if (control.GetUserStatus() == false)
                    {
                        MainTableThreePictureBox.Visible = false;
                    }
                }
                else
                {
                    LoginInfoLabel.Text = "Username or Password incorrect";
                }
            }
            catch(Exception loginE)
            {

            }
            
        }

        private void MainTableOnePictureBox_Click(object sender, EventArgs e)
        {
            MainPanel.Hide();
            GamePanel.Show();
            control.InitiateTable(0);
            MaxBetBtn.Text = control.GetMaxBet().ToString();
            MinBetBtn.Text = control.GetMinBet().ToString();
            GameBalanceLabel.Text = control.GetBalance().ToString();
        }

        private void LoginExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinBetBtn_Click(object sender, EventArgs e)
        {
            bet = control.GetMinBet();
            MinBetBtn.Hide();
            MaxBetBtn.Hide();
            BetLabel.Hide();
            clearCards();
            InfoLabel.Text = "You bet: " + bet + " press Deal to start game";
            double bal = Double.Parse(GameBalanceLabel.Text);
            bal -= bet;
            GameBalanceLabel.Text = bal.ToString();
        }

        private void MaxBetBtn_Click(object sender, EventArgs e)
        {
            bet = control.GetMaxBet();
            MinBetBtn.Hide();
            MaxBetBtn.Hide();
            BetLabel.Hide();
            clearCards();
            InfoLabel.Text = "You bet: " + bet + " press Deal to start game";
            double bal = Double.Parse(GameBalanceLabel.Text);
            bal -= bet;
            GameBalanceLabel.Text = bal.ToString();
        }

        private void LoginCreateCreateBtn_Click(object sender, EventArgs e)
        {
            if (LoginCreatePWTextBox.Text.Length > 2)
            {
                string acc = control.CreateAccount(LoginCreateUnameTextBox.Text, LoginCreatePWTextBox.Text);
                if (acc.Equals("True"))
                {
                    LoginInfoLabel.Text = "Account created";
                    LoginCreateGroupBox.Hide();
                    LoginCreatePWTextBox.Clear();
                    LoginCreateUnameTextBox.Clear();
                }
                else
                {
                    LoginInfoLabel.Text = "Account name already in use";
                    LoginCreatePWTextBox.Clear();
                    LoginCreateUnameTextBox.Clear();
                }
            }
            else
            {
                LoginInfoLabel.Text = "For your safety" + "\n" + "your password must be atleast 3 characters";
                LoginCreatePWTextBox.Clear();
            }
        }

        private void LoginCreateAccBtn_Click(object sender, EventArgs e)
        {
            LoginCreateGroupBox.Show();
        }

        private void MainAccountDeleteBtn_Click(object sender, EventArgs e)
        {
            //ta bort konto
            //rensa user
            MainPanel.Hide();
            LoginPanel.Show();
        }

        private void LoginPasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginPasswordLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

namespace BlackJackSolution
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.LogOutBtn = new System.Windows.Forms.Button();
            this.UpdateAccountBtn = new System.Windows.Forms.Button();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.GamePanel = new System.Windows.Forms.Panel();
            this.InfoGroupBox = new System.Windows.Forms.GroupBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.ActionGroupBox = new System.Windows.Forms.GroupBox();
            this.BetLabelAmount = new System.Windows.Forms.Label();
            this.BetLabel = new System.Windows.Forms.Label();
            this.BetAmountText = new System.Windows.Forms.TextBox();
            this.LeaveButton = new System.Windows.Forms.Button();
            this.DealButton = new System.Windows.Forms.Button();
            this.StandButton = new System.Windows.Forms.Button();
            this.HitButton = new System.Windows.Forms.Button();
            this.YourHandGroupBox = new System.Windows.Forms.GroupBox();
            this.YourHandPictureBox7 = new System.Windows.Forms.PictureBox();
            this.YourHandPictureBox6 = new System.Windows.Forms.PictureBox();
            this.YourHandPictureBox5 = new System.Windows.Forms.PictureBox();
            this.YourHandPictureBox4 = new System.Windows.Forms.PictureBox();
            this.YourHandPictureBox3 = new System.Windows.Forms.PictureBox();
            this.YourHandPictureBox2 = new System.Windows.Forms.PictureBox();
            this.YourHandPictureBox1 = new System.Windows.Forms.PictureBox();
            this.DealerHandGroupBox = new System.Windows.Forms.GroupBox();
            this.DealerPictureBox7 = new System.Windows.Forms.PictureBox();
            this.DealerPictureBox6 = new System.Windows.Forms.PictureBox();
            this.DealerPictureBox5 = new System.Windows.Forms.PictureBox();
            this.DealerPictureBox4 = new System.Windows.Forms.PictureBox();
            this.DealerPictureBox3 = new System.Windows.Forms.PictureBox();
            this.DealerPictureBox2 = new System.Windows.Forms.PictureBox();
            this.DealerPictureBox1 = new System.Windows.Forms.PictureBox();
            this.MainPanel.SuspendLayout();
            this.GamePanel.SuspendLayout();
            this.InfoGroupBox.SuspendLayout();
            this.ActionGroupBox.SuspendLayout();
            this.YourHandGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YourHandPictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YourHandPictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YourHandPictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YourHandPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YourHandPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YourHandPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YourHandPictureBox1)).BeginInit();
            this.DealerHandGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DealerPictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerPictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerPictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.LogOutBtn);
            this.MainPanel.Controls.Add(this.UpdateAccountBtn);
            this.MainPanel.Location = new System.Drawing.Point(6, 4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1241, 654);
            this.MainPanel.TabIndex = 0;
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.Location = new System.Drawing.Point(979, 529);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(206, 77);
            this.LogOutBtn.TabIndex = 1;
            this.LogOutBtn.Text = "Logout";
            this.LogOutBtn.UseVisualStyleBackColor = true;
            this.LogOutBtn.Click += new System.EventHandler(this.LogOutBtn_Click);
            // 
            // UpdateAccountBtn
            // 
            this.UpdateAccountBtn.Location = new System.Drawing.Point(703, 529);
            this.UpdateAccountBtn.Name = "UpdateAccountBtn";
            this.UpdateAccountBtn.Size = new System.Drawing.Size(206, 77);
            this.UpdateAccountBtn.TabIndex = 0;
            this.UpdateAccountBtn.Text = "Account options";
            this.UpdateAccountBtn.UseVisualStyleBackColor = true;
            // 
            // LoginPanel
            // 
            this.LoginPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(1235, 654);
            this.LoginPanel.TabIndex = 2;
            // 
            // GamePanel
            // 
            this.GamePanel.Controls.Add(this.InfoGroupBox);
            this.GamePanel.Controls.Add(this.ActionGroupBox);
            this.GamePanel.Controls.Add(this.YourHandGroupBox);
            this.GamePanel.Controls.Add(this.DealerHandGroupBox);
            this.GamePanel.Location = new System.Drawing.Point(0, 0);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(1238, 649);
            this.GamePanel.TabIndex = 3;
            // 
            // InfoGroupBox
            // 
            this.InfoGroupBox.BackColor = System.Drawing.Color.White;
            this.InfoGroupBox.Controls.Add(this.InfoLabel);
            this.InfoGroupBox.Location = new System.Drawing.Point(30, 497);
            this.InfoGroupBox.Name = "InfoGroupBox";
            this.InfoGroupBox.Size = new System.Drawing.Size(654, 124);
            this.InfoGroupBox.TabIndex = 18;
            this.InfoGroupBox.TabStop = false;
            this.InfoGroupBox.Text = "Information";
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Location = new System.Drawing.Point(30, 49);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(0, 17);
            this.InfoLabel.TabIndex = 0;
            // 
            // ActionGroupBox
            // 
            this.ActionGroupBox.Controls.Add(this.BetLabelAmount);
            this.ActionGroupBox.Controls.Add(this.BetLabel);
            this.ActionGroupBox.Controls.Add(this.BetAmountText);
            this.ActionGroupBox.Controls.Add(this.LeaveButton);
            this.ActionGroupBox.Controls.Add(this.DealButton);
            this.ActionGroupBox.Controls.Add(this.StandButton);
            this.ActionGroupBox.Controls.Add(this.HitButton);
            this.ActionGroupBox.Location = new System.Drawing.Point(709, 497);
            this.ActionGroupBox.Name = "ActionGroupBox";
            this.ActionGroupBox.Size = new System.Drawing.Size(413, 125);
            this.ActionGroupBox.TabIndex = 17;
            this.ActionGroupBox.TabStop = false;
            this.ActionGroupBox.Text = "Actions";
            // 
            // BetLabelAmount
            // 
            this.BetLabelAmount.AutoSize = true;
            this.BetLabelAmount.Location = new System.Drawing.Point(160, 64);
            this.BetLabelAmount.Name = "BetLabelAmount";
            this.BetLabelAmount.Size = new System.Drawing.Size(0, 17);
            this.BetLabelAmount.TabIndex = 7;
            this.BetLabelAmount.Visible = false;
            // 
            // BetLabel
            // 
            this.BetLabel.AutoSize = true;
            this.BetLabel.Location = new System.Drawing.Point(168, 36);
            this.BetLabel.Name = "BetLabel";
            this.BetLabel.Size = new System.Drawing.Size(29, 17);
            this.BetLabel.TabIndex = 6;
            this.BetLabel.Text = "Bet";
            // 
            // BetAmountText
            // 
            this.BetAmountText.Location = new System.Drawing.Point(148, 84);
            this.BetAmountText.Name = "BetAmountText";
            this.BetAmountText.Size = new System.Drawing.Size(75, 22);
            this.BetAmountText.TabIndex = 5;
            // 
            // LeaveButton
            // 
            this.LeaveButton.BackColor = System.Drawing.Color.Red;
            this.LeaveButton.Location = new System.Drawing.Point(279, 76);
            this.LeaveButton.Name = "LeaveButton";
            this.LeaveButton.Size = new System.Drawing.Size(75, 30);
            this.LeaveButton.TabIndex = 3;
            this.LeaveButton.Text = "Leave";
            this.LeaveButton.UseVisualStyleBackColor = false;
            this.LeaveButton.Click += new System.EventHandler(this.LeaveButton_Click);
            // 
            // DealButton
            // 
            this.DealButton.BackColor = System.Drawing.Color.Lime;
            this.DealButton.Location = new System.Drawing.Point(279, 36);
            this.DealButton.Name = "DealButton";
            this.DealButton.Size = new System.Drawing.Size(75, 30);
            this.DealButton.TabIndex = 2;
            this.DealButton.Text = "Deal";
            this.DealButton.UseVisualStyleBackColor = false;
            this.DealButton.Click += new System.EventHandler(this.DealButton_Click);
            // 
            // StandButton
            // 
            this.StandButton.Location = new System.Drawing.Point(16, 76);
            this.StandButton.Name = "StandButton";
            this.StandButton.Size = new System.Drawing.Size(75, 30);
            this.StandButton.TabIndex = 1;
            this.StandButton.Text = "Stand";
            this.StandButton.UseVisualStyleBackColor = true;
            this.StandButton.Visible = false;
            this.StandButton.Click += new System.EventHandler(this.StandButton_Click);
            // 
            // HitButton
            // 
            this.HitButton.Location = new System.Drawing.Point(16, 36);
            this.HitButton.Name = "HitButton";
            this.HitButton.Size = new System.Drawing.Size(75, 30);
            this.HitButton.TabIndex = 0;
            this.HitButton.Text = "Hit";
            this.HitButton.UseVisualStyleBackColor = true;
            this.HitButton.Visible = false;
            this.HitButton.Click += new System.EventHandler(this.HitButton_Click);
            // 
            // YourHandGroupBox
            // 
            this.YourHandGroupBox.Controls.Add(this.YourHandPictureBox7);
            this.YourHandGroupBox.Controls.Add(this.YourHandPictureBox6);
            this.YourHandGroupBox.Controls.Add(this.YourHandPictureBox5);
            this.YourHandGroupBox.Controls.Add(this.YourHandPictureBox4);
            this.YourHandGroupBox.Controls.Add(this.YourHandPictureBox3);
            this.YourHandGroupBox.Controls.Add(this.YourHandPictureBox2);
            this.YourHandGroupBox.Controls.Add(this.YourHandPictureBox1);
            this.YourHandGroupBox.Location = new System.Drawing.Point(23, 263);
            this.YourHandGroupBox.Name = "YourHandGroupBox";
            this.YourHandGroupBox.Size = new System.Drawing.Size(1099, 200);
            this.YourHandGroupBox.TabIndex = 16;
            this.YourHandGroupBox.TabStop = false;
            this.YourHandGroupBox.Text = "Your Hand";
            // 
            // YourHandPictureBox7
            // 
            this.YourHandPictureBox7.Location = new System.Drawing.Point(958, 21);
            this.YourHandPictureBox7.Name = "YourHandPictureBox7";
            this.YourHandPictureBox7.Size = new System.Drawing.Size(117, 164);
            this.YourHandPictureBox7.TabIndex = 14;
            this.YourHandPictureBox7.TabStop = false;
            this.YourHandPictureBox7.Visible = false;
            // 
            // YourHandPictureBox6
            // 
            this.YourHandPictureBox6.Location = new System.Drawing.Point(808, 21);
            this.YourHandPictureBox6.Name = "YourHandPictureBox6";
            this.YourHandPictureBox6.Size = new System.Drawing.Size(120, 164);
            this.YourHandPictureBox6.TabIndex = 13;
            this.YourHandPictureBox6.TabStop = false;
            this.YourHandPictureBox6.Visible = false;
            // 
            // YourHandPictureBox5
            // 
            this.YourHandPictureBox5.Location = new System.Drawing.Point(644, 21);
            this.YourHandPictureBox5.Name = "YourHandPictureBox5";
            this.YourHandPictureBox5.Size = new System.Drawing.Size(120, 164);
            this.YourHandPictureBox5.TabIndex = 12;
            this.YourHandPictureBox5.TabStop = false;
            this.YourHandPictureBox5.Visible = false;
            // 
            // YourHandPictureBox4
            // 
            this.YourHandPictureBox4.Location = new System.Drawing.Point(483, 21);
            this.YourHandPictureBox4.Name = "YourHandPictureBox4";
            this.YourHandPictureBox4.Size = new System.Drawing.Size(120, 164);
            this.YourHandPictureBox4.TabIndex = 11;
            this.YourHandPictureBox4.TabStop = false;
            this.YourHandPictureBox4.Visible = false;
            // 
            // YourHandPictureBox3
            // 
            this.YourHandPictureBox3.Location = new System.Drawing.Point(318, 21);
            this.YourHandPictureBox3.Name = "YourHandPictureBox3";
            this.YourHandPictureBox3.Size = new System.Drawing.Size(120, 164);
            this.YourHandPictureBox3.TabIndex = 10;
            this.YourHandPictureBox3.TabStop = false;
            this.YourHandPictureBox3.Visible = false;
            // 
            // YourHandPictureBox2
            // 
            this.YourHandPictureBox2.Location = new System.Drawing.Point(167, 21);
            this.YourHandPictureBox2.Name = "YourHandPictureBox2";
            this.YourHandPictureBox2.Size = new System.Drawing.Size(120, 164);
            this.YourHandPictureBox2.TabIndex = 9;
            this.YourHandPictureBox2.TabStop = false;
            this.YourHandPictureBox2.Visible = false;
            // 
            // YourHandPictureBox1
            // 
            this.YourHandPictureBox1.Location = new System.Drawing.Point(16, 21);
            this.YourHandPictureBox1.Name = "YourHandPictureBox1";
            this.YourHandPictureBox1.Size = new System.Drawing.Size(120, 164);
            this.YourHandPictureBox1.TabIndex = 8;
            this.YourHandPictureBox1.TabStop = false;
            this.YourHandPictureBox1.Visible = false;
            // 
            // DealerHandGroupBox
            // 
            this.DealerHandGroupBox.Controls.Add(this.DealerPictureBox7);
            this.DealerHandGroupBox.Controls.Add(this.DealerPictureBox6);
            this.DealerHandGroupBox.Controls.Add(this.DealerPictureBox5);
            this.DealerHandGroupBox.Controls.Add(this.DealerPictureBox4);
            this.DealerHandGroupBox.Controls.Add(this.DealerPictureBox3);
            this.DealerHandGroupBox.Controls.Add(this.DealerPictureBox2);
            this.DealerHandGroupBox.Controls.Add(this.DealerPictureBox1);
            this.DealerHandGroupBox.Location = new System.Drawing.Point(23, 48);
            this.DealerHandGroupBox.Name = "DealerHandGroupBox";
            this.DealerHandGroupBox.Size = new System.Drawing.Size(1100, 199);
            this.DealerHandGroupBox.TabIndex = 15;
            this.DealerHandGroupBox.TabStop = false;
            this.DealerHandGroupBox.Text = "Dealer Hand";
            this.DealerHandGroupBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // DealerPictureBox7
            // 
            this.DealerPictureBox7.Location = new System.Drawing.Point(959, 21);
            this.DealerPictureBox7.Name = "DealerPictureBox7";
            this.DealerPictureBox7.Size = new System.Drawing.Size(120, 164);
            this.DealerPictureBox7.TabIndex = 7;
            this.DealerPictureBox7.TabStop = false;
            this.DealerPictureBox7.Visible = false;
            // 
            // DealerPictureBox6
            // 
            this.DealerPictureBox6.Location = new System.Drawing.Point(808, 21);
            this.DealerPictureBox6.Name = "DealerPictureBox6";
            this.DealerPictureBox6.Size = new System.Drawing.Size(120, 164);
            this.DealerPictureBox6.TabIndex = 6;
            this.DealerPictureBox6.TabStop = false;
            this.DealerPictureBox6.Visible = false;
            // 
            // DealerPictureBox5
            // 
            this.DealerPictureBox5.Location = new System.Drawing.Point(644, 21);
            this.DealerPictureBox5.Name = "DealerPictureBox5";
            this.DealerPictureBox5.Size = new System.Drawing.Size(120, 164);
            this.DealerPictureBox5.TabIndex = 5;
            this.DealerPictureBox5.TabStop = false;
            this.DealerPictureBox5.Visible = false;
            // 
            // DealerPictureBox4
            // 
            this.DealerPictureBox4.Location = new System.Drawing.Point(483, 21);
            this.DealerPictureBox4.Name = "DealerPictureBox4";
            this.DealerPictureBox4.Size = new System.Drawing.Size(120, 164);
            this.DealerPictureBox4.TabIndex = 4;
            this.DealerPictureBox4.TabStop = false;
            this.DealerPictureBox4.Visible = false;
            // 
            // DealerPictureBox3
            // 
            this.DealerPictureBox3.Location = new System.Drawing.Point(318, 21);
            this.DealerPictureBox3.Name = "DealerPictureBox3";
            this.DealerPictureBox3.Size = new System.Drawing.Size(120, 164);
            this.DealerPictureBox3.TabIndex = 3;
            this.DealerPictureBox3.TabStop = false;
            this.DealerPictureBox3.Visible = false;
            // 
            // DealerPictureBox2
            // 
            this.DealerPictureBox2.Location = new System.Drawing.Point(167, 21);
            this.DealerPictureBox2.Name = "DealerPictureBox2";
            this.DealerPictureBox2.Size = new System.Drawing.Size(120, 164);
            this.DealerPictureBox2.TabIndex = 2;
            this.DealerPictureBox2.TabStop = false;
            this.DealerPictureBox2.Visible = false;
            // 
            // DealerPictureBox1
            // 
            this.DealerPictureBox1.Location = new System.Drawing.Point(16, 21);
            this.DealerPictureBox1.Name = "DealerPictureBox1";
            this.DealerPictureBox1.Size = new System.Drawing.Size(120, 164);
            this.DealerPictureBox1.TabIndex = 1;
            this.DealerPictureBox1.TabStop = false;
            this.DealerPictureBox1.Visible = false;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.GamePanel);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.MainPanel);
            this.Name = "GUI";
            this.Text = "Blackjack";
            this.MainPanel.ResumeLayout(false);
            this.GamePanel.ResumeLayout(false);
            this.InfoGroupBox.ResumeLayout(false);
            this.InfoGroupBox.PerformLayout();
            this.ActionGroupBox.ResumeLayout(false);
            this.ActionGroupBox.PerformLayout();
            this.YourHandGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.YourHandPictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YourHandPictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YourHandPictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YourHandPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YourHandPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YourHandPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YourHandPictureBox1)).EndInit();
            this.DealerHandGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DealerPictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerPictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerPictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button UpdateAccountBtn;
        private System.Windows.Forms.Button LogOutBtn;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.GroupBox DealerHandGroupBox;
        private System.Windows.Forms.PictureBox DealerPictureBox7;
        private System.Windows.Forms.PictureBox DealerPictureBox6;
        private System.Windows.Forms.PictureBox DealerPictureBox5;
        private System.Windows.Forms.PictureBox DealerPictureBox4;
        private System.Windows.Forms.PictureBox DealerPictureBox3;
        private System.Windows.Forms.PictureBox DealerPictureBox2;
        private System.Windows.Forms.PictureBox DealerPictureBox1;
        private System.Windows.Forms.PictureBox YourHandPictureBox7;
        private System.Windows.Forms.PictureBox YourHandPictureBox6;
        private System.Windows.Forms.PictureBox YourHandPictureBox5;
        private System.Windows.Forms.PictureBox YourHandPictureBox4;
        private System.Windows.Forms.PictureBox YourHandPictureBox3;
        private System.Windows.Forms.PictureBox YourHandPictureBox2;
        private System.Windows.Forms.PictureBox YourHandPictureBox1;
        private System.Windows.Forms.GroupBox ActionGroupBox;
        private System.Windows.Forms.GroupBox YourHandGroupBox;
        private System.Windows.Forms.GroupBox InfoGroupBox;
        private System.Windows.Forms.Label BetLabel;
        private System.Windows.Forms.TextBox BetAmountText;
        private System.Windows.Forms.Button LeaveButton;
        private System.Windows.Forms.Button DealButton;
        private System.Windows.Forms.Button StandButton;
        private System.Windows.Forms.Button HitButton;
        private System.Windows.Forms.Label BetLabelAmount;
        private System.Windows.Forms.Label InfoLabel;
    }
}


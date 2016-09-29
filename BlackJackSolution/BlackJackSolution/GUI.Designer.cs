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
            this.UpdateAccountBtn = new System.Windows.Forms.Button();
            this.LogOutBtn = new System.Windows.Forms.Button();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.GamePanel = new System.Windows.Forms.Panel();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.LogOutBtn);
            this.MainPanel.Controls.Add(this.UpdateAccountBtn);
            this.MainPanel.Location = new System.Drawing.Point(30, 18);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1108, 593);
            this.MainPanel.TabIndex = 0;
            // 
            // UpdateAccountBtn
            // 
            this.UpdateAccountBtn.Location = new System.Drawing.Point(602, 471);
            this.UpdateAccountBtn.Name = "UpdateAccountBtn";
            this.UpdateAccountBtn.Size = new System.Drawing.Size(206, 77);
            this.UpdateAccountBtn.TabIndex = 0;
            this.UpdateAccountBtn.Text = "Account options";
            this.UpdateAccountBtn.UseVisualStyleBackColor = true;
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.Location = new System.Drawing.Point(849, 471);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(206, 77);
            this.LogOutBtn.TabIndex = 1;
            this.LogOutBtn.Text = "Logout";
            this.LogOutBtn.UseVisualStyleBackColor = true;
            this.LogOutBtn.Click += new System.EventHandler(this.LogOutBtn_Click);
            // 
            // LoginPanel
            // 
            this.LoginPanel.Location = new System.Drawing.Point(44, 15);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(1108, 593);
            this.LoginPanel.TabIndex = 2;
            // 
            // GamePanel
            // 
            this.GamePanel.Location = new System.Drawing.Point(60, 12);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(1108, 593);
            this.GamePanel.TabIndex = 3;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.GamePanel);
            this.Name = "GUI";
            this.Text = "Blackjack";
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button UpdateAccountBtn;
        private System.Windows.Forms.Button LogOutBtn;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Panel GamePanel;
    }
}


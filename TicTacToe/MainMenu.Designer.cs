namespace TicTacToe
{
    partial class MainMenu
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPlayerVSComputer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPlayerVSPlayerLan = new System.Windows.Forms.Button();
            this.btnPlayerVSPlayer = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPlayerVSComputer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Single Player";
            // 
            // btnPlayerVSComputer
            // 
            this.btnPlayerVSComputer.Location = new System.Drawing.Point(6, 19);
            this.btnPlayerVSComputer.Name = "btnPlayerVSComputer";
            this.btnPlayerVSComputer.Size = new System.Drawing.Size(299, 43);
            this.btnPlayerVSComputer.TabIndex = 0;
            this.btnPlayerVSComputer.Text = "Player vs Computer";
            this.btnPlayerVSComputer.UseVisualStyleBackColor = true;
            this.btnPlayerVSComputer.Click += new System.EventHandler(this.btnPlayerVSComputer_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPlayerVSPlayerLan);
            this.groupBox2.Controls.Add(this.btnPlayerVSPlayer);
            this.groupBox2.Location = new System.Drawing.Point(12, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 129);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Multiplayer";
            // 
            // btnPlayerVSPlayerLan
            // 
            this.btnPlayerVSPlayerLan.Location = new System.Drawing.Point(6, 68);
            this.btnPlayerVSPlayerLan.Name = "btnPlayerVSPlayerLan";
            this.btnPlayerVSPlayerLan.Size = new System.Drawing.Size(299, 43);
            this.btnPlayerVSPlayerLan.TabIndex = 1;
            this.btnPlayerVSPlayerLan.Text = "Player vs Player [ LAN ]";
            this.btnPlayerVSPlayerLan.UseVisualStyleBackColor = true;
            // 
            // btnPlayerVSPlayer
            // 
            this.btnPlayerVSPlayer.Location = new System.Drawing.Point(6, 19);
            this.btnPlayerVSPlayer.Name = "btnPlayerVSPlayer";
            this.btnPlayerVSPlayer.Size = new System.Drawing.Size(299, 43);
            this.btnPlayerVSPlayer.TabIndex = 0;
            this.btnPlayerVSPlayer.Text = "Player vs Player";
            this.btnPlayerVSPlayer.UseVisualStyleBackColor = true;
            this.btnPlayerVSPlayer.Click += new System.EventHandler(this.btnPlayerVSPlayer_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(242, 234);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 3;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 269);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainMenu";
            this.Text = "TicTacToe 6002526 : MainMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPlayerVSComputer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPlayerVSPlayer;
        private System.Windows.Forms.Button btnPlayerVSPlayerLan;
        private System.Windows.Forms.Button btnAbout;
    }
}
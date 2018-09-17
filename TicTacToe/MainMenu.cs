
using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            GameMenu.GreetMenu.Close();
        }

        void btnPlayerVSComputer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Game.Start();
            GameMenu.PlayerVsComputerBoard.Show();
        }

        void btnPlayerVSPlayer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Game.Start();
            GameMenu.PlayerVsPlayerBoard.Show();
        }

        void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Author : \n" +
                "Chatchai Saratakij (6002526)"
            );
        }
    }
}

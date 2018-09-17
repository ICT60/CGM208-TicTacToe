
using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class GreetMenu : Form
    {
        public GreetMenu()
        {
            InitializeComponent();
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            GameMenu.GreetMenu = this;
            GameMenu.MainMenu = new MainMenu();
            GameMenu.PlayerVsComputerBoard = new PlayerVsComputerBoard();
            GameMenu.PlayerVsPlayerBoard = new PlayerVsPlayerBoard();
        }

        void btnStart_Click(object sender, EventArgs e)
        {
            GameMenu.MainMenu.Show();
            this.Hide();
        }

        void GreetMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            DialogResult promptResult = MessageBox.Show(
                "Are you sure to quit?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );
            e.Cancel = !(DialogResult.Yes == promptResult);
        }
    }
}


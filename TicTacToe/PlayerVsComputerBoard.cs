
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace TicTacToe
{
    public partial class PlayerVsComputerBoard : Form
    {
        const int MAX_TARGET = 9;

        const string CURRENT_TURN_FORMAT = "Turn : {0}";
        const string CURRENT_WINNER_FORMAT = "Winner : {0}";

        Player[] players;
        Button[] numericButtons;

        Color highlightColor;

        int currentPlayerIndex;
        ushort selectedBoardFlag;

        List<int> computerPickTarget;

        public bool IsBoardFull => (selectedBoardFlag == 0x01ff);


        public PlayerVsComputerBoard()
        {
            InitializeComponent();
        }

        void Initialize()
        {
            numericButtons = new Button[] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            players = new Player[2];
            selectedBoardFlag = 0;
            currentPlayerIndex = 0;
            highlightColor = Color.Red;
            computerPickTarget = new List<int>();
        }

        void ResetData()
        {
            lblTurn.Text = string.Format(CURRENT_TURN_FORMAT, string.Empty);

            foreach (Button button in numericButtons)
            {
                button.Text = string.Empty;
                button.ForeColor = Color.Black;
            }

            players[0].marker = 'X';
            players[0].isWin = false;
            players[0].selectedTarget = 0;

            players[1].marker = 'O';
            players[1].isWin = false;
            players[1].selectedTarget = 0;

            selectedBoardFlag = 0;
            currentPlayerIndex = 0;

            computerPickTarget.Clear();

            for (int i = 1; i <= MAX_TARGET; ++i)
            {
                computerPickTarget.Add(i);
            }
        }

        void SubscribeEvents()
        {
            Game.OnStart += OnGameStart;
            Game.OnOver += OnGameOver;

            btn1.Click += OnNumericButton_Click;
            btn2.Click += OnNumericButton_Click;
            btn3.Click += OnNumericButton_Click;
            btn4.Click += OnNumericButton_Click;
            btn5.Click += OnNumericButton_Click;
            btn6.Click += OnNumericButton_Click;
            btn7.Click += OnNumericButton_Click;
            btn8.Click += OnNumericButton_Click;
            btn9.Click += OnNumericButton_Click;
        }

        void UnsubscribeEvents()
        {
            Game.OnStart -= OnGameStart;
            Game.OnOver -= OnGameOver;

            btn1.Click -= OnNumericButton_Click;
            btn2.Click -= OnNumericButton_Click;
            btn3.Click -= OnNumericButton_Click;
            btn4.Click -= OnNumericButton_Click;
            btn5.Click -= OnNumericButton_Click;
            btn6.Click -= OnNumericButton_Click;
            btn7.Click -= OnNumericButton_Click;
            btn8.Click -= OnNumericButton_Click;
            btn9.Click -= OnNumericButton_Click;
        }

        void OnGameStart()
        {
            ResetData();
            ShowPlayerTurn(currentPlayerIndex);
        }

        void OnGameOver()
        {
            if (players[0].isWin)
            {
                ShowWinner(0);
                HighlightWinFlag(0);
                MessageBox.Show("Player (X) : Win");
            }
            else if (players[1].isWin)
            {
                ShowWinner(1);
                HighlightWinFlag(1);
                MessageBox.Show("Computer (O) : Win");
            }
            else
            {
                if (!IsBoardFull)
                    return;

                ShowTie();
                MessageBox.Show("Tie");
            }
        }

        void OnNumericButton_Click(object sender, EventArgs e)
        {
            if (!Game.IsGameStart)
                return;

            int pickNumber = 0;

            if (btn1.Equals(sender))
                pickNumber = 1;

            else if (btn2.Equals(sender))
                pickNumber = 2;

            else if (btn3.Equals(sender))
                pickNumber = 3;

            else if (btn4.Equals(sender))
                pickNumber = 4;

            else if (btn5.Equals(sender))
                pickNumber = 5;

            else if (btn6.Equals(sender))
                pickNumber = 6;

            else if (btn7.Equals(sender))
                pickNumber = 7;

            else if (btn8.Equals(sender))
                pickNumber = 8;

            else if (btn9.Equals(sender))
                pickNumber = 9;

            else
                return;

            ushort selectTarget = (ushort)(1 << (pickNumber - 1));
            bool isCanSelectTarget = !((selectedBoardFlag & selectTarget) == selectTarget);

            if (!isCanSelectTarget)
                return;

            selectedBoardFlag |= selectTarget;
            computerPickTarget.Remove(pickNumber);

            Button clickedButton = sender as Button;
            clickedButton.Text = players[currentPlayerIndex].marker + "";

            players[currentPlayerIndex].selectedTarget |= selectTarget;
            players[currentPlayerIndex].isWin = Game.IsWinner(players[currentPlayerIndex]);

            if (players[currentPlayerIndex].isWin || IsBoardFull)
            {
                Game.Over();
                return;
            }

            currentPlayerIndex = 1;
            ShowPlayerTurn(1);

            ComputerPickTarget();
        }

        void ComputerPickTarget()
        {
            Random rand = new Random();

            int index = rand.Next(0, computerPickTarget.Count);
            int pickNumber = computerPickTarget[index];

            computerPickTarget.Remove(pickNumber);

            ushort selectTarget = (ushort)(1 << (pickNumber - 1));
            selectedBoardFlag |= selectTarget;

            Button clickedButton = numericButtons[pickNumber - 1];
            clickedButton.Text = players[currentPlayerIndex].marker + "";

            players[currentPlayerIndex].selectedTarget |= selectTarget;
            players[currentPlayerIndex].isWin = Game.IsWinner(players[currentPlayerIndex]);

            if (players[currentPlayerIndex].isWin || IsBoardFull)
            {
                Game.Over();
                return;
            }

            currentPlayerIndex = 0;
            ShowPlayerTurn(0);
        }

        void ShowPlayerTurn(int index)
        {
            UpdateStatusLabel(CURRENT_TURN_FORMAT, index);
        }

        void ShowWinner(int index)
        {
            UpdateStatusLabel(CURRENT_WINNER_FORMAT, index);
        }

        void ShowTie()
        {
            lblTurn.Text = "Tie :(";
        }

        void UpdateStatusLabel(string format, int index)
        {
            string statusText = (index == 0) ? string.Format(format, "Player ") : string.Format(format, "Computer ");
            statusText += string.Format("({0})", players[index].marker);
            lblTurn.Text = statusText;
        }

        void HighlightWinFlag(int winnerIndex)
        {
            ushort winFlag = 0;

            foreach (ushort flag in Game.WinConditions)
            {
                if ((flag & players[winnerIndex].selectedTarget) == flag)
                {
                    winFlag = flag;
                    break;
                }
            }

            if (winFlag <= 0)
                return;

            for (int i = 0; i < MAX_TARGET; ++i)
            {
                ushort testFlag = (ushort)(1 << i);
                if ((winFlag & testFlag) == testFlag)
                    numericButtons[i].ForeColor = highlightColor;
            }
        }

        void PlayerVsComputerBoard_Load(object sender, EventArgs e)
        {
            Initialize();
            SubscribeEvents();
            ResetData();
            ShowPlayerTurn(currentPlayerIndex);
        }

        void PlayerVsComputerBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            DialogResult promptResult = MessageBox.Show(
                "Back to mainmenu?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );

            if (DialogResult.Yes != promptResult)
                return;

            Game.Over();
            ResetData();

            this.Hide();
            GameMenu.MainMenu.Show();
        }

        void btnRestart_Click(object sender, EventArgs e)
        {
            Game.Over();
            Game.Start();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05_C16
{
    public partial class FormBoard : Form
    {
        private const int k_ButtonCardHeight = 75;
        private const int k_ButtonCardWidth = 75;
        private const int k_SpaceBetweenCards = 20;
        private const int k_PlayerNameLabelHeight = 40;
        private const int k_PlayerNameLabelWidth = 300;
        private Label m_CurrentPlayerLabel;

        public static int SpaceBetweenCards
        {
            get { return k_SpaceBetweenCards; }
        }

        public Label CurrentPlayerLabel
        {
            get
            {
                return m_CurrentPlayerLabel;
            }

            set
            {
                m_CurrentPlayerLabel = value;
            }
        }

        public FormBoard()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            Display.TheGame.CurrentPlayerChange += gameManager_CurrentPlayerChange;
            Display.TheGame.GameOver += gameManager_GameOver;
        }

        private void FormBoard_Load(object sender, EventArgs e)
        {
            loadBoard();
            loadLables();
        }

        private void loadBoard()
        {
            for (int i = 0; i < Display.TheGame.MainBoard.Rows; i++)
            {
                for (int j = 0; j < Display.TheGame.MainBoard.Cols; j++)
                {
                    {
                        Button buttonCard = new Button();

                        buttonCard.FlatStyle = FlatStyle.System;
                        //buttonCard.BackColor = Color.LightGray;
                        buttonCard.Text = String.Empty;
                        buttonCard.Name = i + "," + j;
                        buttonCard.Size = new System.Drawing.Size(k_ButtonCardWidth, k_ButtonCardHeight);
                        Display.SetLocationOfCard(i, j, buttonCard);
                        buttonCard.Click += buttonCard_Click;
                        this.Controls.Add(buttonCard);
                        Display.TheGame.MainBoard.GameBoard[i, j].IsOpenChange += cell_IsOpenChange;
                    }
                }
            }
        }

        private void loadLables()
        {
            //current player :
            m_CurrentPlayerLabel = new System.Windows.Forms.Label();

            m_CurrentPlayerLabel.Text = "Current Player:  " + Display.TheGame.CurrentPlayer.Name;
            m_CurrentPlayerLabel.BackColor = Display.TheGame.CurrentPlayer.Color;
            m_CurrentPlayerLabel.Size = new System.Drawing.Size(k_PlayerNameLabelWidth, k_PlayerNameLabelHeight);
            int totalHeightOfBoard = (k_ButtonCardHeight + k_SpaceBetweenCards) * Display.TheGame.MainBoard.Rows;
            m_CurrentPlayerLabel.Location = new System.Drawing.Point(k_SpaceBetweenCards, totalHeightOfBoard + k_PlayerNameLabelHeight);
            this.Controls.Add(m_CurrentPlayerLabel);

            //players names and score :
            int i = 0;

            foreach(Player player in Display.TheGame.Players)
            {
                Label playerName = new System.Windows.Forms.Label();

                i++;
                playerName.Name = player.Name;
                playerName.Text = player.Name + ":   " + player.NumOfPairsSucceeded;
                playerName.BackColor = player.Color;
                playerName.Size = new System.Drawing.Size(k_PlayerNameLabelWidth, k_PlayerNameLabelHeight);
                playerName.Location = new System.Drawing.Point(k_SpaceBetweenCards, m_CurrentPlayerLabel.Location.Y + (k_SpaceBetweenCards + k_PlayerNameLabelHeight * i));
                this.Controls.Add(playerName);
                player.NumOfPairsSucceededChange += player_NumOfPairsSucceededChange;
            }
            
        }

        void player_NumOfPairsSucceededChange(object sender)
        {
            Control relevantLabel = this.Controls.Find((sender as Player).Name, true)[0];
            relevantLabel.Text = (sender as Player).Name + ":   " + (sender as Player).NumOfPairsSucceeded;
            relevantLabel.Refresh();
        }

        private void buttonCard_Click (object sender, EventArgs e)
        {
            try
            {
                // $G$ DSN-001 (-7) You should have used an inherited control (inherited from Button) in order to save additional data on each control 
                string[] rowAndCol = (sender as Button).Name.Split(',');
                int row = int.Parse(rowAndCol[0]);
                int col = int.Parse(rowAndCol[1]);
                Display.TheGame.GetCellToOpen(row, col);
                Display.TheGame.AfterTwoCardsAreOpen();
            }
            catch (Exception exception)
            {
                string caption = "Error!";
                MessageBoxButtons okButton = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(exception.Message, caption, okButton);
            }
        }

        public void gameManager_GameOver(object sender)
        {
            string winnerOrTieMessage = Display.TheGame.GetWinnerOrTieMessage();
            winnerOrTieMessage += System.Environment.NewLine + "Do You Want To Play Another Round?";
            string caption = "Game Over";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(winnerOrTieMessage,caption,buttons);

            if (result == DialogResult.Yes)
            {
                Display.TheGame.ResetLogic();
            }
            else
            {
                this.Close();
                this.Refresh();
            }
        }

        public void gameManager_CurrentPlayerChange(object sender)
        {
            m_CurrentPlayerLabel.Text = "Current Player:  " + (sender as GameManager).CurrentPlayer.Name;
            m_CurrentPlayerLabel.BackColor = (sender as GameManager).CurrentPlayer.Color;
            m_CurrentPlayerLabel.Refresh();
        }

        private void cell_IsOpenChange(object sender)
        {
            string relevantButtonName = (sender as Cell).RowLocationInBoard + "," + (sender as Cell).ColLocationInBoard;
            Control relevantButton = this.Controls.Find(relevantButtonName, true)[0];
            if ((sender as Cell).IsOpen == true)
            {
                //relevantButton.Text = (sender as Cell).Character.ToString();
                //relevantButton.BackColor = Display.TheGame.CurrentPlayer.Color;
                (relevantButton as Button).Image = Display.ImagesForCards[(sender as Cell).Character].Image;                
                //border:
                (relevantButton as Button).FlatStyle = FlatStyle.Flat;
                (relevantButton as Button).FlatAppearance.BorderColor = Display.TheGame.CurrentPlayer.Color;
                (relevantButton as Button).FlatAppearance.BorderSize = 4;

            }
            else
            {
                //relevantButton.Text = String.Empty;
                //relevantButton.BackColor = Color.Gray;
                (relevantButton as Button).Image = null;
                //border:
                (relevantButton as Button).FlatStyle = FlatStyle.System;
            }
            relevantButton.Refresh();
            System.Threading.Thread.Sleep(800);
        }
    }
}

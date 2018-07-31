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
    public partial class FormStart : Form
    {
        readonly Queue<string> m_BoardSizesOptionsStrs = new Queue<string>();
        const string k_TitleAgainstFriend = "Against A Friend";
        const string k_TitleAgainstComputer = "Against Computer";
        private Color m_FirstPlayerColor = Color.LightBlue;
        private Color m_SeconedPlayerColor = Color.LightGreen;

        public Color FirstPlayerColor
        {
            get
            {
                return m_FirstPlayerColor;
            }

            set
            {
                m_FirstPlayerColor = value;
            }
        }

        public Color SeconedPlayerColor
        {
            get
            {
                return m_SeconedPlayerColor;
            }

            set
            {
                m_SeconedPlayerColor = value;
            }
        }

        public FormStart()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void buttonAgainstWho_Click(object sender, EventArgs e)
        {   
            if ((sender as Button).Text == k_TitleAgainstComputer)
            {
                (sender as Button).Text = k_TitleAgainstFriend;
                textBoxSecondPlayerName.Text = "Computer";
                textBoxSecondPlayerName.ReadOnly = true;
               
            }
            else if ((sender as Button).Text == k_TitleAgainstFriend)
            {
                (sender as Button).Text = k_TitleAgainstComputer;
                textBoxSecondPlayerName.Text = " ";
                textBoxSecondPlayerName.ReadOnly = false;
            }
        }

        private void FormStart_Load(object sender, EventArgs e)
        {

        }

        //Our Methods:

        private void initilizeBoardSizesOptionsStrs()
        {
            for (int i = Board.k_MinRows; i <= Board.k_MaxRows; i++)
            {
                for (int j = Board.k_MinCols; j <= Board.k_MaxCols; j++)
                {
                    string sizeOptionStr = i.ToString() + "X" + j.ToString();
                    if ((i % 2 == 0)||(j % 2 == 0))
                    {
                        m_BoardSizesOptionsStrs.Enqueue(sizeOptionStr);
                    }
                }
            }

            string sizeOptionstr = m_BoardSizesOptionsStrs.Dequeue();
            m_BoardSizesOptionsStrs.Enqueue(sizeOptionstr);

        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            if (m_BoardSizesOptionsStrs.Count == 0)
            {
                initilizeBoardSizesOptionsStrs();
            }

            string sizeOptionstr = m_BoardSizesOptionsStrs.Dequeue();
            (sender as Button).Text = sizeOptionstr;
            m_BoardSizesOptionsStrs.Enqueue(sizeOptionstr);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                initializePlayers();
                initializeBoard();
                this.DialogResult = DialogResult.OK;
                //it is supposed to set the dialog result as OK automatically
                //and close the dialog, since buttonStart is set as Accept-Button...
                //but it doesn't
                
            }
            catch (FormatException i_formatException)
            {
                //do nothing
            }
        }

        private void initializePlayers()
        {
            const bool v_IsHuman = true;

            if (string.IsNullOrWhiteSpace(textBoxFirstPlayerName.Text))
            {
                textBoxFirstPlayerName.Text = "Must be filled!";
                throw new FormatException();
            }
            else
            {
                //first player:
                Display.TheGame.AddNewPlayerToGame(new Player(textBoxFirstPlayerName.Text, v_IsHuman, m_FirstPlayerColor));
                //second player:
                if (buttonAgainstWho.Text == k_TitleAgainstComputer)
                {
                    Display.TheGame.AddNewPlayerToGame(new Player(textBoxSecondPlayerName.Text, v_IsHuman, m_SeconedPlayerColor));
                }
                else //buttonAgainstWho.Text == k_TitleAgainstFriend
                {
                    Display.TheGame.AddNewPlayerToGame(new Player(textBoxSecondPlayerName.Text, !v_IsHuman, m_SeconedPlayerColor));
                }
            }            
        }

        private void initializeBoard()
        {
            int rows, cols;
            string boardSizeStr = buttonBoardSize.Text;
            string[] rowsAndCols = boardSizeStr.Split('X');
            if (!int.TryParse(rowsAndCols[0], out rows))
            {
                throw new FormatException("something is not ok with the rows num of board");
            }

            if (!int.TryParse(rowsAndCols[1], out cols))
            {
                throw new FormatException("something is not ok with the cols num of board");
            }

            //<DEBUG USE ONLY>
            //Display.TheGame.MainBoard = new Board(2, 2);
            //</DEBUG USE ONLY>
            Display.TheGame.MainBoard = new Board(rows, cols);
        }

        private void buttonFirstPlayerColor_Click(object sender, EventArgs e)
        {
            DialogResult resualt = colorDialog1.ShowDialog();

            if (resualt == DialogResult.OK)
            {
                FirstPlayerColor = colorDialog1.Color;
            }
        }

        private void buttonSeconedPlayerColor_Click(object sender, EventArgs e)
        {
            DialogResult resualt = colorDialog1.ShowDialog();

            if (resualt == DialogResult.OK)
            {
                SeconedPlayerColor = colorDialog1.Color;
            }
        }
    }
}

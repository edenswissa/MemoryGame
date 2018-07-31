using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_C16
{
    public delegate void EventHandler(object sender);

    public class GameManager
    {
        private readonly Queue<Player> m_Players = new Queue<Player>();
        private const int m_NumOfPlayers = 2;
        private Board m_MainBoard;
        private List<Cell> m_ListOfPrevOpenedCellsWithNoMatch = new List<Cell>();
        private Player m_CurrentPlayer;
        public event EventHandler CurrentPlayerChange;
        public event EventHandler GameOver;

        public Queue<Player> Players
        {
            get { return m_Players; }
        }

        public Board MainBoard
        {
            get { return m_MainBoard; }
            set { m_MainBoard = value; }
        }

        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
            set
            {
                m_CurrentPlayer = value;
                OnCurrentPlayerChange();
            }
        }

        public void AddNewPlayerToGame(Player i_PlayerToAdd)
        {
            if (m_Players.Count == 0)
            {
                m_CurrentPlayer = i_PlayerToAdd;
            }
            m_Players.Enqueue(i_PlayerToAdd);
        }

        private void OnCurrentPlayerChange()
        {
            if (CurrentPlayerChange != null)
            {
                CurrentPlayerChange.Invoke(this);
            }
        }

        private void OnGameOver()
        {
            if (GameOver != null)
            {
                GameOver.Invoke(this);
            }
        }

        private void autoChooseCellToOpen(out int o_RowIndex, out int o_ColIndex)
        {
            do
            {
                //by default choose randomly.
                Random tempRandomIndex = new Random();
                o_RowIndex = tempRandomIndex.Next(0, m_MainBoard.Rows);
                o_ColIndex = tempRandomIndex.Next(0, m_MainBoard.Cols);

                if (m_CurrentPlayer.FirstCellOpened != null)
                {
                    if (m_ListOfPrevOpenedCellsWithNoMatch.Any(c => !ReferenceEquals(c, m_CurrentPlayer.FirstCellOpened) &&
                                                                   c.Equals(m_CurrentPlayer.FirstCellOpened)))
                    {
                        //if this is the second time to choose cell,
                        //if the first opened cell's matching char was opened in previous turns
                        //pick an index randomly out of the previously opened cells to increase success chances

                        int indexOfcellInList = tempRandomIndex.Next(0, m_ListOfPrevOpenedCellsWithNoMatch.Count());
                        o_RowIndex = m_ListOfPrevOpenedCellsWithNoMatch[indexOfcellInList].RowLocationInBoard;
                        o_ColIndex = m_ListOfPrevOpenedCellsWithNoMatch[indexOfcellInList].ColLocationInBoard;

                    }
                }
            }
            while (m_MainBoard.GameBoard[o_RowIndex, o_ColIndex].IsOpen);
            //if it picked the same cell as the first cell, or any other open cell- keep trying
        }

        public void GetCellToOpen(int i_Row, int i_Col)
        {
            if (m_MainBoard.GameBoard[i_Row, i_Col].IsOpen)
            {
                throw new Exception("The card is already open");
            }
            if (m_CurrentPlayer.FirstCellOpened == null)
            {
                m_CurrentPlayer.FirstCellOpened = m_MainBoard.GameBoard[i_Row, i_Col];
                m_MainBoard.GameBoard[i_Row, i_Col].IsOpen = true;
            }
            else if (m_CurrentPlayer.SecondCellOpened == null)
            {
                m_CurrentPlayer.SecondCellOpened = m_MainBoard.GameBoard[i_Row, i_Col];
                m_MainBoard.GameBoard[i_Row, i_Col].IsOpen = true;
            }
        }

        public string GetWinnerOrTieMessage()
        {
            bool isTie = false;

            Player winner = m_CurrentPlayer;
            foreach (Player player in m_Players)
            {
                if (player.NumOfPairsSucceeded > winner.NumOfPairsSucceeded)
                {
                    winner = player;
                }
            }

            foreach (Player player in m_Players)
            {
                if ((winner != player) && (winner.NumOfPairsSucceeded == player.NumOfPairsSucceeded))
                {
                    isTie = true;
                    break;      
                } 
            }

            return isTie ? "It's Tie" : String.Format("The Winner is : {0}", winner.Name);
        }

        public void AfterTwoCardsAreOpen()
        {
            bool isGameOver = false;

            if ((m_CurrentPlayer.FirstCellOpened != null) && (m_CurrentPlayer.SecondCellOpened != null))
            {
                addTwoCellsToPrevOpenedCellsWithNoMatch();
                updateAccordingToMatchOrNotMatch();
                isGameOver = updateIfGameIsOver();
                while (!m_CurrentPlayer.IsHuman && !isGameOver)
                {
                    playAutoPlayerTurn();
                    updateAccordingToMatchOrNotMatch();
                    isGameOver = updateIfGameIsOver();
                }
            }
        }

        private void playAutoPlayerTurn()
        {

            int row, col;
            autoChooseCellToOpen(out row, out col);
            GetCellToOpen(row, col);
            autoChooseCellToOpen(out row, out col);
            GetCellToOpen(row, col);
        }

        private void updateAccordingToMatchOrNotMatch()
        {
            if (m_CurrentPlayer.FirstCellOpened.Equals(m_CurrentPlayer.SecondCellOpened))
            {
                matchingCellsSucceeded();
            }
            else
            {
                matchingCellsFaild();
            }

            m_CurrentPlayer.FirstCellOpened = null;
            m_CurrentPlayer.SecondCellOpened = null;
        }

        private void matchingCellsSucceeded()
        {
            m_CurrentPlayer.NumOfPairsSucceeded++;
            m_MainBoard.NumOfOpenCells += 2;
            m_ListOfPrevOpenedCellsWithNoMatch.Remove(m_CurrentPlayer.FirstCellOpened);
            m_ListOfPrevOpenedCellsWithNoMatch.Remove(m_CurrentPlayer.SecondCellOpened);
        }

        private void matchingCellsFaild()
        {
            m_CurrentPlayer.FirstCellOpened.IsOpen = false;
            m_CurrentPlayer.SecondCellOpened.IsOpen = false;
            switchCurrentPlayerToNextPlayer();
        }

        private void addTwoCellsToPrevOpenedCellsWithNoMatch()
        {
            if (!m_ListOfPrevOpenedCellsWithNoMatch.Any(c => ReferenceEquals(c, m_CurrentPlayer.FirstCellOpened)))
            {//if cell is not already in the list add it
                m_ListOfPrevOpenedCellsWithNoMatch.Add(m_CurrentPlayer.FirstCellOpened);
            }

            if (!m_ListOfPrevOpenedCellsWithNoMatch.Any(c => ReferenceEquals(c, m_CurrentPlayer.SecondCellOpened)))
            {//if cell is not already in the list add it
                m_ListOfPrevOpenedCellsWithNoMatch.Add(m_CurrentPlayer.SecondCellOpened);
            }
        }

        private void switchCurrentPlayerToNextPlayer()
        {
            Player theCurrentPlayerThatIsPushedToBeLastPlayer = m_Players.Dequeue();
            m_Players.Enqueue(theCurrentPlayerThatIsPushedToBeLastPlayer);
            CurrentPlayer = m_Players.First();
        }


        private bool updateIfGameIsOver()
        {
            bool res = false;

            if (m_MainBoard.CheckIfAllCellsAreOpen())
            {
                OnGameOver();
                res = true;
            }

            return res;
        }
        
        public void ResetLogic()
        {
            foreach(Player player in m_Players)
            {
                player.NumOfPairsSucceeded = 0;
                player.FirstCellOpened = null;
                player.SecondCellOpened = null;
            }

            m_MainBoard.NumOfOpenCells = 0;
            m_MainBoard.InitializeCells();
            m_ListOfPrevOpenedCellsWithNoMatch.Clear();
            if (!m_CurrentPlayer.IsHuman)
            {
                switchCurrentPlayerToNextPlayer();
            }
        }
    }
}
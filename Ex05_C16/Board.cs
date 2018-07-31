using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_C16
{
    public class Board
    {
        private readonly int m_Rows = 0;
        private readonly int m_Cols = 0;
        private int m_TotalSize = 0;
        private readonly Cell[,] m_GameBoard;
        private int m_NumOfOpenCells = 0;
        public const int k_MaxRows = 6;
        public const int k_MaxCols = 6;
        public const int k_MinRows = 4;
        public const int k_MinCols = 4;
        public static readonly Char[] k_CharOptionsForCell = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                                                              'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        
        public int Rows
        {
            get { return m_Rows; }
        }

        public int Cols
        {
            get { return m_Cols; }
        }

        public Cell[,] GameBoard
        {
            get { return m_GameBoard; }
        }

        public int TotalSize
        {
            get { return m_TotalSize; }
        }
       
        public int NumOfOpenCells
        {
            get { return m_NumOfOpenCells; }
            set { m_NumOfOpenCells = value; }
        }

        internal bool CheckIfAllCellsAreOpen()
        {
            return (m_TotalSize == m_NumOfOpenCells);
        }

        private void createCells()
        {
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Cols; j++)
                {
                    m_GameBoard[i, j] = new Cell();
                }
            }
        }

        public Board(int i_Rows, int i_Cols)
        {
            m_Rows = i_Rows;
            m_Cols = i_Cols;
            m_TotalSize = m_Cols * m_Rows;
            m_GameBoard = new Cell[i_Rows, i_Cols];
            createCells();
            InitializeCells();
        }

        public void InitializeCells()
        {
            List<Char> tmpListOfTheCharsToPutInCells;
            Random rndIndexOfCharToPut = new Random();
            int rndIndex;

            tmpListOfTheCharsToPutInCells = createListOftheCharsToPutInCells();
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Cols; j++)
                {
                    m_GameBoard[i, j].IsOpen = false;
                    rndIndex = rndIndexOfCharToPut.Next(0, tmpListOfTheCharsToPutInCells.Count);
                    m_GameBoard[i, j].Character = tmpListOfTheCharsToPutInCells[rndIndex];
                    tmpListOfTheCharsToPutInCells.RemoveAt(rndIndex);
                    m_GameBoard[i, j].RowLocationInBoard = i;
                    m_GameBoard[i, j].ColLocationInBoard = j;
                }
            }
        }

        private List<Char> createListOftheCharsToPutInCells()
        {
            Char charForCell;
            List<Char> charList = new List<Char>();

            for (int i = 0; i < (m_TotalSize / 2); i++)
            {
                charForCell = Board.k_CharOptionsForCell[i];
                charList.Add(charForCell);
                charList.Add(charForCell);
            }

            return charList;
        }
    }
}

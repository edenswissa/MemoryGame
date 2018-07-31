using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_C16
{
    public class Cell
    {
        private char m_Character;
        private bool m_IsOpen = false;
        private const char m_Space = ' ';
        private int m_RowLocationInBoard;
        private int m_ColLocationInBoard;
        public event EventHandler IsOpenChange;

        public char Character
        {
            get { return m_Character; }
            set { m_Character = value; }
        }

        public bool IsOpen
        {
            get { return m_IsOpen; }
            set 
            { 
                m_IsOpen = value;
                OnIsOpenChange();
            }
        }

        public int RowLocationInBoard
        {
            get { return m_RowLocationInBoard; }
            set { m_RowLocationInBoard = value; }
        }

        public int ColLocationInBoard
        {
            get { return m_ColLocationInBoard; }
            set { m_ColLocationInBoard = value; }
        }

        public char GetCharToPrint()
        {
            if (m_IsOpen)
            {
                return m_Character;
            }
            else
            {
                return m_Space;
            }
        }

        public bool Equals(Cell i_Cell)
        {
            return (this.m_Character.Equals(i_Cell.Character)) ;
        }

        private void OnIsOpenChange()
        {
            if (IsOpenChange != null)
            {
                IsOpenChange.Invoke(this);
            }
        }
    }
}

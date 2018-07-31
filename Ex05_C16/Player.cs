using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_C16
{
    public class Player
    {
        private string m_Name;
        private bool m_IsHuman;
        private int m_NumOfPairsSucceeded = 0;		 
        private Color m_Color;
        private Cell m_FirstCellThatOpened = null;
        private Cell m_SecondCellThatOpened = null;
        public event EventHandler NumOfPairsSucceededChange;

        public Player (string i_Name, bool i_IsHuman, Color i_Color)
        {
            m_Name = i_Name;
            m_IsHuman = i_IsHuman;
            m_Color = i_Color;
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value;  }
        }

        public bool IsHuman
        {
            get { return m_IsHuman; }
            set { m_IsHuman = value; }
        }

        public int NumOfPairsSucceeded
        {
            get { return m_NumOfPairsSucceeded; }
            set {
                    m_NumOfPairsSucceeded = value;
                    OnNumOfPairsSucceededChange();
                }
        }

        public Cell FirstCellOpened
        {
            get { return m_FirstCellThatOpened; }
            set { m_FirstCellThatOpened = value; }
        }

        public Cell SecondCellOpened
        {
            get { return m_SecondCellThatOpened; }
            set { m_SecondCellThatOpened = value; }
        }

        public Color Color
        {
            get
            {
                return m_Color;
            }

            set
            {
                m_Color = value;
            }
        }

        private void OnNumOfPairsSucceededChange()
        {
            if(NumOfPairsSucceededChange != null)
            {
                NumOfPairsSucceededChange.Invoke(this);
            }
        }
    }
}

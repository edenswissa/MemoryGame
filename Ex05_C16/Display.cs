using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_C16
{
    public static class Display
    {
        private static GameManager m_TheGame = new GameManager();
        private static Dictionary<Char, System.Windows.Forms.PictureBox> m_ImagesForCards = new Dictionary<Char, System.Windows.Forms.PictureBox>();

        public static GameManager TheGame
        {
            get { return m_TheGame; }
        }

        public static Dictionary<Char, System.Windows.Forms.PictureBox> ImagesForCards
        {
            get { return m_ImagesForCards; }
        }

        internal static void RunMemoryGame()
        {
            FormStart formStart = new FormStart();
            if (formStart.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InitializeImages();
                FormBoard formBoard = new FormBoard();
                formBoard.ShowDialog();
            }
        }

        internal static void SetLocationOfCard(int i_RowIndexInBoard, int i_ColIndexInBoard, System.Windows.Forms.Button io_CardToSet)
        {
            System.Drawing.Point location = new System.Drawing.Point();
            location.X = (i_ColIndexInBoard * (io_CardToSet.Width + FormBoard.SpaceBetweenCards)) + FormBoard.SpaceBetweenCards;
            location.Y = (i_RowIndexInBoard * (io_CardToSet.Height + FormBoard.SpaceBetweenCards)) + FormBoard.SpaceBetweenCards;
            io_CardToSet.Location = location;
        }

        public static void InitializeImages()
        {
            foreach (Char charOption in Board.k_CharOptionsForCell)
            {
                System.Windows.Forms.PictureBox picBox = new System.Windows.Forms.PictureBox();

                picBox.Load(string.Format("http://lorempixel.com/80/80/"));
                m_ImagesForCards.Add(charOption, picBox);
            }
        }
    }
}

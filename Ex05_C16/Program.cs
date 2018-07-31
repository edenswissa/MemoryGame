using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// $G$ CSS-999 (-40) StyleCop errors.
// $G$ SFN-009 (+12) Bonus: Events in the Logic layer are handled by the UI.
// $G$ DSN-999 (-10) You were not allowed to use the designer.
// $G$ SFN-010 (+10) Bonus: Picture bonus! a bit slow..
namespace Ex05_C16
{
    class Program
    {
        public static void Main()
        {
            GameManager game = new GameManager();
            Display.RunMemoryGame();
        }
    }
}

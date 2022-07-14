using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversi_game
{
    public class Bot : Player
    {
        public override Point MakeMove()
        {
            Random rand = new Random();
            Point point = new Point();
            point.X = rand.Next() % 10;
            point.Y = rand.Next() % 10;
            return point;
        }


        public override Field GetSign()
        {
            return Field.BLACK;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversi_game
{
    public class Human:Player
    {
        public override Point MakeMove()
        {
            Point point = new Point();
            Console.Write("Row= ");
            point.X = int.Parse(Console.ReadLine());
            Console.Write("Column= ");
            point.Y = int.Parse(Console.ReadLine());
            return point;
        }
        public override Field GetSign()
        {
            return Field.RED;
        }
    }
}

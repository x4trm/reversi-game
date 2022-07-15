using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversi_game
{
    public class Manager
    {
        public Player player1;
        public Player player2;
        public Board board;
        public Player active;
        public Field winner;
        public bool game = true;
        public Point point;
        public Manager(int size)
        {
            board = new Board(size);
            player1 = new Human();
            player2 = new Bot();
            active = player1;
            while (game)
            {
                board.ShowBoard();
                point = active.MakeMove();
                /*                do
                                {
                                    point = active.MakeMove();

                                }while(point.X>=board.boardSize || point.Y>=board.boardSize || !board.Put(point,active.GetSign()));*/
                while (point.X < 0 || point.Y < 0 || point.X >= board.boardSize || point.Y >= board.boardSize || board.Put(point, active.GetSign()) == false)
                {
                    point = active.MakeMove();
                }
                winner = board.GameOver(out game, active.GetSign());
                if (!game)
                {
                    Console.WriteLine("Game Over!");
                    if (winner == Field.RED)
                    {
                        Console.WriteLine("You Win!");
                    }
                    else if (winner == Field.BLACK)
                    {
                        Console.WriteLine("Computer Win!");
                    }
                    else
                    {
                        Console.WriteLine("Draw!");
                    }
                }
                if (active == player1) active = player2;
                else active = player1;
            }
        }
    }
}

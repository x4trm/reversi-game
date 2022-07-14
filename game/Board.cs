using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversi_game
{
    public enum Field
    {
        BLACK='X',
        RED='O',
        FREE='.'
    }
    public class Board
    {
        public Field[,] board;
        public int boardSize;
        public Board(int size)
        {
            boardSize = size;
            board = new Field[boardSize, boardSize];
            cleanBoard();
        }
        private void cleanBoard()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    board[i, j] = Field.FREE;
                }
            }
            int center = boardSize / 2;
            board[center - 1, center - 1] = board[center, center] = Field.BLACK;
            board[center - 1, center] = board[center, center - 1] = Field.RED;
        }
        private bool CheckPoint(int x,int y)
        {
            return x>=0 && x<boardSize && y>=0 && y<boardSize;
        }
        public Field GetField(int x,int y)
        {
            if(!CheckPoint(x,y))
            {
                throw new Exception("Achtung!");
            }
            return board[x, y];
        }
        public void ShowBoard()
        {
            Console.Write(" ");
            for (int i = 0; i < boardSize; i++)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine();
            for (int i = 0; i < boardSize; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write((char)board[i, j] + " ");
                }

                Console.Write("\n");
            }
        }
        public bool Find(int x, int y, int dx, int dy, Field playerSign, bool verification)
        {
            bool change = false;
            int tempx, tempy;
            int i = x + dx;
            int j = y + dy;
            if (i <= 0 || i >= boardSize || j <= 0 || j >= boardSize || board[x, y] == playerSign)
            {
                return change;
            }
            while (i >= 0 && i < boardSize && j < boardSize && j >= 0 && board[x, y] != playerSign)
            {
                if (board[x, y] == 0)
                    break;
                i += dx;
                j += dy;
                if (i <= 0 || i > boardSize || j <= 0 || j >= boardSize)
                    break;

            }
            if (board[x, y] == playerSign)
            {
                tempx = x + dx;
                tempy = y + dy;
                while (tempx != i || tempy != j)
                {
                    change = true;
                    if (!verification)
                    {
                        board[x, y] = playerSign;
                    }
                    tempx += dx;
                    tempy += dy;
                }
            }
            return change;

        }
        public bool TurnOver(int x, int y, Field playerSign, bool verification)
        {
            bool insert = false;
            bool[] tab = new bool[8];
            tab[0] = Find(x, y, -1, 0, playerSign, verification);
            tab[1] = Find(x, y, 1, 0, playerSign, verification);
            tab[2] = Find(x, y, 1, 1, playerSign, verification);
            tab[3] = Find(x, y, -1, -1, playerSign, verification);
            tab[4] = Find(x, y, -1, 1, playerSign, verification);
            tab[5] = Find(x, y, 1, -1, playerSign, verification);
            tab[6] = Find(x, y, 0, 1, playerSign, verification);
            tab[7] = Find(x, y, 0, -1, playerSign, verification);
            foreach (bool t in tab)
            {
                if (t == true)
                {
                    insert = true;
                }
            }
            return insert;
        }
        public bool Put(Point point, Field playerSign)
        {
            int x = point.X;
            int y = point.Y;
            if (TurnOver(x, y, playerSign, false))
            {
                board[x, y] = playerSign;
                return true;
            }
            else
            {
                return false;
            }
        }
        public Field GameOver(out bool game,Field field)
        {
            bool temp = false;
            int x = 0, o = 0;
            for(int i =0;i<boardSize;i++)
            {
                for(int j=0;j<boardSize;j++)
                {
                    if (board[i, j] == Field.RED) o++;
                    else if (board[i, j] == Field.BLACK) x++;
                    if(TurnOver(i,j,field,true))
                    {
                        temp = true;
                    }
                }
            }
            game = temp;
            if (x > o) return Field.BLACK;
            else if (o > x) return Field.RED;
            else return Field.FREE;
        }
    }
}

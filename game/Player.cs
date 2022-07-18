using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversi_game
{
    public abstract class Player
    {
        public abstract Field GetSign();
        public abstract Point MakeMove();
    }
}

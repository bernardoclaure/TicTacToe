using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    interface IPlayer
    {
        int MakeMove( char[] board);
        char GetPlayerChar();
    }
}

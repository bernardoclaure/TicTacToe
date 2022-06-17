using System;
using System.Collections.Generic;
using System.Text;
using static TicTacToe.Board;
namespace TicTacToe
{
    class HumanPlayer : IPlayer
    {
        private char humanChar;
        public HumanPlayer(char player)
        {
            humanChar = player;
        }

        public char GetPlayerChar()
        {
            return humanChar;
        }

        public int MakeMove( char[] board)
        {
            int position;
            string input;
            do
            {
                input = Console.ReadLine();
                position = int.Parse(input);

            } while (!ValidMove(board, position));
            
            return position;
        }
        public bool ValidMove(char[] board,int position)
        {
            char[] emptySpots = AvailableSpots(board);
            foreach (var move in emptySpots)
            {
                if (int.Parse(move.ToString()) == position)
                    return true;
            }
            Console.WriteLine("Posicion en el tablero invalida, por favor ingrese nuevamente otra casilla");
            return false;
        }
    }
}

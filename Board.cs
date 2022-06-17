using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    static class Board
    {
        public static void MarkBoard(int position, char character,char[] board)
        {
            board[position] = character;
        }
        public static void PrintBoard(char[] board)
        {
            for(int i=0;i<9;i++)
            {
                if (((i + 1) % 3) != 0)
                    Console.Write("|" + board[i]+ "|");
                else
                {
                    Console.WriteLine("|" + board[i] + "|");
                    Console.WriteLine("---------");
                }
            }
        }
        public static bool WinCondition(char player, char[] board) 
        {
            if (
                 (board[0] == player && board[1] == player && board[2] == player) ||
                 (board[3] == player && board[4] == player && board[5] == player) ||
                 (board[6] == player && board[7] == player && board[8] == player) ||
                 (board[0] == player && board[3] == player && board[6] == player) ||
                 (board[1] == player && board[4] == player && board[7] == player) ||
                 (board[2] == player && board[5] == player && board[8] == player) ||
                 (board[0] == player && board[4] == player && board[8] == player) ||
                 (board[2] == player && board[4] == player && board[6] == player)
                 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool FullBoard(char[] board)
        {
            foreach (char space in board)
            {
                if (space != 'X' && space != 'O')
                    return false;
            }
            return true;
        }
        public static char[] AvailableSpots(char[] board)
        {
            List<char> spots=new List<char>();
            foreach (char space in board)
            {
                if (space != 'X' && space != 'O')
                    spots.Add(space);
            }
            return spots.ToArray();

        }
        public static char[] CloneBoard(char[] board)
        {
            char[] copiedBoard = new char[9];
            Array.Copy(board, copiedBoard, 9);
            return copiedBoard;
        }

    }
 
}

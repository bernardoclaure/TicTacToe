using System;
using System.Collections.Generic;
using System.Text;
using static TicTacToe.Board;
namespace TicTacToe
{
    class Game
    {
        public void playGame()
        {
            PcPlayer pcPlayer = new PcPlayer();
            char[] board = new char[9] { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
            int position;
            char player = selectWhoBegins();
            do
            {
                Console.Clear();
                printBoard(board); 
                position = makeMove(player, board, pcPlayer);
                markBoard(position,player, board);
                player = changePlayer(player);
            }
            while (!winCondition(changePlayer(player), board) && !fullBoard(board));
            Console.Clear();
            printBoard(board);
            if (winCondition(changePlayer(player), board))
                Console.WriteLine("El ganador es : " + changePlayer(player));
            else
                Console.WriteLine("Empate");
        }
        public int makeMove(char player, char[]board, PcPlayer pcPlayer)
        {
            int position;
            string input;
            if (player == 'O')
            {
                input = Console.ReadLine();
                position = int.Parse(input);
            }
            else
            {
                position = pcPlayer.makeMove(player, board);
            }
            return position;
        }
        public static char changePlayer(char player)
        {
            if (player == 'O')
                return 'X';
            else
                return 'O';
        }
        public char selectWhoBegins()
        {
            string input;
            Console.WriteLine("Elija quien empieza, 1 para comenzar, 2 para jugar de segundo, en caso de presionar otra tecla empezara segundo");
            input = Console.ReadLine();
            if (int.Parse(input)==1)
            {
                return 'O';
            }
            else
            {
                return 'X';
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        public void playGame()
        {
            pcPlayer pcPlayer = new pcPlayer();
            Board board = new Board();
            char[] boardU = new char[9] { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
            string input;
            int position;
            char player=' ';
            do
            {

                Console.Clear();
                board.printBoard(boardU);
                player = changePlayer(player);
                if(player=='O')
                {
                    input = Console.ReadLine();
                    position = int.Parse(input);
                }
                else
                {
                    position = pcPlayer.miniMax(player, boardU);
                }
                board.markBoard(position,player, boardU);


            }
            while (!board.winCondition(player, boardU) && !board.fullBoard(boardU));
            board.printBoard(boardU);
            if (board.winCondition(player, boardU))
                Console.WriteLine("El ganador es : " + player);
            else
                Console.WriteLine("Empate");
        }
        public char changePlayer(char player)
        {
            if (player == 'O')
                return 'X';
            else
                return 'O';
        }
    }
}

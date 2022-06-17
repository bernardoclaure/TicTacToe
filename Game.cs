using System;
using System.Collections.Generic;
using System.Text;
using static TicTacToe.Board;
namespace TicTacToe
{
    class Game
    {
        PcPlayer pcPlayer = new PcPlayer('X');
        HumanPlayer humanPlayer = new HumanPlayer('O');
        public void PlayGame()
        {
            char[] board = new char[9] { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
            int position;
            var player = SelectWhoBegins();
            do
            {
                Console.Clear();
                PrintBoard(board);
                position = player.MakeMove(board);
                MarkBoard(position,player.GetPlayerChar(), board);
                player = ChangePlayer(player);
            }
            while (!WinCondition(ChangePlayer(player).GetPlayerChar(), board) && !FullBoard(board));
            Console.Clear();
            PrintBoard(board);
            if (WinCondition(ChangePlayer(player).GetPlayerChar(), board))
                Console.WriteLine("El ganador es : " + ChangePlayer(player).GetPlayerChar());
            else
                Console.WriteLine("Empate");
        }
    
        public static char ChangeSymbol(char player)
        {
            if (player == 'O')
                return 'X';
            else
                return 'O';
        }
        public IPlayer ChangePlayer(IPlayer player)
        {
            if (player is HumanPlayer)
                return pcPlayer;
            else
                return humanPlayer;
        }
        public IPlayer SelectWhoBegins()
        {
            string input;
            Console.WriteLine("Elija quien empieza, 1 para comenzar, 2 para jugar de segundo, en caso de presionar otra tecla empezara segundo");
            input = Console.ReadLine();
            if (int.Parse(input)==1)
            {
                return humanPlayer;
            }
            else
            {
                return pcPlayer;
            }
        }
    }
}

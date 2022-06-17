using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static TicTacToe.Board;
namespace TicTacToe
{
    class PcPlayer:IPlayer
    {
        private char pcCharacter;
        public PcPlayer(char player)
        {
            pcCharacter = player;
        }

        public char GetPlayerChar()
        {
            return pcCharacter;
        }

        public int MakeMove(char[] board) 
        {
            var emptySpots = AvailableSpots(board);
            var scores = new Dictionary<int, int>();
            var topScore = int.MinValue;
            foreach (var move in emptySpots)
            {
                var moveInt = int.Parse(move.ToString());
                var score = MiniMax(pcCharacter, moveInt, CloneBoard(board));
                scores[moveInt] = score;
                if (score > topScore)
                {
                    topScore = score;
                }
            }
            var topMoves = scores.Where(x => x.Value == topScore)
                .Select(x => x.Key)
                .ToArray();
                return topMoves[0];
        }
        private int MiniMax(char player, int move, char[] board)
        {
            MarkBoard(move, player, board);
            var result =WinCondition(player, board);
            var ended = FullBoard(board);
            if (result && player == pcCharacter)
                return 100;
            else if (result && player != pcCharacter)
                return -100;
            else if (ended)
                return 0;
            player = Game.ChangeSymbol(player);
            var emptySpots = AvailableSpots(board);
            var scores = new int[emptySpots.Length];
            for (var i = 0; i < emptySpots.Length; i++)
            {
                var availableMove = int.Parse(emptySpots[i].ToString());
                var score = MiniMax(player, availableMove, CloneBoard(board));
                scores[i] = score;
            }
            var pcTurn = player == pcCharacter;
            return pcTurn ? scores.Max() : scores.Min();
        }
  
    }
}

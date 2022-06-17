using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class pcPlayer
    {
        Board board = new Board();
        char realP = 'X';
        Game game = new Game();
        public int miniMax(char player,char[] boardU) 
        {
            var emptySpots = board.availableSpots(board.CloneBoard(boardU));
            var scores = new Dictionary<int, int>();
            var topScore = int.MinValue;
            foreach (var move in emptySpots)
            {
                var moveInt = int.Parse(move.ToString());
                var score = GetMinMaxScoreForMovesRecursive(player, moveInt, board.CloneBoard(boardU));
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
        private int GetMinMaxScoreForMovesRecursive(char player, int move, char[] boardU)
        {
           
            board.markBoard(move, player, boardU);
            var result = board.winCondition(player, boardU);
            var ended = board.fullBoard(boardU);
            if (result && player == realP)
                return 100;
            else if (result && player != realP)
                return -100;
            else if (ended)
                return 0;
            player = game.changePlayer(player);

            var nextAvailableMoves = board.availableSpots(boardU);
            var scores = new int[nextAvailableMoves.Length];
            for (var i = 0; i < nextAvailableMoves.Length; i++)
            {
                var availableMove = int.Parse(nextAvailableMoves[i].ToString());
                var score = GetMinMaxScoreForMovesRecursive(player, availableMove, board.CloneBoard(boardU));
                scores[i] = score;
            }
            var isMyTurn = player == realP;
            return isMyTurn ? scores.Max() : scores.Min();
        }
    }
}

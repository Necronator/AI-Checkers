using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AICheckers
{
    class AI_Tree : IAI
    {
        //weightings of different possible moves to be applied to each possible future game baord
        int Ai_MaxDepthLevel = DecideDifficulty();

        int Weight_CapturePiece = 5;
        int Weight_CaptureKing = 2;
        int Weight_CaptureDouble = 7;
        int Weight_CaptureMulti = 10;

        int Weight_AtRisk = 3;
        int Weight_KingAtRisk = 1;

        //int Ai_MaxDepthLevel = 2;

        //int Weight_CapturePiece = 3;
        //int Weight_CaptureKing = 2;
        //int Weight_CaptureDouble = 5;
        //int Weight_CaptureMulti = 10;

        //int Weight_AtRisk = 3;
        //int Weight_KingAtRisk = 1;

        //int Ai_MaxDepthLevel = 3;

        //int Weight_CapturePiece = 3;
        //int Weight_CaptureKing = 2;
        //int Weight_CaptureDouble = 5;
        //int Weight_CaptureMulti = 10;

        //int Weight_AtRisk = 3;
        //int Weight_KingAtRisk = 1;



        CheckerColour colour;

        Tree<Move> gameTree;

        public static int DecideDifficulty()
        {
            Console.WriteLine("Please decide the difficulty of the AI: Type 1 for easy, 2 for medium and 3 for hard");
            string userInput = Console.ReadLine();
            while (userInput != "1" && userInput != "2" && userInput != "3")
            {
                Console.WriteLine("Please decide the difficulty of the AI: Type 1 for easy, 2 for medium and 3 for hard");
                userInput = Console.ReadLine();
            }
            
            if(userInput == "1")
            {
                return (3);
            }
            if (userInput == "2")
            {
                return (5);
            }
            if (userInput == "3")
            {
                return (10);
            }
            else
            {
                return (0);
            }

        }
        public CheckerColour Colour
        {
            get { return colour; }
            set { colour = value; }
        }

        public Move Process(Square[,] Board)
        {
            Console.WriteLine();
            Console.WriteLine("AI: Building Game Tree...");

            gameTree = new Tree<Move>(new Move());

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board[i, j].Colour == Colour)
                    {
                        foreach (Move myPossibleMove in FindSquares.GetOpenSquares(Board, new Point(j, i)))
                        {
                            CalculateChildMoves(0, gameTree.AddChild(myPossibleMove), myPossibleMove, DeepCopy(Board));

                        }
                    }
                    IsGameOver(Board);
                }
            }

            Console.WriteLine();
            Console.WriteLine("AI: Scoring Game Tree...");

            
            ScoreTreeMoves(Board); //gives a value to all current possibe moves
            IsGameOver(Board); // checks if the game has ended
            return SumTreeMoves(); //returns the best move
            //return ReturnRandomMove(); //returns a random move 
            
        }

        private Square[,] DeepCopy(Square[,] sourceBoard)
        {
            Square[,] result = new Square[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    result[i, j] = new Square();
                    result[i, j].Colour = sourceBoard[i, j].Colour;
                    result[i, j].King = sourceBoard[i, j].King;
                }
            }

            return result;
        }

        private void CalculateChildMoves(int recursionLevel, Tree<Move> branch, Move move, Square[,] vBoard)
        {
            if (recursionLevel >= Ai_MaxDepthLevel)
            {
                return;
            }

            CheckerColour moveColour = vBoard[move.Source.Y, move.Source.X].Colour;

            //Move the checker
            vBoard = ExecuteVirtualMove(move, vBoard);

            //Calculate the other player's moves
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (vBoard[i, j].Colour != moveColour)
                    {
                        foreach (Move otherPlayerMove in FindSquares.GetOpenSquares(vBoard, new Point(j, i)))
                        {
                            if (vBoard[i, j].Colour != CheckerColour.Empty)
                            {
                                CalculateChildMoves(
                                    ++recursionLevel,
                                    branch.AddChild(otherPlayerMove),
                                    otherPlayerMove,
                                    DeepCopy(vBoard));
                            }
                        }
                    }
                }
            }
        }

        private Square[,] ExecuteVirtualMove(Move move, Square[,] Board)
        {
            Board[move.Destination.Y, move.Destination.X].Colour = Board[move.Source.Y, move.Source.X].Colour;
            Board[move.Destination.Y, move.Destination.X].King = Board[move.Source.Y, move.Source.X].King;
            Board[move.Source.Y, move.Source.X].Colour = CheckerColour.Empty;
            Board[move.Source.Y, move.Source.X].King = false;

            //Kinging
            if ((move.Destination.Y == 7 && Board[move.Destination.Y, move.Destination.X].Colour == CheckerColour.Red)
                || (move.Destination.Y == 0 && Board[move.Destination.Y, move.Destination.X].Colour == CheckerColour.Black))
            {
                Board[move.Destination.Y, move.Destination.X].King = true;
            }

            return Board;
        }

        private void ScoreTreeMoves(Square[,] Board)
        {
            Action<Move> scoreMove = (Move move) => move.Score = ScoreMove(move, Board);

            foreach (Tree<Move> possibleMove in gameTree.Children)
            {
                possibleMove.Traverse(scoreMove);
            }

        }

        private Move SumTreeMoves()
        {
            //Iterate currently possible moves

            int branchSum = 0;
            Action<Move> sumScores = (Move move) => branchSum += move.Score;

            // if a capture move is mandatory, add it to the list
            /*if (move.IsMandatoryCapture())
            {
                mandatoryCaptureMoves.Add(move);
                continue;
            }
            */

            foreach (Tree<Move> possibleMove in gameTree.Children)
            {
                possibleMove.Traverse(sumScores);
                possibleMove.Value.Score += branchSum;
                branchSum = 0;
            }

            //Return highest score
            return gameTree.Children.OrderByDescending(o => o.Value.Score).ToList()[0].Value;
        }

        private Move ReturnRandomMove()
        {
            int branchSum = 0;
            Action<Move> sumScores = (Move move) => branchSum += move.Score;
            Random rand = new Random();


            foreach (Tree<Move> possibleMove in gameTree.Children)
            {
                possibleMove.Traverse(sumScores);
                possibleMove.Value.Score += branchSum;
                branchSum = 0;
            }

            //Return random scores
            return gameTree.Children.OrderBy(_ => rand.Next()).ToList()[0].Value;
        }

        private void IsGameOver(Square[,] Board) //checks if any black or red pieces are present and declares the winner 
        {
            bool isRedAlive = false;
            bool isBlackAlive = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(Board[i,j].Colour == CheckerColour.Black)
                    {
                        isBlackAlive = true;
                    }
                    if (Board[i,j].Colour == CheckerColour.Red)
                    {
                        isRedAlive = true;
                    }
                }
            }
            if(isRedAlive == false)
            {
                Console.WriteLine("Black wins");
            }
            if (isBlackAlive == false)
            {
                Console.WriteLine("Red wins");
            }
        }

        private int ScoreMove(Move move, Square[,] board)
        {
            int score = 0;

            //Offensive traits
            score += move.Captures.Count * Weight_CapturePiece;

            if (move.Captures.Count > 0)
            {
                score+= 
            }
            if (move.Captures.Count == 1)
            { 
                score += Weight_CapturePiece; 
            }
            if (move.Captures.Count == 2)
            { 
                score += Weight_CaptureDouble; 
            }
            if (move.Captures.Count > 2)
            { 
                score += Weight_CaptureMulti; 
            }

            //Check King Captures
            foreach (Point point in move.Captures)
            {
                if (board[point.Y, point.X].King) score += Weight_CaptureKing;
            }

            //Check if piece is at risk
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j].Colour == Colour)
                    {
                        foreach (Move opponentMove in FindSquares.GetOpenSquares(board, new Point(j, i)))
                        {
                            if (opponentMove.Captures.Contains(move.Source))
                            {
                                if (board[move.Source.Y, move.Source.X].King)
                                {
                                    score -= Weight_KingAtRisk;
                                }
                                else
                                {
                                    score -= Weight_AtRisk;
                                }
                            }
                        }
                    }
                }
            }

            //Subtract score if we are evaluating an opponent's piece
            if (board[move.Source.Y, move.Source.X].Colour != colour) score *= -1;

            Console.WriteLine(
                "{0,-5} {1} Score: {2,2}",
                board[move.Source.Y, move.Source.X].Colour.ToString(),
                move.ToString(),
                score
                ); 

            return score;
        }

    }
}

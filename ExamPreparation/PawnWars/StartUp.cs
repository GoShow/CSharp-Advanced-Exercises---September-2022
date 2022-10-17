using System;

namespace PawnWars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Ugly solution :)
            int side = 8;
            char[,] chessBoard = new char[side, side];

            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 0;
            int blackCol = 0;

            for (int row = 0; row < side; row++)
            {
                string rowElements = Console.ReadLine();

                for (int col = 0; col < side; col++)
                {
                    chessBoard[row, col] = rowElements[col];

                    if (rowElements[col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }

                    if (rowElements[col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            bool whiteTurn = true;

            while (true)
            {
                if (whiteTurn)
                {
                    if (whiteRow == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(97 + whiteCol)}8.");

                        return;
                    }

                    if (IsValidCell(whiteRow - 1, whiteCol - 1, chessBoard) && chessBoard[whiteRow - 1, whiteCol - 1] == 'b')
                    {
                        whiteRow--;
                        whiteCol--;

                        Console.WriteLine($"Game over! White capture on {(char)(97 + whiteCol)}{8 - whiteRow}.");

                        return;
                    }

                    if (IsValidCell(whiteRow - 1, whiteCol + 1, chessBoard) && chessBoard[whiteRow - 1, whiteCol + 1] == 'b')
                    {
                        whiteRow--;
                        whiteCol++;

                        Console.WriteLine($"Game over! White capture on {(char)(97 + whiteCol)}{8 - whiteRow}.");

                        return;
                    }

                    whiteRow--;
                    chessBoard[whiteRow, whiteCol] = 'w';

                }
                else
                {
                    if (blackRow == 7)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(97 + blackCol)}1.");

                        return;
                    }

                    if (IsValidCell(blackRow + 1, blackCol - 1, chessBoard) && chessBoard[blackRow + 1, blackCol - 1] == 'w')
                    {
                        blackRow++;
                        blackCol--;

                        Console.WriteLine($"Game over! Black capture on {(char)(97 + blackCol)}{8 - blackRow}.");

                        return;
                    }

                    if (IsValidCell(blackRow + 1, blackCol + 1, chessBoard) && chessBoard[blackRow + 1, blackCol + 1] == 'w')
                    {
                        blackRow++;
                        blackCol++;

                        Console.WriteLine($"Game over! Black capture on {(char)(97 + blackCol)}{8 - blackRow}.");

                        return;
                    }

                    blackRow++;
                    chessBoard[blackRow, blackCol] = 'b';
                }

                whiteTurn = !whiteTurn;
            }
        }

        static bool IsValidCell(int row, int col, char[,] matrix)
        {
            return row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1);
        }
    }
}

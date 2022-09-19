using System;
using System.Linq;

namespace WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int playerRow = 0;
            int playerCol = 0;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string chars = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = chars[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string moves = Console.ReadLine();

            foreach (char move in moves)
            {
                bool playerWon = false;
                bool playerLost = false;

                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                switch (move)
                {
                    case 'U':
                        matrix[playerRow, playerCol] = '.';
                        newPlayerRow--;
                        MovePlayer(newPlayerRow, playerCol, matrix, ref playerWon, ref playerLost);
                        break;
                    case 'D':
                        matrix[playerRow, playerCol] = '.';
                        newPlayerRow++;
                        MovePlayer(newPlayerRow, playerCol, matrix, ref playerWon, ref playerLost);
                        break;
                    case 'L':
                        matrix[playerRow, playerCol] = '.';
                        newPlayerCol--;
                        MovePlayer(playerRow, newPlayerCol, matrix, ref playerWon, ref playerLost);
                        break;
                    case 'R':
                        matrix[playerRow, playerCol] = '.';
                        newPlayerCol++;
                        MovePlayer(playerRow, newPlayerCol, matrix, ref playerWon, ref playerLost);
                        break;
                }

                matrix = SpreadBunnies(matrix, ref playerLost);

                if (playerWon)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {playerRow} {playerCol}");

                    return;
                }

                playerRow = newPlayerRow;
                playerCol = newPlayerCol;

                if (playerLost)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");

                    return;
                }
            }
        }

        static void MovePlayer(int playerRow, int playerCol, char[,] matrix, ref bool playerWon, ref bool playerLost)
        {
            if (IsCellValid(playerRow, playerCol, matrix))
            {
                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerLost = true;
                }
                else
                {
                    matrix[playerRow, playerCol] = 'P';
                }
            }
            else
            {
                playerWon = true;
            }
        }

        static char[,] SpreadBunnies(char[,] matrix, ref bool playerLost)
        {
            char[,] newMatrix = CopyMatrix(matrix);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (IsCellValid(row - 1, col, matrix))
                        {
                            if (matrix[row - 1, col] == 'P')
                            {
                                playerLost = true;
                            }

                            newMatrix[row - 1, col] = 'B';
                        }

                        if (IsCellValid(row + 1, col, matrix))
                        {
                            if (matrix[row + 1, col] == 'P')
                            {
                                playerLost = true;
                            }

                            newMatrix[row + 1, col] = 'B';
                        }

                        if (IsCellValid(row, col - 1, matrix))
                        {
                            if (matrix[row, col - 1] == 'P')
                            {
                                playerLost = true;
                            }

                            newMatrix[row, col - 1] = 'B';
                        }

                        if (IsCellValid(row, col + 1, matrix))
                        {
                            if (matrix[row, col + 1] == 'P')
                            {
                                playerLost = true;
                            }

                            newMatrix[row, col + 1] = 'B';
                        }
                    }
                }
            }

            return newMatrix;
        }

        static bool IsCellValid(int row, int col, char[,] matrix)
        {
            return row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1);
        }

        static char[,] CopyMatrix(char[,] matrix)
        {
            char[,] copy = new char[matrix.GetLength(0), matrix.GetLength(1)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    copy[row, col] = matrix[row, col];
                }
            }

            return copy;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}

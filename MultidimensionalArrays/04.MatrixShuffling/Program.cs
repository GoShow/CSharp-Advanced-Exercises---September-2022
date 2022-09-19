using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] strings = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = strings[col];
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (IsValidCommand(dimensions, tokens))
                {
                    string tempValue = matrix[int.Parse(tokens[1]), int.Parse(tokens[2])]; // Hello
                    matrix[int.Parse(tokens[1]), int.Parse(tokens[2])] = matrix[int.Parse(tokens[3]), int.Parse(tokens[4])]; //Hello -> World
                    matrix[int.Parse(tokens[3]), int.Parse(tokens[4])] = tempValue; //World -> Hello

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        static void PrintMatrix(string[,] matrix)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        static bool IsValidCommand(int[] dimensions, string[] tokens)
        {
            return
                tokens[0] == "swap"
                && tokens.Length == 5
                && int.Parse(tokens[1]) >= 0 && int.Parse(tokens[1]) < dimensions[0]
                && int.Parse(tokens[2]) >= 0 && int.Parse(tokens[2]) < dimensions[1]
                && int.Parse(tokens[3]) >= 0 && int.Parse(tokens[3]) < dimensions[0]
                && int.Parse(tokens[4]) >= 0 && int.Parse(tokens[4]) < dimensions[1];
        }
    }
}

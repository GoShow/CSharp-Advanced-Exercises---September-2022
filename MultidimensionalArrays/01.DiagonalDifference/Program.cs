using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int leftRightSum = 0;
            int rightLeftSum = 0;

            for (int i = 0, j = size - 1; i < size; i++, j--)
            {
                leftRightSum += matrix[i, i];
                rightLeftSum += matrix[j, i];
            }

            Console.WriteLine(Math.Abs(leftRightSum - rightLeftSum));
        }
    }
}

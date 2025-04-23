using System;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsA = 200; // Specify the number of rows for matrix A
            int colsA = 200; // Specify the number of columns for matrix A
            int colsB = 200; // Specify the number of columns for matrix B

            int[,] matrixA = GenerateRandomMatrix(rowsA, colsA);
            int[,] matrixB = GenerateRandomMatrix(colsA, colsB); // colsA for rows of matrix B
            int[,] resultMatrix = new int[rowsA, colsB];

            Console.WriteLine("Matrix A:");
            PrintMatrix(matrixA);
            Console.WriteLine("\nMatrix B:");
            PrintMatrix(matrixB);

            MatrixMultiplier.MultiplyMatricesConcurrently(matrixA, matrixB, resultMatrix, rowsA, colsA, colsB, 4);

            Console.WriteLine("\nResult Matrix:");
            PrintMatrix(resultMatrix);
        }

        static int[,] GenerateRandomMatrix(int rows, int cols)
        {
            Random rand = new Random();
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.Next(1, 10); // Random numbers between 1 and 9
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    class MatrixMultiplier
    {
        public static void MatrixMultiplierThread(int[,] matrixA, int[,] matrixB, int[,] resultMatrix, int rowStart, int rowEnd, int rowsA, int colsA, int colsB)
        {
            for (int curr_Row = rowStart; curr_Row < rowEnd; curr_Row++)
            {
                for (int k = 0; k < colsB; k++)
                {
                    for (int curr_Col = 0; curr_Col < colsA; curr_Col++)
                    {
                        resultMatrix[curr_Row, k] += matrixA[curr_Row, curr_Col] * matrixB[curr_Col, k];
                    }
                }
            }
        }

        public static void MultiplyMatricesConcurrently(int[,] matrixA, int[,] matrixB, int[,] resultMatrix, int rowsA, int colsA, int colsB, int numThreads)
        {
            int amountPerThread = rowsA / numThreads;
            int remainder = rowsA % numThreads;
            
            Thread[] threads = new Thread[numThreads];

            for (int i = 0; i < numThreads; i++)
            {
                int rowStart = i * amountPerThread;
                int rowEnd = (i + 1) * amountPerThread;

                if (i == numThreads - 1)
                {
                    rowEnd += remainder; 
                }

                threads[i] = new Thread(() => MatrixMultiplierThread(matrixA, matrixB, resultMatrix, rowStart, rowEnd, rowsA, colsA, colsB));
                threads[i].Start();
            }

            for (int i = 0; i < numThreads; i++)
            {
                threads[i].Join();
            }

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    Console.Write(resultMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            
        }

    }

    class MatrixMultiplier
    {
        //static function for each thread
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

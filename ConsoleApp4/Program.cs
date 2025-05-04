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
            for (int curr_Row = rowStart; curr_Row < rowEnd; curr_Row++)//looping over assigned rows
            {
                for (int k = 0; k < colsB; k++)//looping over columns of matrixB
                {
                    for (int curr_Col = 0; curr_Col < colsA; curr_Col++)//multipling each row elemnt with column element and summing
                    {
                        resultMatrix[curr_Row, k] += matrixA[curr_Row, curr_Col] * matrixB[curr_Col, k];
                    }
                }
            }
        }

        public static void MultiplyMatricesConcurrently(int[,] matrixA, int[,] matrixB, int[,] resultMatrix, int rowsA, int colsA, int colsB, int numThreads)
        {
            
            int amountPerThread = rowsA / numThreads; //amount of rows per each thread
            int remainder = rowsA % numThreads; //the amout of rows left after partition, will be added to the last thread
            
            Thread[] threads = new Thread[numThreads]; //creating an array of threads

            for (int i = 0; i < numThreads; i++)
            {
                int rowStart = i * amountPerThread; //starting row for the specific thread
                int rowEnd = (i + 1) * amountPerThread; //ending row for the specific thread

                if (i == numThreads - 1) //incase this is the last thread add the remainder if necessary
                {
                    rowEnd += remainder; 
                }

                threads[i] = new Thread(() => MatrixMultiplierThread(matrixA, matrixB, resultMatrix, rowStart, rowEnd, rowsA, colsA, colsB)); //initialisng current thread with the needed function paramters
                threads[i].Start(); //starting the thread
            }

            for (int i = 0; i < numThreads; i++) //joining all threads before exiting the method, so they will all finish before exiting the method
            {
                threads[i].Join(); 
            }
        }
    }
}

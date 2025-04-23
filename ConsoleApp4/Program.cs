using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static void ThreadTest()
        {
            
            Console.WriteLine("Hellow, world" + new Random().Next());

        }
        static void Main(string[] args)
        {

    int[,] matrixA = new int[,] {
    {1, 2, 3,4},
    {4, 5, 6,5},
    {7, 8, 9,6},
    {10, 11, 12,7}
};
                int[,] matrixB = new int[,] {
    {1, 2, 3,4},
    {4, 5, 6,5},
    {7, 8, 9,6},
    {10, 11, 12,7}
};
                int[,] resultMatrix = new int[,] {
    {0, 0, 0,0},
    {0, 0, 0,0},
    {0, 0, 0,0},
    {0, 0, 0,0},

};


            MatrixMultiplier.MultiplyMatricesConcurrently(matrixA,matrixB,resultMatrix,4,4,4,2);

        }
    }
    class MatrixMultiplier
    {
        public static void MatrixMultiplierThread(int[,]matrixA, int[,]matrixB, int[,] resultMatrix,int rowStart, int rowEnd,int rowsA, int colsA, int colsB) //The thread, passing all needed info
        {
            Console.WriteLine($"starting row: {rowEnd}");
            for (int curr_Row = rowStart; curr_Row < rowEnd; curr_Row++) //Going through the needed rows for this thread
            {
                
                for(int k = 0; k < colsB; k++) //Going through each column in matrixB
                { 

                    for(int curr_Col = 0; curr_Col<colsA; curr_Col++) //Calculating the sum of the current Row * current Column and inserting to the respective place in the result matrix
                       
                    {
                        Console.WriteLine($"current row: {curr_Row}");
                        Console.WriteLine($"current row: {k}");
                        Console.WriteLine($"result matrix row: {resultMatrix[curr_Row, k]}");
                        Console.WriteLine($"columns: {colsA}");
                        resultMatrix[curr_Row, k] += matrixA[curr_Row, curr_Col] * matrixB[curr_Col, k];
                    }
                }
                
            }
        }
        public static void MultiplyMatricesConcurrently(int[,]matrixA, int[,]matrixB, int[,] resultMatrix, int rowsA, int colsA, int colsB, int numThreads)
        {
            int amountPerThread = rowsA / numThreads;
       
            if (amountPerThread * numThreads != rowsA)
            {
                amountPerThread++;
            Console.WriteLine($"Amount per thread: {amountPerThread}");
            Thread[] threads = new Thread[numThreads];
            for(int i =0; i < numThreads-1; i++)
            {
                Console.WriteLine($"yasssrow: {i*amountPerThread}");
                threads[i] = new Thread(() => MatrixMultiplierThread(matrixA,matrixB, resultMatrix, (i-1)*amountPerThread, i*amountPerThread,rowsA,colsA,colsB));
                
            }
            threads[numThreads-1] = new Thread(() => MatrixMultiplierThread(matrixA,matrixB, resultMatrix, (numThreads-1)*amountPerThread, rowsA,rowsA,colsA,colsB));
            for(int i = 0; i < numThreads; i++)
                {
                      threads[i].Start();
                }



            for(int i = 0; i < numThreads; i++)
            {
                threads[i].Join();
            }


            for(int i =0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    Console.WriteLine(resultMatrix[i,j]);
                }
            }
            }
                



            else
            {

                 Console.WriteLine($"Amount per thread: {amountPerThread}");
            Thread[] threads = new Thread[numThreads];
            for(int i =0; i < numThreads; i++)
            {
                Console.WriteLine($"yasssrow: {i*amountPerThread}");
                threads[i] = new Thread(() => MatrixMultiplierThread(matrixA,matrixB, resultMatrix, (i-1)*amountPerThread, i*amountPerThread,rowsA,colsA,colsB));
              
            }
            for(int i = 0; i < numThreads; i++)
                {
                      threads[i].Start();
                }

            for(int i = 0; i < numThreads; i++)
            {
                threads[i].Join();
            }


            for(int i =0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    Console.WriteLine("th result: "+resultMatrix[i,j]);
                }
            }
            }


        }
    }
}

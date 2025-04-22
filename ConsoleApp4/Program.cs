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
            Stopwatch stop = Stopwatch.StartNew();
            Thread thread = new Thread(ThreadTest);
            thread.Start();

            stop.Stop();
            Console.WriteLine($"Time taken: {stop.Elapsed.TotalMilliseconds} ms");

        }
    }
    class MatrixMultiplier
    {
        public static MatrixMultiplierThread()
        public static void MultiplyMatricesConcurrently(int[,]matrixA, int[,]matrixB, int[,] resultMatrix, int rowsA, int colsA, int colsB, int numThreads)
        {
            int amountPerThread = rowsA / numThreads;

            if (amountPerThread * numThreads != rowsA)
                amountPerThread++;
            Thread[] threads = new Thread[amountPerThread];


        }
    }
}
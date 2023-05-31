using System;
using System.Runtime.InteropServices;
using System.Threading;
using static System.Threading.Thread;

namespace Simulator
{
    class Program
    {
        static SharableSpreadSheet SSS;
        static int nOperations;
        static int rows;
        static int cols;
        static int nThreads;
        static int mssleep;

        static void Main(string[] args)
        {
            rows = Int32.Parse(args[0]);
            cols = Int32.Parse(args[1]);
            nThreads = Int32.Parse(args[2]);
            nOperations = Int32.Parse(args[3]);
            mssleep = Int32.Parse(args[4]);

            SSS = new SharableSpreadSheet(rows, cols, nThreads);

            //intilizing all cells in the table 
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    SSS.setCell(i, j, "testcell" + i.ToString() + j.ToString());
            }


            //array of threads
            Thread[] threads = new Thread[nThreads];

            //sending each thread to the function
            for (int i = 0; i < nThreads; i++)
            {
                threads[i] = new Thread(SimulatorThread);
                threads[i].Start();
            }
            //waiting for all threads to finish
            for (int i = 0; i < nThreads; i++)
                threads[i].Join();

        }

        static void SimulatorThread()
        {
            var tup = SSS.getSize();
            rows = tup.Item1;
            cols = tup.Item2;

            string[] words = { "Chen","Frydman","Lena","SISE","Robert","Petal","Amit" };

            Random rand = new();
            for (int i = 0; i < nOperations; i++)
            {
                var str = "";
                int RandomOperation = rand.Next(0, 12);

                if (RandomOperation == 0)
                {
                    int row = rand.Next(0, rows);
                    int col = rand.Next(0, cols);
                    str = SSS.getCell(row, col);
                    Console.WriteLine($"User[{CurrentThread.ManagedThreadId}]: getCell[{row},{col}, cell includes:{str}].");
                }

                else if (RandomOperation == 1)
                {
                    int row = rand.Next(0, rows);
                    int col = rand.Next(0, cols);
                    int randomIndex = rand.Next(0, words.Length);
                    str = words[randomIndex];

                    SSS.setCell(row, col, str);
                    Console.WriteLine($"User[{CurrentThread.ManagedThreadId}]: setCell[{row},{col}, cell changed to:{str}].");
                }

                else if (RandomOperation == 2)
                {
                    int randomIndex = rand.Next(0, words.Length);
                    str = words[randomIndex];
                    tup = SSS.searchString(str);
                    Console.WriteLine($"User[{CurrentThread.ManagedThreadId}]: searchString [found at: {tup.Item1},{tup.Item2}, string is {str}].");
                }
                else if (RandomOperation == 3)
                {
                    int row1 = rand.Next(0, rows);
                    int row2 = rand.Next(row1, rows);
                    SSS.exchangeRows(row1, row2);
                    Console.WriteLine($"User[{CurrentThread.ManagedThreadId}]: exchangeRows [change between {row1},{row2}].");
                }

                else if (RandomOperation == 4)
                {
                    int col1 = rand.Next(0, cols);
                    int col2 = rand.Next(col1, cols);
                    SSS.exchangeCols(col1, col2);
                    Console.WriteLine($"User[{CurrentThread.ManagedThreadId}]: exchangeRows [change between {col1},{col2}].");
                }

                else if (RandomOperation == 5)
                {
                    int row = rand.Next(0, rows);
                    int randomIndex = rand.Next(0, words.Length);
                    str = words[randomIndex];
                    int col = SSS.searchInRow(row, str);
                    Console.WriteLine($"User[{CurrentThread.ManagedThreadId}]: searchInRow [row:{row}, found {str} in col:{col}].");
                }
                else if (RandomOperation == 6)
                { 
                    int col = rand.Next(0, cols);
                    int randomIndex = rand.Next(0, words.Length);
                    str = words[randomIndex];
                    int row = SSS.searchInCol(col, str);
                    Console.WriteLine($"User[{CurrentThread.ManagedThreadId}]: searchInCol [col:{col}, found {str} in row:{row}].");
                }
                else if (RandomOperation == 7)
                {
                    int row1 = rand.Next(0, rows - 2);
                    int row2 = rand.Next(row1, rows);
                    int col1 = rand.Next(0, cols - 2);
                    int col2 = rand.Next(col1, cols);
                    int randomIndex = rand.Next(0, words.Length);
                    str = words[randomIndex];
                    tup = SSS.searchInRange(col1, col2, row1, row2, str);
                    Console.WriteLine($"User[{CurrentThread.ManagedThreadId}]: searchInRange [row1:{row1} to row2:{row2}, col1:{col1} to col2:{col2}], found at: [{tup.Item1},{tup.Item2}].");
                }
                else if (RandomOperation == 8)
                {
                    int row = rand.Next(0, rows);
                    SSS.addRow(row);
                    Console.WriteLine($"User[{CurrentThread.ManagedThreadId}]: addRow [a new row added after {row}].");
                }
                else if (RandomOperation == 9)
                {
                    int col = rand.Next(0, cols);
                    SSS.addCol(col);
                    Console.WriteLine($"User[{CurrentThread.ManagedThreadId}]: addCol [a new col added after {col}].");
                }
                else if (RandomOperation == 10)
                {
                    int randomIndex = rand.Next(0, words.Length);
                    str = words[randomIndex];
                    int trueorfalse = rand.Next(0, 1);
                    Tuple<int, int>[] arr = SSS.findAll(str, trueorfalse != 0);
                    string tups = "";
                    for (int j = 0; j < arr.Length; j++)
                    {
                        tups += ($"<{arr[j].Item1},{arr[j].Item2}>, ");
                    }

                    if (tups.Length >= 2) tups = tups[..^2];
                    Console.WriteLine($"User[{CurrentThread.ManagedThreadId}]: findAll [the string: {str} found at cells: {tups}]");

                }
                else if (RandomOperation == 11)
                {
                    int randomIndex = rand.Next(0, words.Length);
                    string strOld = words[randomIndex];
                    randomIndex = rand.Next(0, words.Length);
                    string strNew = words[randomIndex];
                    SSS.setAll(strOld, strNew, rand.Next(0, 1) != 0);
                    Console.WriteLine($"User[{CurrentThread.ManagedThreadId}]: setAll [the old string: {strOld}, the new string: {strNew}].");
                }
                else if (RandomOperation == 12)
                {
                    tup = SSS.getSize();
                    int row = tup.Item1;
                    int col = tup.Item2;
                    Console.WriteLine($"User[{CurrentThread.ManagedThreadId}]: getSize [the size is:{row},{col}]");
                }
                Sleep(mssleep);
            }
        }
    }
}

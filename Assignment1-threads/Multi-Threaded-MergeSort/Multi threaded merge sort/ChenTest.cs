using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class ChenTest
{
    static void Main(string[] args)
    {
        MTMergeSort mTMergeSort = new MTMergeSort();
        string[] arrayInput = { "z", "y", "x", "a", "d", "do", "b", "a" };
        List<string> sortedList = mTMergeSort.MergeSort(arrayInput, 2);
        foreach (string str in sortedList)
        {
            Console.WriteLine(str);
        }
        Console.ReadKey();
    }

}
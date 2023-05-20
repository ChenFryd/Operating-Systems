using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

class MTMergeSort
{
    //wrapper function for MergeSortMultiThreaded
    public List<string> MergeSort(string[] strList, int nMin = 2)
    {
        MergeSortMultiThreaded(strList, 0, strList.Length-1, nMin);
        return strList.ToList();
    }

    public void MergeSortMultiThreaded(string[] strArray, int initial, int final, int nMin) {
        if (initial >= final)
            return;
        int mid = initial + (final-initial) / 2;
        if ((final-initial+1) > nMin) //if above threshold minimum number of string to sort, apply multithreading
        {
            Task firstHalf = Task.Run(() => MergeSortMultiThreaded(strArray, initial, mid, nMin));
            Task secondHalf = Task.Run(() => MergeSortMultiThreaded(strArray, mid +1, final, nMin));
            Task.WaitAll(firstHalf,secondHalf); //need to wait in order to merge them together. it's our join 
        }
        else { //else do it single thread
            MergeSortSingleThread(strArray, initial, mid);
            MergeSortSingleThread(strArray, mid+1, final);
        }
        Merge(strArray, initial, mid, final); //at the end merge between them
    }
    private void MergeSortSingleThread(string[] strArray, int initial, int final)
    {
        if (initial >= final)
            return;
        int mid = initial + (final - initial) / 2;
        MergeSortSingleThread(strArray, initial, mid);
        MergeSortSingleThread(strArray, mid+1, final);
        Merge(strArray, initial, mid, final);
    }
    public void Merge(string[] arr, int leftStart, int mid, int rightEnd)
    {
        if (leftStart == rightEnd)
            return;
        int leftLength = mid - leftStart +1;
        int rightLength = rightEnd - mid;

        //inititate the temp arrays
        string[] tempLeft = new string[leftLength];
        string[] tempRight = new string[rightLength];
        for (int i = 0; i< leftLength; i++)
            tempLeft[i] = arr[leftStart+i];
        for (int j = 0; j < rightLength; j++)
            tempRight[j] = arr[mid +j+1];
        
        //initiate the runners - those are for keeping index of the updated arrays.
        int arrRunner = leftStart; 
        int leftRunner = 0;
        int rightRunner = 0;
        
        //continue one by one to update the main array.
        while (leftRunner < leftLength && rightRunner < rightLength)
        {
            if (String.Compare(tempLeft[leftRunner],tempRight[rightRunner]) < 0)
                arr[arrRunner] = tempLeft[leftRunner++];
            else
                arr[arrRunner] = tempRight[rightRunner++];
            arrRunner++;
        }

        //update the lasting items
        while (leftRunner < leftLength) {
            arr[arrRunner++] = tempLeft[leftRunner++];
        }

        while (rightRunner < rightLength){
            arr[arrRunner++] = tempRight[rightRunner++];
        }
    }
}

class IftachTest
{
    //test were made up by iftach.s
    static void Main(string[] args)
    {
        //if you want to change or add, you can but make sure its in the right order!
        string[] arr = { "a", "b", "c", "d", "e", "f", "f", "g", "h", "i", "i" };

        List<String> Answer = new List<String>();
        Answer = arr.ToList();
        MTMergeSort mergeSort = new MTMergeSort();
        int flag = 0;
        string ans = string.Join(" ", arr);

        //---------------------------------
        //change here to the amount wanted:
        int loops = 100;
        //---------------------------------


        for (int i = 0; i < loops; i++)
        {
            string[] test = new String[arr.Length];
            Array.Copy(arr, test, arr.Length);
            var rng = new Random();
            rng.Shuffle(test);
            string s = string.Join(" ", test);
            if (!mergeSort.MergeSort(test).compareList(Answer))
            {
                Console.WriteLine("test failed: got:\n " + s);
                Console.WriteLine("expected:\n " + ans);
                flag = 1;
            }
            else
            {
                Console.WriteLine("Test number " + i.ToString() + " Passed!!! with the next array: " + s);
            }

        }
        if (flag == 0) { Console.WriteLine("\nAll " + loops.ToString() + " test passed!!\nwell done!!! "); }
        Console.ReadKey();

    }

}
static class RandomExtensions
{
    public static void Shuffle<T>(this Random rng, T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }

    public static Boolean compareList(this List<String> list1, List<String> list2)
    {
        try
        {
            for (int i = 0; i < list1.Count; i++)
            {
                if (!list1[i].Equals(list2[i]))
                {
                    return false;
                }
            }
            return true;
        }
        catch (Exception e) { return false; }
    }
}
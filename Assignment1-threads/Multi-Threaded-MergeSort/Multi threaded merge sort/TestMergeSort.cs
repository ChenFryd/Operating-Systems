// test class
class TestMergeSort
{
    public static void Main(string[] args)
    {
        // #1 test
        // list to be sorted
        string[] lettersList = { "a", "h", "b", "d", "e", "l", "c", "r", "g", "i", "q", "j", "y", "f", "k", "t", "u", "n", "o", "m", "p", "s", "w", "v", "z", "x" };
        // sort list
        MTMergeSort ms = new MTMergeSort();
        // sorted list
        string[] sortedLetters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        List<string> sorted = ms.MergeSort(lettersList, 2);
        bool passedTest = sortedLetters.SequenceEqual(sorted);
        if (passedTest)
            Console.WriteLine("Passed test!");
        else Console.WriteLine("Test failed.");

        // #2 test
        // list to be sorted
        string[] countries = { "United States", "China", "Japan", "Germany", "United Kingdom", "India", "France", "Brazil", "Italy", "Canada", "South Korea", "Russia", "Australia", "Spain", "Mexico", "Indonesia", "Netherlands", "Turkey", "Saudi Arabia", "Switzerland" };
        // sorted list
        string[] countriesSorted = { "Australia", "Brazil", "Canada", "China", "France", "Germany", "India", "Indonesia", "Italy", "Japan", "Mexico", "Netherlands", "Russia", "Saudi Arabia", "South Korea", "Spain", "Switzerland", "Turkey", "United Kingdom", "United States" };
        // sort list
        List<string> sorted2 = ms.MergeSort(countries, 3);
        passedTest = countriesSorted.SequenceEqual(sorted2);
        if (passedTest)
            Console.WriteLine("Passed test!");
        else Console.WriteLine("Test failed.");

        // #3 test
        string[] fruits = { "Apple", "Banana", "Orange", "Grapes", "Mango", "Strawberry", "Pineapple", "Kiwi", "Watermelon", "Peach", "Pear", "Cherry", "Blueberry", "Raspberry", "Blackberry", "Cantaloupe", "Honeydew", "Plum", "Grapefruit", "Pomegranate" };
        string[] fruitsSorted = { "Apple", "Banana", "Blackberry", "Blueberry", "Cantaloupe", "Cherry", "Grapefruit", "Grapes", "Honeydew", "Kiwi", "Mango", "Orange", "Peach", "Pear", "Pineapple", "Plum", "Pomegranate", "Raspberry", "Strawberry", "Watermelon" };
        List<string> sorted3 = ms.MergeSort(fruits, 4);
        passedTest = sorted3.SequenceEqual(fruitsSorted);
        if (passedTest)
            Console.WriteLine("Passed test!");
        else Console.WriteLine("Test failed.");

        Console.ReadKey();
    }
}
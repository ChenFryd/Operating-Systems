using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
class Program {
    static Color[][] largeImagePixels;
    static Color[][] smallImagePixels;
    static int largeImageHeight;
    static int largeImageWidth;
    static int smallImageHeight;
    static int smallImageWidth;
    static int sectorWidth;

    static void Main(string[] args)
    {
        //variables
        int amountThreads = 1;
        Thread[] threads;
        Bitmap largeImage;
        Bitmap smallImage;
        String searchMethod;

        //checking var
        if (args.Length != 4)
            Console.WriteLine("Paramater length is incorrect");
        try
        {
            amountThreads = int.Parse(args[2]);
        }
        catch {
            Console.WriteLine("threads must be a number");
        }
        if (amountThreads < 0)
        {
            Console.WriteLine("threads amount must be positive");
        }
        if (args[3] != "exact" && args[3] != "euclidian")
            Console.WriteLine("The matching must be exact or euclidian");

        

        // convert args parameters to variables
        try
        {
            largeImage = new Bitmap(args[0]);
            largeImageHeight = largeImage.Height;
            largeImageWidth = largeImage.Width;

            smallImage = new Bitmap(args[1]);
            smallImageHeight = smallImage.Height;
            smallImageWidth = smallImage.Width;

            //divide largeImage into sectors.
            sectorWidth = (int)Math.Ceiling((double)(largeImage.Width / (amountThreads)));
            
            searchMethod = args[3];
        }
        catch {
            throw new Exception("one of the images not found");
        }

        //initialize color[][] arrays
        largeImagePixels = new Color[largeImageWidth][];
        for (int x = 0; x < largeImageWidth; x++)
        {
            largeImagePixels[x] = new Color[largeImageHeight];
            for (int y = 0; y < largeImageHeight; y++)
            {
                largeImagePixels[x][y] = largeImage.GetPixel(x, y);
            }
        }

        smallImagePixels = new Color[smallImageWidth][];
        for (int x = 0; x < smallImageWidth; x++)
        {
            smallImagePixels[x] = new Color[smallImageHeight];
            for (int y = 0; y < smallImageHeight; y++)
            {
                smallImagePixels[x][y] = smallImage.GetPixel(x, y);
            }
        }

        //initalize threads
        threads = new Thread[amountThreads];
        for (int i = 0; i < amountThreads; i++)
        {
            if (searchMethod == "exact")
                threads[i] = new Thread(new ParameterizedThreadStart(searchExact));
            else if (searchMethod == "euclidian")
                threads[i] = new Thread(new ParameterizedThreadStart(searchEuclidian));
            else
                Console.WriteLine("Invalid search method");
            threads[i].Start(i); //insert sector parameter to the threads
        }
    }
    public static void searchExact(Object sectorIndexObject)
    {
        int sectorIndex = (int)sectorIndexObject;
        for (int i = sectorIndex * sectorWidth; i < (sectorIndex + 1) * sectorWidth; i++) //search within the sector
        {
            if (i + smallImageWidth > largeImageWidth)
                break;
            for (int j = 0; j < largeImageHeight - smallImageHeight + 1; j++) //search on eligible image places
            {
                bool breakOuterLoop = false;
                for (int k = 0; k < smallImageWidth; k++) //the small image
                {
                    if (breakOuterLoop)
                        break;
                    for (int l = 0; l < smallImageHeight; l++)
                    {
                        if (largeImagePixels[i + k][j + l] != smallImagePixels[k][l]) 
                        {
                            breakOuterLoop = true;
                            break;
                        }

                    }
                }
                //subimage found
                if (!breakOuterLoop)
                    Console.WriteLine(i+","+j);
            }
        }
    }


    public static void searchEuclidian(Object sectorIndexObject)
    {
        int maxValue = 5;
        int sectorIndex = (int)sectorIndexObject;
        for (int i = sectorIndex * sectorWidth; i < (sectorIndex + 1) * sectorWidth; i++)
        {
            if (i + smallImageWidth > largeImageWidth)
                break;
            for (int j = 0; j < largeImageHeight- smallImageHeight+1; j++)  //search on eligible image places
            {
                double sum = 0;
                bool breakOuterLoop = false;
                for (int k = 0; k < smallImageWidth; k++)
                {
                    if (breakOuterLoop)
                        break;
                    for (int l = 0; l < smallImageHeight; l++)
                    {
                        double redColorPow = Math.Pow(largeImagePixels[i + k][j + l].R - smallImagePixels[k][l].R, 2);
                        double greenColorPow = Math.Pow(largeImagePixels[i + k][j + l].G - smallImagePixels[k][l].G, 2);
                        double blueColorPow = Math.Pow(largeImagePixels[i + k][j + l].B - smallImagePixels[k][l].B, 2);
                        sum += (double)Math.Sqrt(redColorPow + greenColorPow + blueColorPow);
                        if (sum > maxValue)
                        {
                            breakOuterLoop = true;
                            break;
                        }

                    }
                }
                //subimage found
                if (!breakOuterLoop)
                    Console.WriteLine(i + "," + j);
            }
        }

    }
}
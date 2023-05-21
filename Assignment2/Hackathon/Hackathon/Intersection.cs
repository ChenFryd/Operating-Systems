using System;
using System.Collections.Generic;
using System.Threading;
class Car
{
    // You can add properties and methods specific to a Car object here
}
class Intersection
{
    // Buffers for each line
    private Dictionary<string, Queue<Car>> lineBuffers;

    // Producer and consumer rates
    private Dictionary<string, int> producerRates;
    private Dictionary<string, List<string>> cycle;
    private int consumerRate;

    // Mutex for synchronization
    private readonly object mutex = new object();
    private Mutex mutexIntersection;

    public Intersection(Dictionary<string, int> producerRatesInput, int consumerRate)
    {
        this.consumerRate = consumerRate;
        this.producerRates = producerRatesInput; 
        this.lineBuffers = new Dictionary<string, Queue<Car>>();
        this.cycle = new Dictionary<string, List<String>>();
        InitiateCycle();
        InitializeLineBuffers();
    }

    public void InitiateCycle() {
        cycle.Add("NorthToSouthAndNorthToEast", new List<string> { "NorthToSouth", "NorthToEast" });
        cycle.Add("WestToEastAndWestToNorth", new List<string> { "WestToEast", "WestToNorth" });
        cycle.Add("SouthToNorthAndSouthToWest", new List<string> { "SouthToNorth", "SouthToWest" });
        cycle.Add("EastToWestAndEastToNorth", new List<string> { "EastToWest", "EastToSouth" });
    }

    private void InitializeLineBuffers()
    {
        // Add line buffers for each direction
        lineBuffers.Add("NorthToSouth", new Queue<Car>());
        lineBuffers.Add("NorthToEast", new Queue<Car>());
        lineBuffers.Add("WestToEast", new Queue<Car>());
        lineBuffers.Add("WestToNorth", new Queue<Car>());
        lineBuffers.Add("SouthToNorth", new Queue<Car>());
        lineBuffers.Add("SouthToWest", new Queue<Car>());
        lineBuffers.Add("EastToWest", new Queue<Car>());
        lineBuffers.Add("EastToSouth", new Queue<Car>());
    }

    public void StartSimulation()
    {
        Thread producerThread = new Thread(Producer);
        Thread consumerThread = new Thread(Consumer);

        producerThread.Start();
        consumerThread.Start();
    }

    private void Producer()
    {
        while (true)
        {
            lock (mutex)
            {
                Console.WriteLine("Adding cars to the intersection:");

                foreach (var lineBuffer in lineBuffers)
                {
                    string direction = lineBuffer.Key;
                    Queue<Car> buffer = lineBuffer.Value;

                    for (int i = 0; i < producerRates[direction]; i++)
                    {
                        Car car = new Car(); // Create a new car object
                        buffer.Enqueue(car); // Add the car to the line buffer
                        Console.WriteLine($"- Car added to {direction} line");
                    }
                }

                Monitor.PulseAll(mutex); // Signal that cars are added

                Thread.Sleep(1000); // Simulate some time before next production
            }
        }
    }

    private void Consumer()
    {
        while (true)
        {
            lock (mutex)
            {
                Console.WriteLine("Crossing the intersection:");

                foreach (var cycleDir in cycle) //south to north, south to west
                { 
                    Queue<Car> buffer1 = lineBuffers[cycleDir.Value[0]];
                    Queue<Car> buffer2 = lineBuffers[cycleDir.Value[1]];
                    if (buffer1.Count >= consumerRate || buffer2.Count >= consumerRate)
                    {
                        for (int i = 0; i < consumerRate; i++)
                        {
                            if (buffer1.Count > 0)
                            {
                                Car car = buffer1.Dequeue(); // Remove car from the line buffer
                                Console.WriteLine($"- Car crossed from {cycleDir.Value[0]}");
                            }
                            if (buffer2.Count > 0)
                            {
                                Car car = buffer2.Dequeue(); // Remove car from the line buffer
                                Console.WriteLine($"- Car crossed from {cycleDir.Value[1]}");
                            }
                        }
                    }
                    
                }

                Monitor.PulseAll(mutex); // Signal that cars have crossed

                Thread.Sleep(1000); // Simulate some time before next consumption
            }
        }
    }
}


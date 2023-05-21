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

    public Intersection(int producerRate, int consumerRate)
    {
        this.consumerRate = consumerRate;
        this.producerRates = new Dictionary<string, int>();
        this.lineBuffers = new Dictionary<string, Queue<Car>>();
        this.cycle = new Dictionary<string, List<String>>();
        InitiateCycle();
        InitializeLineBuffers();
    }

    public void InitiateCycle() {
        cycle.Add("NorthToSouthAndNorthToEast", new List<string> { "NorthToSouth", "NorthToEast" });
        cycle.Add("WestToEastAndWestToSouth", new List<string> { "WestToEast", "WestToSouth" });
        cycle.Add("SouthToNorthAndSouthToWest", new List<string> { "SouthToNorth", "SouthToWest" });
        cycle.Add("EastToWestAndEastToNorth", new List<string> { "EastToWest", "EastToNorth" });
    }

    private void InitializeLineBuffers()
    {
        // Add line buffers for each direction
        lineBuffers.Add("NorthToSouth", new Queue<Car>());
        lineBuffers.Add("NorthToEast", new Queue<Car>());
        lineBuffers.Add("WestToEast", new Queue<Car>());
        lineBuffers.Add("WestToSouth", new Queue<Car>());
        lineBuffers.Add("SouthToNorth", new Queue<Car>());
        lineBuffers.Add("SouthToWest", new Queue<Car>());
        lineBuffers.Add("EastToWest", new Queue<Car>());
        lineBuffers.Add("EastToNorth", new Queue<Car>());
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

                    foreach (var direction in cycleDir.Value)
                    {
                        Queue<Car> buffer = lineBuffers[direction];

                        if (buffer.Count >= consumerRate)
                        {
                            for (int i = 0; i < consumerRate; i++)
                            {
                                Car car = buffer.Dequeue(); // Remove car from the line buffer
                                Console.WriteLine($"- Car crossed from {direction}");
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


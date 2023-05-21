using System;
using System.Collections.Generic;
using System.Threading;

class Car
{
    // You can add properties and methods specific to a Car object here
}

namespace Hackathon
{
    class Intersection
    {
        // Buffers for each line
        private Dictionary<string, Queue<Car>> lineBuffers;

        // Producer and consumer rates
        private Dictionary<string, int> producerRates;
        private Dictionary<string, List<string>> cycle;
        private Dictionary<string,Mutex> mutexDict;
        private int consumerRate;
        private UserControl2 _uc;


    


        public Intersection(Dictionary<string, int> producerRatesInput, int consumerRate, UserControl2 uc)
        {
            this.consumerRate = consumerRate;
            this.producerRates = producerRatesInput;
            this.lineBuffers = new Dictionary<string, Queue<Car>>();
            this.cycle = new Dictionary<string, List<String>>();
            this._uc = uc;
            InitiateCycle();
            InitializeLineBuffers();
        }

    public void InitiateCycle() {
        cycle.Add("NorthToSouthAndNorthToEast", new List<string> { "NorthToSouth", "NorthToEast" });
        cycle.Add("WestToEastAndWestToNorth", new List<string> { "WestToEast", "WestToNorth" });
        cycle.Add("SouthToNorthAndSouthToWest", new List<string> { "SouthToNorth", "SouthToWest" });
        cycle.Add("EastToWestAndEastToNorth", new List<string> { "EastToWest", "EastToSouth" });
    }
        public void InitiateMutex() {
            mutexDict.Add("NorthToSouth", new Mutex());
            mutexDict.Add("NorthToEast", new Mutex());
            mutexDict.Add("WestToEast", new Mutex());
            mutexDict.Add("WestToNorth", new Mutex());
            mutexDict.Add("SouthToNorth", new Mutex());
            mutexDict.Add("SouthToWest", new Mutex());
            mutexDict.Add("EastToWest", new Mutex());
            mutexDict.Add("EastToSouth", new Mutex());
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
                foreach (var lineBuffer in lineBuffers)
                {
                    string direction = lineBuffer.Key;
                    Queue<Car> buffer = lineBuffer.Value;
                    Mutex mutexLine = mutexDict[direction];
                    mutexLine.WaitOne();
                    for (int i = 0; i < producerRates[direction]; i++)
                    {
                        Car car = new Car(); // Create a new car object
                        _uc.AddCar(car);
                        buffer.Enqueue(car); // Add the car to the line buffer
                    }
                    mutexLine.ReleaseMutex();
                }
            }
        }

        private void Consumer()
        {
            while (true)
            {
                foreach (var cycleDir in cycle) //south to north, south to west
                {
                    string dir1 = cycleDir.Value[0];
                    string dir2 = cycleDir.Value[1];
                    Queue<Car> buffer1 = lineBuffers[dir1];
                    Queue<Car> buffer2 = lineBuffers[dir2];
                    Mutex mutexDir1 = mutexDict[dir1];
                    Mutex mutexDir2 = mutexDict[dir2];
                    mutexDir1.WaitOne();
                    mutexDir2.WaitOne();
                    if (buffer1.Count >= consumerRate || buffer2.Count >= consumerRate)
                    {
                        for (int i = 0; i < consumerRate; i++)
                        {
                            if (buffer1.Count > 0)
                            {
                                Car car = buffer1.Dequeue(); // Remove car from the line buffer
                                _uc.RemoveCar(car);
                            }
                            if (buffer2.Count > 0)
                            {
                                Car car = buffer2.Dequeue(); // Remove car from the line buffer
                                _uc.RemoveCar(car);
                            }
                        }
                    }
                    mutexDir1.ReleaseMutex();
                    mutexDir2.ReleaseMutex();
                }
            }
        }
    }
}

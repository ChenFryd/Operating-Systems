using System;
using System.Collections.Generic;
using System.Threading;
using WinFormsApp1;

class CookieJar
{
    private int buffer; // Number of cookies in the jar
    private readonly int maxCapacity; // Maximum capacity of the jar

    public CookieJar(int maxCapacity)
    {
        this.maxCapacity = maxCapacity;
    }

    public void Produce(int produceRate)
    {
        lock (this)
        {
            while (buffer >= maxCapacity)
            {
                Console.WriteLine("Cookie jar is full. Waiting for consumers...");
                Monitor.Wait(this);
            }

            Console.WriteLine($"Mom refilling {produceRate} cookies.");
            buffer += produceRate;

            Monitor.PulseAll(this); // Notify waiting consumers that cookies are available
        }
    }

    public void Consume(int consumerId, int consumeRate)
    {
        lock (this)
        {
            while (buffer < consumeRate)
            {
                Console.WriteLine($"Consumer {consumerId} is waiting for cookies...");
                Monitor.Wait(this);
            }

            Console.WriteLine($"Consumer {consumerId} is eating {consumeRate} cookies.");
            buffer -= consumeRate;

            Monitor.PulseAll(this); // Notify waiting producer that cookies have been consumed
        }
    }
}

class Program
{
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());

        const int bufferSize = 10;
        const int consumersCount = 5;
        const int produceRate = 4;
        const int consumeRate = 2;

        CookieJar cookieJar = new CookieJar(bufferSize);

        // Create producer thread
        Thread producerThread = new Thread(() =>
        {
            while (true)
            {
                cookieJar.Produce(produceRate);
                Thread.Sleep(1000); // Simulate production time
            }
        });

        // Create consumer threads
        List<Thread> consumerThreads = new List<Thread>();
        for (int i = 0; i < consumersCount; i++)
        {
            int consumerId = i;
            Thread consumerThread = new Thread(() =>
            {
                while (true)
                {
                    cookieJar.Consume(consumerId, consumeRate);
                    Thread.Sleep(1500); // Simulate consumption time
                }
            });
            consumerThreads.Add(consumerThread);
        }

        // Start the producer and consumer threads
        producerThread.Start();
        foreach (var consumerThread in consumerThreads)
        {
            consumerThread.Start();
        }

        // Wait for the threads to complete (in this example, it runs indefinitely until you terminate the program)
        producerThread.Join();
        foreach (var consumerThread in consumerThreads)
        {
            consumerThread.Join();
        }
        Console.ReadKey();
    }
}
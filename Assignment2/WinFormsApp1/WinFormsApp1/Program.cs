using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int producerRate = 5; // Number of cars produced per iteration
            int consumerRate = 3; // Number of cars consumed per iteration

            Intersection intersection = new Intersection(producerRate, consumerRate);
            intersection.StartSimulation();

            // Keep the main thread running
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}

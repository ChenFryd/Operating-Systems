/*using System;
using System.Collections.Generic;
using System.Threading;

class Intersection
{
    //how many lines there are
    private int _northToSouthLines;
    private int _northToEastLines;

    private int _westToEastLines;
    private int _westToNorthLines;

    private int _southToNorthLines;
    private int _southToWestLines;

    private int _eastToWestLines;
    private int _eastToSouthLines;

    //how many cars cross the intersection
    private int consumerRate;

    //how many cars are added to the intersection each minute
    private int _producerNorthToSouthLineRate;
    private int _producerNorthToEastLineRate;

    private int _producerWestToEastLineRate;
    private int _producerWestToNorthLineRate;

    private int _producerSouthToNorthLineRate;
    private int _producerSouthToWestLineRate;

    private int _producerEastToWestLineRate;
    private int _producerEastToSouthLineRate;

    //how much cars there are in each line
    private int _counterCarsNorthToSouth;
    private int _counterCarsNorthToEast;
    private int _counterCarsSouthToNorth;
    private int _counterCarsSouthToWest;
    private int _counterCarsWestToEast;
    private int _counterCarsWestToNorth;
    private int _counterCarsEastToWest;
    private int _counterCarsEastToSouth;


    public Intersection() //default values
    {
        //number of lines on each direction
        this._northToSouthLines = 1;
        this._northToEastLines = 1;
        this._westToNorthLines= 1;
        this._westToEastLines = 1;
        this._southToNorthLines = 1;
        this._southToWestLines = 1;
        this._eastToSouthLines = 1;
        this._eastToWestLines = 1;

        //how many cars can cross each green light
        this.consumerRate = 3;

        //current cars in each line
        this._counterCarsNorthToSouth = 0;
        this._counterCarsNorthToEast = 0;
        this._southToNorthLines = 0;
        this._counterCarsSouthToWest = 0;
        this._counterCarsWestToEast = 0;
        this._counterCarsWestToNorth = 0;
        this._counterCarsEastToWest= 0;
        this._counterCarsEastToSouth = 0;
}

    public void cycle() {
        AddCars();
        crossNorthToSouthAndCrossSouthToNorth();
        AddCars();
        crossNorthToSouthAndCrossNorthToEast();
        AddCars();
        crossEastToWestAndCrossWestToEast();
        AddCars();
        crossEastToWestAndCrossEastToSouth();
        AddCars();
        crossNorthToSouthAndCrossSouthToNorth();
        AddCars();
        crossSouthToNorthAndCrossSouthToWest();
        AddCars();
        crossEastToWestAndCrossWestToEast();
        AddCars();
        crossWestToNorthAndWestToEast();
    }
    public void crossNorthToSouthAndCrossSouthToNorth()
    {
        lock (this)
        {
            Console.WriteLine($"{consumerRate*_northToSouthLines} Cars crossing from the North to the South and {consumerRate * _southToNorthLines} cars crossing from the South to the North.");
            _counterCarsNorthToSouth -= consumerRate * _westToEastLines;
            _counterCarsSouthToNorth -= consumerRate * _southToNorthLines;
            Monitor.PulseAll(this);
        }
    }
    public void crossNorthToSouthAndCrossNorthToEast()
    {
        lock (this)
        {
            Console.WriteLine($"{consumerRate * _northToSouthLines} Cars crossing from the north to the South and {consumerRate * _northToEastLines} cars crossing from the north to the East.");
            _counterCarsNorthToSouth -= consumerRate * _northToSouthLines;
            _counterCarsNorthToEast -= consumerRate * _northToEastLines;
            Monitor.PulseAll(this);
        }
    }

    public void crossEastToWestAndCrossWestToEast() {
        lock (this)
        {
            Console.WriteLine($"{consumerRate * _counterCarsEastToWest} Cars crossing from the East to the West and {consumerRate * _westToEastLines} cars crossing from the West to the East.");
            _counterCarsEastToWest -= consumerRate * _counterCarsEastToWest;
            _counterCarsWestToEast -= consumerRate * _westToEastLines;
            Monitor.PulseAll(this);
        }
    }
    public void crossEastToWestAndCrossEastToSouth()
    {
        lock (this)
        {
            Console.WriteLine($"{consumerRate * _eastToWestLines} Cars crossing from the East to the West and {consumerRate *_eastToSouthLines} cars crossing from the East to the South.");
            _counterCarsEastToWest -= consumerRate * _eastToWestLines;
            _counterCarsEastToSouth -= consumerRate * _eastToSouthLines;
            Monitor.PulseAll(this);
        }
    }

    public void crossSouthToNorthAndCrossSouthToWest() {
        lock (this)
        {
            Console.WriteLine($"{consumerRate * _southToNorthLines} Cars crossing from the South to the North and {consumerRate * _southToWestLines} cars crossing from the South to the West.");
            _counterCarsSouthToNorth -= consumerRate * _southToNorthLines;
            _counterCarsSouthToWest -= consumerRate * _southToWestLines;
            Monitor.PulseAll(this);
        }
    }

    public void crossWestToNorthAndWestToEast() {
        lock (this)
        {
            Console.WriteLine($"{consumerRate* _westToNorthLines} Cars crossing from the West to North and {consumerRate*_westToEastLines} cars crossing from the West to the East.");
            _counterCarsWestToNorth -= consumerRate*_westToNorthLines;
            _counterCarsWestToEast -= consumerRate*_westToEastLines;
            Monitor.PulseAll(this);
        }
    }
    public void AddCars()
    {
        lock (this)
        {
            Console.WriteLine($"Adding cars to the intersection:");
            Console.WriteLine($"- Adding cars in the North to South: {_producerNorthToSouthLineRate} cars.");
            Console.WriteLine($"- Adding cars in the North to East: {_producerNorthToEastLineRate} cars.");
            Console.WriteLine($"- Adding cars in the West to East: {_producerWestToEastLineRate} cars.");
            Console.WriteLine($"- Adding cars in the West to North: {_producerWestToNorthLineRate} cars.");
            Console.WriteLine($"- Adding cars in the East to South: {_producerEastToSouthLineRate} cars.");
            Console.WriteLine($"- Adding cars in the East to West: {_producerEastToWestLineRate} cars.");
            Console.WriteLine($"- Adding cars in the South to North: {_producerSouthToNorthLineRate} cars.");
            Console.WriteLine($"- Adding cars in the South to West: {_producerSouthToWestLineRate} cars.");

            _counterCarsNorthToSouth += _producerNorthToSouthLineRate;
            _counterCarsNorthToEast += _producerNorthToEastLineRate;
            _counterCarsEastToSouth += _producerEastToSouthLineRate;
            _counterCarsEastToWest += _producerEastToWestLineRate;
            _counterCarsSouthToNorth += _producerSouthToNorthLineRate;
            _counterCarsSouthToWest += _producerSouthToWestLineRate;
            _counterCarsWestToEast += _producerWestToEastLineRate;
            _counterCarsWestToNorth += _producerWestToNorthLineRate;

            Monitor.PulseAll(this);
        }
    }
}
*/
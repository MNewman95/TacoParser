﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS
            // Grab the path from the name of your file

            // Now, here's the new code

            // DONE Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            // DONE Create a `double` variable to store the distance
            ITrackable one = null;
            ITrackable two = null;
            double distance = 0;
           
            // DONE Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            foreach (var locA in locations)
            {
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;
                foreach (var locB in locations)
                {  
                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        one = locA;
                        two = locB;     
                    }

                }
            }
            Console.WriteLine($"{one.Name}is {TacoParser.ConvertToMiles(distance)} miles away from {two.Name}");
            // DONE Create a new corA Coordinate with your locA's lat and long

            // DONe Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // DONE Create a new Coordinate with your locB's lat and long

            // DONE Now, compare the two using `.GetDistanceTo()`, which returns a double
            // DONE If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above


            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.

            // DONE Convert the distance to miles
            // DONE Create a method to convert metres to miles in the TacoParser class
            //Write a unit test for the method in you tests
            // DONE Implement method in Program.cs
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Theory
{
    class Program
    {
        static void Main(string[] args)
        {


            TSP_Brute tsp = new TSP_Brute();
            Arun_Algorithim arjun = new Arun_Algorithim();


            List<GraphVertex> FullSet = new List<GraphVertex>();


            FullSet.Add(new GraphVertex("Miami", 25.785, -80.271));
            FullSet.Add(new GraphVertex("Seattle", 47.597, -122.335));
            FullSet.Add(new GraphVertex("San Diego", 32.779, -117.14));
            FullSet.Add(new GraphVertex("Augusta", 44.322, -69.777));
            FullSet.Add(new GraphVertex("San Francisco", 37.767, -122.424));
            FullSet.Add(new GraphVertex("Sacramento", 38.579, -121.468));
            FullSet.Add(new GraphVertex("Los Angeles", 34.044, -118.302));
            FullSet.Add(new GraphVertex("Portland", 45.514, -122.66));
            FullSet.Add(new GraphVertex("Bend", 44.034, -121.334));
            FullSet.Add(new GraphVertex("Spokane", 47.673, -117.386));
            FullSet.Add(new GraphVertex("Las Vegas", 36.151, -115.185));
            FullSet.Add(new GraphVertex("Boise", 43.605, -116.22));
            FullSet.Add(new GraphVertex("Salt Lake City", 40.723, -111.896));
            FullSet.Add(new GraphVertex("Tucson", 32.24, -110.951));
            FullSet.Add(new GraphVertex("Butte", 45.959, -112.558));
            FullSet.Add(new GraphVertex("Denver", 39.744, -104.986));
            FullSet.Add(new GraphVertex("Albuquerque", 35.108, -106.607));
            FullSet.Add(new GraphVertex("Cheyenne", 41.161, -104.834));
            FullSet.Add(new GraphVertex("Colorado Springs", 38.852, -104.765));
            FullSet.Add(new GraphVertex("Amarillo", 35.196, -101.845));
            FullSet.Add(new GraphVertex("Bismarck", 46.817, -100.733));
            FullSet.Add(new GraphVertex("Dodge City", 37.755, -100.026));
            FullSet.Add(new GraphVertex("Pierre", 44.425, -100.291));
            FullSet.Add(new GraphVertex("San Antonio", 29.472, -98.511));
            FullSet.Add(new GraphVertex("Lincoln", 40.82, -96.68));
            FullSet.Add(new GraphVertex("Oklahoma City", 35.474, -97.522));
            FullSet.Add(new GraphVertex("Dallas", 32.815, -96.802));
            FullSet.Add(new GraphVertex("Minneapolis", 44.979, -93.314));
            FullSet.Add(new GraphVertex("Des Moines", 41.6, -93.634));
            FullSet.Add(new GraphVertex("Kansas City", 39.102, -94.683));
            FullSet.Add(new GraphVertex("Houston", 29.77, -95.409));
            FullSet.Add(new GraphVertex("Duluth", 46.821, -92.13));
            FullSet.Add(new GraphVertex("Little Rock", 34.741, -92.332));
            FullSet.Add(new GraphVertex("Milwaukee", 43.046, -87.962));
            FullSet.Add(new GraphVertex("Springfield", 39.791, -89.646));
            FullSet.Add(new GraphVertex("Chicago", 41.868, -87.682));
            FullSet.Add(new GraphVertex("Memphis", 35.117, -89.951));
            FullSet.Add(new GraphVertex("Louisville", 38.212, -85.692));
            FullSet.Add(new GraphVertex("Gaylord", 44.995, -84.668));
            FullSet.Add(new GraphVertex("Lansing", 42.72, -84.559));
            FullSet.Add(new GraphVertex("Indianapolis", 39.799, -86.15));
            FullSet.Add(new GraphVertex("Nashville", 36.151, -86.782));
            FullSet.Add(new GraphVertex("Huntsville", 34.713, -86.622));
            FullSet.Add(new GraphVertex("Birmingham", 33.503, -86.793));
            FullSet.Add(new GraphVertex("Detroit", 42.368, -83.103));
            FullSet.Add(new GraphVertex("Cleveland", 41.461, -81.665));
            FullSet.Add(new GraphVertex("Columbus", 39.999, -82.99));
            FullSet.Add(new GraphVertex("Atlanta", 33.798, -84.38));
            FullSet.Add(new GraphVertex("Tallahassee", 30.454, -84.255));
            FullSet.Add(new GraphVertex("Charleston", 32.837, -79.993));
            FullSet.Add(new GraphVertex("Buffalo", 42.909, -78.829));
            FullSet.Add(new GraphVertex("Pittsburgh", 40.444, -79.991));
            FullSet.Add(new GraphVertex("Columbia", 34.028, -81.007));
            FullSet.Add(new GraphVertex("Savannah", 32.051, -81.107));
            FullSet.Add(new GraphVertex("Tampa", 27.988, -82.485));
            FullSet.Add(new GraphVertex("Charleston", 38.354, -81.634));
            FullSet.Add(new GraphVertex("Richmond", 37.552, -77.483));
            FullSet.Add(new GraphVertex("Raleigh", 35.821, -78.655));
            FullSet.Add(new GraphVertex("Albany", 42.661, -73.767));
            FullSet.Add(new GraphVertex("Philadelphia", 39.998, -75.145));
            FullSet.Add(new GraphVertex("Montpelier", 44.262, -72.583));
            FullSet.Add(new GraphVertex("New York", 40.753, -73.983));
            FullSet.Add(new GraphVertex("Concord", 42.457, -71.375));
            FullSet.Add(new GraphVertex("Boston", 42.336, -71.079));
            FullSet.Add(new GraphVertex("SAINT LOUIS", 38.635, -90.285));
            FullSet.Add(new GraphVertex("FLOYD", 36.91, -80.309));





            Graph todo = new Graph("todo");
            todo.AddVertices(FullSet.ToArray());

            for (int h = 0; h < FullSet.Count; h++)
            {
                for (int j = h + 1; j < FullSet.Count; j++)
                {
                    todo.AddEdge(FullSet[h], FullSet[j], 0, true);
                }

            }
            int i = 0;
            while (i != 3)
            {
                /*
                Stopwatch brute = new Stopwatch();
                brute.Start();
                tsp.BruteForceTSP(todo);
                brute.Stop();
                Console.WriteLine("With " + todo.Vertices.Count + " cities, it took " + brute.ElapsedMilliseconds + " when using the brute algorithim");
                */
                Stopwatch arun = new Stopwatch();
                arun.Start();
                arjun.ArunAlgorithim(todo);
                arun.Stop();
                Console.WriteLine("With " + todo.Vertices.Count + " cities, it took" + arun.ElapsedMilliseconds + " when using the arun algorithim");
                i++;
            }


            /*
                        for (int i = 2; i < FullSet.Count - 1; i++)
                        {
                            List<GraphVertex> SmallSet = new List<GraphVertex>();
                            Graph todo = new Graph("todo");

                            for (int j = 0; j < i; j++)
                            {
                                SmallSet.Add(FullSet[j]);
                            }
                            todo.AddVertices(SmallSet.ToArray());


                            for (int h = 0; h < SmallSet.Count; h++)
                            {
                                for (int j = h + 1; j < SmallSet.Count; j++)
                                {
                                    todo.AddEdge(FullSet[h], FullSet[j], 0, true);
                                }

                            }

                            Stopwatch brute = new Stopwatch();
                            brute.Start();
                            tsp.BruteForceTSP(todo);
                            brute.Stop();
                            Console.WriteLine("With " + i + " cities, it took " + brute.ElapsedMilliseconds + " when using the brute algorithim");

                            Stopwatch arun = new Stopwatch();
                            arun.Start();
                            arjun.ArunAlgorithim(todo);
                            arun.Stop();
                            Console.WriteLine("With " + i + " cities, it took" + arun.ElapsedMilliseconds + " when using the arun algorithim");

                        }

                */



            Console.Read();
        }



    }


}



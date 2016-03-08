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
            //FullSet.Add(new GraphVertex("Sacramento", 38.579, -121.468));
            //FullSet.Add(new GraphVertex("Los Angeles", 34.044, -118.302));
            //FullSet.Add(new GraphVertex("Portland", 45.514, -122.66));
            //FullSet.Add(new GraphVertex("Bend", 44.034, -121.334));
            // FullSet.Add(new GraphVertex("Spokane", 47.673, -117.386));




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
                Stopwatch brute = new Stopwatch();
                brute.Start();
                tsp.BruteForceTSP(todo);
                brute.Stop();
                Console.WriteLine("With " + todo.Vertices.Count + " cities, it took " + brute.ElapsedMilliseconds + " when using the brute algorithim");

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



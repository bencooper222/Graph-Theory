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
            /*
            TSP_Brute tsp = new TSP_Brute();
            //List<Vertex> set = new List<Vertex>();
            Graph todo = Graph.CompleteGraph(11, 1);
         



            var watch = Stopwatch.StartNew();
            Console.WriteLine(tsp.BruteForceTSP(todo));
            watch.Stop();
            Console.WriteLine("This computation took: " + watch.ElapsedMilliseconds + " milliseconds");
            Console.Read();*/

            Arun_Algorithim arjun = new Arun_Algorithim();
            Graph todo = new Graph("hi");
            List<GraphVertex> set = new List<GraphVertex>();

            
            set.Add(new GraphVertex("Miami", 25.785, -80.271));
            set.Add(new GraphVertex("Seattle", 47.597, -122.335));
            set.Add(new GraphVertex("San Diego", 32.779, -117.14));
            set.Add(new GraphVertex("Tampa", 27.988, -82.485));

            todo.AddVertices(set.ToArray());

            for(int i=0; i < set.Count; i++)
            {
                for (int j = i+1; j < set.Count; j++)
                {
                    todo.AddEdge(set[i], set[j], 0, true);
                    Console.WriteLine(set[i] + " " + set[j]);
                }
                    
            }


            Console.WriteLine(arjun.ArunAlgorithim(todo));
            Console.Read();
        }



    }


}



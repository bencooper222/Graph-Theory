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
            
            TSP_Algorithims tsp = new TSP_Algorithims();
            //Graph dc3 = new Graph("disconnected 3");
            List<Vertex> set = new List<Vertex>();
            /*
            set.Add(new Vertex("1"));
            set.Add(new Vertex("2"));
            set.Add(new Vertex("3"));
            set.Add(new Vertex("4"));
            set.Add(new Vertex("5"));
            set.Add(new Vertex("6"));
            set.Add(new Vertex("7"));
            set.Add(new Vertex("8"));
            set.Add(new Vertex("9"));
            set.Add(new Vertex("10")); */

            Graph todo = Graph.CompleteGraph(11, 1);
         

            /*       dc3.AddNodes(set.ToArray()); // this is K_3
                   dc3.AddEdge(set[0], set[1], 1);
                   dc3.AddEdge(set[1], set[2], 1);
                   dc3.AddEdge(set[0], set[2], 1); */

            /* dc3.AddNodes(set.ToArray()); // this is K_4
             dc3.AddEdge(set[0], set[1], 1);
             dc3.AddEdge(set[1], set[2], 1);
             dc3.AddEdge(set[2], set[3], 1);
             dc3.AddEdge(set[0], set[3], 100);
             dc3.AddEdge(set[0], set[2], 1);
             dc3.AddEdge(set[1], set[3], 1); */


            var watch = Stopwatch.StartNew();
            Console.WriteLine(tsp.BruteForceTSP(todo));
            watch.Stop();
            Console.WriteLine("This computation took: " + watch.ElapsedMilliseconds + " milliseconds");
            Console.Read();
        }



    }


}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Theory
{
    class Arun_Algorithim
    {

        public string ArunAlgorithim(Graph SalesmanLocations)
        {
            Graph configuration = new Graph("result");
            string results = "";

            List<GraphVertex> vertices = SalesmanLocations.Vertices;
            List<double> yPositions = new List<double>();
            foreach (GraphVertex v in vertices)
            {
                yPositions.Add(v.Coordinates[1]);
            }
            double averageYPos = Average(yPositions.ToArray());

            //divides into two separate lists based on the average
            List<GraphVertex> aboveAverage = SortHigher(vertices, averageYPos, true);
            List<GraphVertex> belowAverage = SortHigher(vertices, averageYPos, false);

            // sorts to save computing power later

            belowAverage = belowAverage.OrderBy(v => v.Coordinates[0]).ToList();
            aboveAverage = aboveAverage.OrderBy(v => v.Coordinates[0]).ToList();

            configuration.AddVertices(belowAverage.ToArray());
            configuration.AddVertices(aboveAverage.ToArray());

            // connects each set of edges
            for (int i = 0; i < belowAverage.Count - 1; i++)
            {
                double edgeWeight = SalesmanLocations.GetEdgeWeight(belowAverage[i], belowAverage[i + 1]);
                configuration.AddEdge(belowAverage[i], belowAverage[i + 1], edgeWeight, false);
                results += belowAverage[i] + " is connected to " + belowAverage[i + 1] + " with an edge weight of " + edgeWeight + "\n";
            }

            for (int i = 0; i < aboveAverage.Count - 1; i++)
            {
                double edgeWeight = SalesmanLocations.GetEdgeWeight(aboveAverage[i], aboveAverage[i + 1]);
                configuration.AddEdge(aboveAverage[i], aboveAverage[i + 1], edgeWeight, false);
                results += aboveAverage[i] + " is connected to " + aboveAverage[i + 1] + " with an edge weight of " + edgeWeight + "\n";
            }

            double westExtremeWeight = SalesmanLocations.GetEdgeWeight(aboveAverage[0], belowAverage[0]);
            configuration.AddEdge(belowAverage[0], aboveAverage[0], westExtremeWeight, false);
            results += belowAverage[0] + " is connected to " + aboveAverage[0] + " with an edge weight of " + westExtremeWeight + "\n";

            double eastExtremeWeight = SalesmanLocations.GetEdgeWeight(aboveAverage[aboveAverage.Count - 1], belowAverage[belowAverage.Count - 1]);
            configuration.AddEdge(aboveAverage[aboveAverage.Count - 1], belowAverage[belowAverage.Count - 1], eastExtremeWeight, false);
            results += aboveAverage[aboveAverage.Count - 1] + " is connected to " + belowAverage[belowAverage.Count - 1] + " with an edge weight of " + eastExtremeWeight + "\n";

            return results;

        }


        private double Average(params double[] numbers)
        {
            double sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            return sum / numbers.Length;
        }

        /// <summary>
        /// Returns a list that matches the higher or lower key 
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="limit"></param>
        /// <param name="higher">If true, will find all with y coordinate higher than limit. If false, will find ones lower.</param>
        /// <returns></returns>
        private List<GraphVertex> SortHigher(List<GraphVertex> vertices, double limit, bool higher)
        {
            List<GraphVertex> results = new List<GraphVertex>();
            foreach (GraphVertex v in vertices)
            {

                if (higher)
                {
                    if (v.Coordinates[1] > limit)
                    {

                        results.Add(v);
                    }

                }
                else
                {
                    if (v.Coordinates[1] < limit)
                    {
                        results.Add(v);
                    }
                }

            }
            return results;
        }

        private Graph ConnectComponents(List<GraphVertex> vertices)
        {
            Graph result = new Graph("connected");
            result.AddVertices(vertices.ToArray());

            for (int i = 0; i < result.Vertices.Count - 1; i++)
            {
                GraphVertex first = result.Vertices[i];
                GraphVertex second = result.Vertices[i + 1];

                //      result.AddEdge(first,second)
            }
            return Graph.CompleteGraphConstructor(2, 3);
        }
    }
}

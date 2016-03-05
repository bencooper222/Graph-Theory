using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Theory
{
    class TSP_Brute
    {
        public string BruteForceTSP(Graph SalesmanLocations)
        {
            string result = "NO RESULT";
            if (SalesmanLocations.IsConnected())
            {
                List<GraphVertex> vertices = SalesmanLocations.Vertices;
                List<List<GraphVertex>> permutations = GeneratePermutations(vertices);
                List<double> totalWeights = new List<double>();
                foreach (List<GraphVertex> permutation in permutations)
                {
                    if (PathExists(permutation))
                    {

                        totalWeights.Add(SumWeights(permutation));
                    }
                }

                double bestRun = totalWeights.Min();
                List<GraphVertex> bestPermutation = permutations[totalWeights.IndexOf(bestRun)];

                result = " ";
                foreach (GraphVertex v in bestPermutation)
                {
                    result += v;

                }
                result += bestPermutation[0]; // the computer is computing a cycle, this just makes the string reflect that
                result = result + " took a total of: " + bestRun + " weight units";
            }



            return result;
        }

        private bool PathExists(List<GraphVertex> vertices)
        {
            bool sameConnections = true;
            for (int i = 0; i < vertices.Count; i++)
            {
                if (i != vertices.Count - 1)
                {
                    if (!vertices[i].IsNeighbor(vertices[i + 1]))
                    {
                        sameConnections = false;
                    }
                }
                else
                {
                    if (!vertices[0].IsNeighbor(vertices[vertices.Count - 1]))
                    {
                        sameConnections = false;
                    }
                }
            }
            return sameConnections;
        }

        private double SumWeights(List<GraphVertex> vertices) // requires a graph that has a path thorugh it
        {
            double sum = 0;
            for (int i = 0; i < vertices.Count; i++)
            {
                List<GraphVertex> neighbors = vertices[i].Neighbors;
                if (i != vertices.Count - 1)
                {

                    int index = neighbors.IndexOf(vertices[i + 1]);
                    sum += vertices[i].Costs[index];
                }
                else
                {
                    int index = neighbors.IndexOf(vertices[0]);
                    sum += vertices[i].Costs[index];
                }

            }
            return sum;
        }




        private List<List<Vertex>> GeneratePermutations<Vertex>(List<Vertex> vertices) // creds to http://csharphelper.com/blog/2014/08/generate-all-of-the-permutations-of-a-set-of-objects-in-c/
        {
            // Make an array to hold the
            // permutation we are building.
            Vertex[] current_permutation = new Vertex[vertices.Count];

            // Make an array to tell whether
            // an item is in the current selection.
            bool[] in_selection = new bool[vertices.Count];

            // Make a result list.
            List<List<Vertex>> results = new List<List<Vertex>>();

            // Build the combinations recursively.
            PermuteItems<Vertex>(vertices, in_selection, current_permutation, results, 0);

            // Return the results.
            return results;
        }




        // Recursively permute the items that are
        // not yet in the current selection.
        private void PermuteItems<T>(List<T> items, bool[] in_selection, T[] current_permutation, List<List<T>> results, int next_position) // also stolen from http://csharphelper.com/blog/2014/08/generate-all-of-the-permutations-of-a-set-of-objects-in-c/
        {
            // See if all of the positions are filled.
            if (next_position == items.Count)
            {
                // All of the positioned are filled.
                // Save this permutation.
                results.Add(current_permutation.ToList());
            }
            else
            {
                // Try options for the next position.
                for (int i = 0; i < items.Count; i++)
                {
                    if (!in_selection[i])
                    {
                        // Add this item to the current permutation.
                        in_selection[i] = true;
                        current_permutation[next_position] = items[i];

                        // Recursively fill the remaining positions.
                        PermuteItems<T>(items, in_selection,
                            current_permutation, results,
                            next_position + 1);

                        // Remove the item from the current permutation.
                        in_selection[i] = false;
                    }
                }
            }
        }


        

    }
}

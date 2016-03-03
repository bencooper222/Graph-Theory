using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Theory
{
    class TSP_Algorithims
    {
        public string BruteForceTSP(Graph g) // must be run in a for loop that is equal to g.Count();
        {
            string result = "NO RESULT";
            if (g.IsConnected())
            {
                List<Vertex> vertices = g.Vertices;
                List<List<Vertex>> permutations = GeneratePermutations(vertices);
                List<double> totalWeights = new List<double>();
                foreach(List<Vertex> permutation in permutations)
                {
                    if (PathExists(permutation))
                    {
                        
                        totalWeights.Add(SumWeights(permutation));
                    }
                }

                double bestRun = totalWeights.Min();
                List<Vertex> bestPermutation = permutations[totalWeights.IndexOf(bestRun)];

                result = " ";
                foreach(Vertex v in bestPermutation)
                {
                    result += v;
                    
                }
                result += bestPermutation[0]; // the computer is computing a cycle, this just makes the string reflect that
                result = result + " took a total of: " + bestRun;
            }

           

            return result;
        }

        private bool PathExists(List<Vertex> vertices)
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
                    if (!vertices[0].IsNeighbor(vertices[vertices.Count-1]))
                    {
                        sameConnections = false;
                    }
                }
            }
            return sameConnections;
        }

        private double SumWeights(List<Vertex> vertices) // requires a graph that has a path thorugh it
        {
            double sum = 0;
            for (int i = 0; i < vertices.Count; i++)
            {
                List<Vertex> neighbors = vertices[i].Neighbors;
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



      
        private List<List<Vertex>> GeneratePermutations<Vertex>(List<Vertex> vertices)
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
            PermuteItems<Vertex>(vertices, in_selection,
                current_permutation, results, 0);

            // Return the results.
            return results;
        }




        // Recursively permute the items that are
        // not yet in the current selection.
        private void PermuteItems<T>(List<T> items, bool[] in_selection,
            T[] current_permutation, List<List<T>> results,
            int next_position)
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

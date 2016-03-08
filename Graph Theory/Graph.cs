using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Graph_Theory
{
    class Graph
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private List<GraphVertex> vertices = new List<GraphVertex>();
        public List<GraphVertex> Vertices
        {
            get
            {
                return vertices;
            }
        }

        public Graph(string name)
        {
            this.name = name;
        }

        public void AddVertex(GraphVertex vertex)
        {
            if (!Contains(vertex))
            {
                vertices.Add(vertex);
            }

        }

        /// <summary>
        /// Adds multiple vertices at a time
        /// </summary>
        /// <param name="verts">Indefinite paramter of vertices</param>
        public void AddVertices(params GraphVertex[] verts)
        {
            foreach (GraphVertex vert in verts)
            {
                AddVertex(vert);
            }
        }


        /// <summary>
        /// Adds an edge between 2 vertices of given cost
        /// </summary>
        /// <param name="one">A vertex</param>
        /// <param name="two">A second vertex</param>
        /// <param name="cost">Weight of edge between the two</param>
        public void AddEdge(GraphVertex one, GraphVertex two, double cost, bool calculateCost)
        {
            if (Contains(one) & Contains(two))
            {
                if (!one.Neighbors.Contains(two))
                {
                    if (!calculateCost)
                    {
                        one.Neighbors.Add(two);
                        one.Weights.Add(cost);

                        two.Neighbors.Add(one);
                        two.Weights.Add(cost);
                    }
                    if (calculateCost)
                    {
                        one.Neighbors.Add(two);
                        one.Weights.Add(Distance(one.Coordinates, two.Coordinates));

                        two.Neighbors.Add(one);
                        two.Weights.Add(Distance(one.Coordinates, two.Coordinates));
                    }

                }

            }

        }

        private double Distance(double[] coordinates1, double[] coordinates2)
        {
            return Math.Sqrt((coordinates1[0] - coordinates2[0]) * (coordinates1[0] - coordinates2[0]) + (coordinates1[1] - coordinates2[1]) * (coordinates1[1] - coordinates2[1]));
        }

        public void AddSameWeightedEdges(double cost, params GraphVertex[] vertices)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                for (int j = i; j < vertices.Length; j++)
                {
                    AddEdge(vertices[i], vertices[j], cost, false);

                }

            }
        }

        public double GetEdgeWeight(GraphVertex v1, GraphVertex v2)
        {
            int locationV1 = vertices.IndexOf(v1);
            int locationV2 = vertices[locationV1].Neighbors.IndexOf(v2);

            if (locationV1 != -1 & locationV2 != -1)
            {
                return vertices[locationV1].Weights[locationV2];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

        }

        public void RemoveVertex(GraphVertex vert)
        {
            foreach (GraphVertex v in vertices)
            {
                if (v == vert)
                {
                    vertices.Remove(v);
                }
            }
        }

        public bool Contains(GraphVertex ver1)
        {
            bool contain = false;
            foreach (GraphVertex vert in vertices)
            {
                if (vert == ver1)
                {
                    contain = true;
                }
            }
            return contain;
        }

        public int Count()
        {
            return vertices.Count;
        }

        public GraphVertex GetRandomVertex()
        {
            Random rand = new Random();
            return vertices[(int)rand.NextDouble() * Count()];

        }

        public bool IsConnected()
        {
            bool connected = true;
            foreach (GraphVertex v in vertices)
            {
                if (v.Neighbors.Count == 0)
                {
                    connected = false;
                }

            }
            return connected;
        }

        public Graph Duplicate()
        {
            return this;
        }

        public override string ToString()
        {
            string results = "";

            foreach (GraphVertex v in vertices)
            {
                results += (v + " ");
            }

            return results;
        }

        public static Graph operator +(Graph g1, Graph g2)
        {
            Graph result = new Graph(g1.Name + g2.Name);

            result.AddVertices(g1.Vertices.ToArray());
            result.AddVertices(g2.Vertices.ToArray());

            return result;
        }


        public static Graph CompleteGraphConstructor(int vertexTotal, double cost)
        {
            Graph result = new Graph("Complete_" + vertexTotal);
            GraphVertex[] vertexArray = new GraphVertex[vertexTotal];
            for (int i = 0; i < vertexTotal; i++)
            {

                GraphVertex toAdd = new GraphVertex(i.ToString(), 0, 0);
                result.AddVertex(toAdd);
                vertexArray[i] = toAdd;
            }
            result.AddSameWeightedEdges(cost, vertexArray);

            return result;
        }
    }
}

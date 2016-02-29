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
        public string Name { get; }
        private List<Vertex> vertices = new List<Vertex>();
        public List<Vertex> Vertices
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

        private void AddNode(Vertex vertex)
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
        public void AddNodes(params Vertex[] verts)
        {
            foreach (Vertex vert in verts)
            {
                AddNode(vert);
            }
        }


        /// <summary>
        /// Adds an edge between 2 vertices of given cost
        /// </summary>
        /// <param name="one">A vertex</param>
        /// <param name="two">A second vertex</param>
        /// <param name="cost">Weight of edge between the two</param>
        public void AddEdge(Vertex one, Vertex two, double cost)
        {
            if (Contains(one) & Contains(two))
            {
                one.Neighbors.Add(two);
                one.Costs.Add(cost);

                two.Neighbors.Add(one);
                two.Costs.Add(cost);
            }

        }

        /// <summary>
        /// Connects all given vertices with edges of the same weight
        /// </summary>
        /// <param name="cost">Weight desired</param>
        /// <param name="verts">Vertices to connect</param>
        public void AddSameWeightEdges(double cost, params Vertex[] verts)
        {
            for (int i = 0; i < verts.Length; i++)
            {
                for (int j = 0; j < verts.Length; j++)
                {
                    if (verts[i] != verts[j] & verts[i].IsConnected(verts[j]))
                    {
                        AddEdge(verts[i], verts[j], cost);
                    }
                }

            }
        }

        public bool Contains(Vertex ver1)
        {
            bool contain = false;
            foreach (Vertex vert in vertices)
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

    }
}

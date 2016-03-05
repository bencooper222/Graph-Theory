using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Theory
{
    class GraphVertex
    {
        private string nickname;
        private List<double> costs;
        private List<GraphVertex> neighbors;
        private double[] coordinates = new double[2];
       

        public bool IsBounded
        {
            get
            {
                if (coordinates == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
         
        }

        public double[] Coordinates
        {
            get
            {
                return coordinates;
            }
            set
            {
                coordinates = value;
            }
        }
        public GraphVertex(string name)
        {
            nickname = name;
        }
        


        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

        public List<double> Costs
        {
            get
            {
                if (costs == null)
                {
                    costs = new List<double>();
                }

                return costs;
            }
        }

        public List<GraphVertex> Neighbors
        {
            get
            {
                if (neighbors == null)
                {
                    neighbors = new List<GraphVertex>();
                }

                return neighbors;
            }
        }

        public bool IsNeighbor(GraphVertex ver)
        {
            if (neighbors.Contains(ver))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(GraphVertex ver1, GraphVertex ver2)
        {
            if (ver1.Nickname == ver2.Nickname)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(GraphVertex ver1, GraphVertex ver2)
        {
            if (ver1.Nickname == ver2.Nickname)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
        
            return nickname;
        }
    }
}

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
        private List<double> weights;
        private List<GraphVertex> neighbors;
        private double xPos;
        private double yPos;




        public double[] Coordinates
        {
            get
            {
                double[] coordinates = new double[2];
                coordinates[0] = xPos;
                coordinates[1] = yPos;
                return coordinates;
            }

        }
        public GraphVertex(string name, double xPos, double yPos)
        {
            nickname = name;
            this.xPos = xPos;
            this.yPos = yPos;
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

        public List<double> Weights
        {
            get
            {
                if (weights == null)
                {
                    weights = new List<double>();
                }

                return weights;
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
            return nickname + "(" + xPos + "," + yPos + ")";
        }
    }
}

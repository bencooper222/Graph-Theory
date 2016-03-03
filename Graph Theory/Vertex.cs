using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Theory
{
    class Vertex
    {
        private string nickname;
        private List<double> costs;
        private List<Vertex> neighbors;
        private string number; // used to designate order added to graph


        public Vertex(string name)
        {
            nickname = name;
        }
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
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

        public List<Vertex> Neighbors
        {
            get
            {
                if (neighbors == null)
                {
                    neighbors = new List<Vertex>();
                }

                return neighbors;
            }
        }

        public bool IsNeighbor(Vertex ver)
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

        public static bool operator ==(Vertex ver1, Vertex ver2)
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

        public static bool operator !=(Vertex ver1, Vertex ver2)
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

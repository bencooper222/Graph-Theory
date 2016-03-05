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
            belowAverage.Sort();
            aboveAverage.Sort();

           

            string result = "";
            return result;
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
                    if (v.Coordinates[1] < limit)
                    {
                        results.Add(v);
                    }
                }
               
            }
            return results;
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAD_3.Experiments
{
    public class Experiment1
    {
        KMeansAlgorithm kmeans;
        public List<Point> points;
        public List<Point> clusters;
        public int iteration;

        public Experiment1(int variant)
        {
            points = FileService.readPoints();
            kmeans = new KMeansAlgorithm();
            this.RandClusters(variant);

            iteration = kmeans.StartAlgorithm(ref points, ref clusters);
        }

        private void RandClusters(int variant)
        {
            Point p;
            Random r;
            double min = -10, max = 10;
            int group = 0;
            clusters = new List<Point>();

            for (int i = 0; i < variant; i++)
            {
                group++;
                p = new Point();

                r = new Random(Guid.NewGuid().GetHashCode());
                p.X = r.NextDouble() * (max - min) + min;

                r = new Random(Guid.NewGuid().GetHashCode());
                p.Y = r.NextDouble() * (max - min) + min;

                p.Group = group;

                clusters.Add(p);
            }
        }
    }
}

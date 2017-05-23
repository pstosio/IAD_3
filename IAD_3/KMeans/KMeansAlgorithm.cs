using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace IAD_3
{
    public class KMeansAlgorithm
    {
        private List<Point> memory;

        public int StartAlgorithm(ref List<Point> points, ref List<Point> clusters, int counterStop = 100)
        {
            int counter = 0;

            while (counter < counterStop)
            {
                this.RememberTheLastPointLocation(clusters);
                this.GroupReset(ref points);
                this.GivingGroupCollections(ref points, clusters);
                this.ClustersShift(points, ref clusters);

                if (this.DidPointsChange(clusters))
                {
                    break;
                }

                counter++;
            }

            return counter;
        }

        public void RememberTheLastPointLocation(List<Point> clusters)
        {
            memory = new List<Point>();
            memory = (List<Point>)this.DeepClone(clusters);
        }

        public object DeepClone(object obj)
        {
            object objResult = null;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(ms, obj);
                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }
            return objResult;
        }

        public void GroupReset(ref List<Point> points)
        {
            foreach (Point point in points)
            {
                point.Group = -1;
            }
        }

        public void GivingGroupCollections(ref List<Point> points, List<Point> clusters)
        {
            for (int i = 0; i < points.Count; i++)
            {
                Point point = points[i];
                this.GroupAssignment(ref point, clusters);
            }
        }
        public void GroupAssignment(ref Point point, List<Point> clusters)
        {
            Dictionary<double, Point> d = new Dictionary<double, Point>();

            foreach (var cluster in clusters)
            {
                double od = this.CountingDistances(cluster, point);

                while (d.ContainsKey(od))
                {
                    od = od + 0.000001;
                }

                d.Add(od, cluster);
            }

            var g = d.First(k => k.Key == d.Keys.Min()).Value.Group;

            point.Group = g;
        }

        public double CountingDistances(Point p1, Point p2)
        {
            double x = Math.Pow(p1.X - p2.X, 2);
            double y = Math.Pow(p1.Y - p2.Y, 2);

            return Math.Sqrt(x + y);
        }

        public void ClustersShift(List<Point> points, ref List<Point> clusters)
        {
            List<Point> tmpPoints;

            foreach (Point cluster in clusters)
            {
                tmpPoints = new List<Point>();

                foreach (Point point in points)
                {
                    if (point.Group == cluster.Group)
                    {
                        tmpPoints.Add(point);
                    }
                }

                double x1 = 0;
                double x2 = 0;

                if (tmpPoints.Count > 0)
                {
                    x1 = tmpPoints.Average(i => i.X);
                    x2 = tmpPoints.Average(i => i.Y);

                    cluster.X = x1;
                    cluster.Y = x2;
                }
            }
        }

        public bool DidPointsChange(List<Point> clusters)
        {
            bool yes = true;

            for (int i = 0; i < clusters.Count; i++)
            {
                if (Math.Abs(clusters[i].X - memory[i].X) > double.Epsilon)
                {
                    yes = false;
                }
            }

            return yes;
        }
    }
}

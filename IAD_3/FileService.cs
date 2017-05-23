using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAD_3
{
    public static class FileService
    {
        public static List<Point> readPoints()
        {
            List<Point> points = new List<Point>();

            string fileName = "attract.txt";
            string tmpLine;
            string[] splittedLine = null;

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                while ((tmpLine = streamReader.ReadLine()) != null)
                {
                    splittedLine = tmpLine.Split(',');

                    try
                    {
                        Point p = new Point();
                        p.X = Convert.ToDouble(splittedLine[0], System.Globalization.CultureInfo.InvariantCulture);
                        p.Y = Convert.ToDouble(splittedLine[1], System.Globalization.CultureInfo.InvariantCulture);

                        points.Add(p);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }

                }
            }

            return points;
        }
    }
}

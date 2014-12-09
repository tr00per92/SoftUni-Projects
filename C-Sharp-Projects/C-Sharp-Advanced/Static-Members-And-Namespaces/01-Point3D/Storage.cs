using System;
using System.IO;

namespace _01_Point3D
{
    static class Storage
    {
        const string Output = "../../txtFiles/output.txt";

        public static void WritePathToTxt(Path3D path)
        {
            StreamWriter writer = new StreamWriter(Output);

            using (writer)
            {
                foreach (var point in path.Points)
                {
                    writer.WriteLine(point);
                }
            }
        }

        public static Path3D ReadPathFromTxt(string pathToFile)
        {
            Path3D result = new Path3D();
            StreamReader reader = new StreamReader(pathToFile);            
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] coords = line.Split (new char[] { 'X', 'Y', 'Z', ' ', ':' },
                        StringSplitOptions.RemoveEmptyEntries);
                    result.Points.Add(new Point3D 
                        (Double.Parse(coords[0]), Double.Parse(coords[1]), Double.Parse(coords[2])));
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
}

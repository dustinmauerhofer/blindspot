using System;
using System.IO;

namespace BlindSpot
{
    public class Test
    {
        public static void WriteInFile()
        {
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.txt");

            using (StreamWriter sw = new StreamWriter(outputPath))
            {
                sw.WriteLine("Your data goes here");
            }
        }
    }
}

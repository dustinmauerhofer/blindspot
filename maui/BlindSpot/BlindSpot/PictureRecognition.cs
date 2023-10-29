using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace BlindSpot
{
    public class PictureRecognition
    {
        public static async Task<string> ScanPicture()
        {
            //string output = String.Empty;

            //// Get the current working directory
            //string currentDirectory = Directory.GetCurrentDirectory();

            //// Construct the full path to the Python script
            //string scriptPath = @"C:\Users\dustin\Documents\GitHub\blindspot\maui\BlindSpot\BlindSpot\AI\main.py";
            //string imagePath = @"C:\Users\dustin\Documents\GitHub\blindspot\maui\BlindSpot\BlindSpot\AI\blueberyy.jpg";

            //// Create a Python runtime
            //var pythonRuntime = Python.CreateRuntime();
            //dynamic python = pythonRuntime.UseFile(scriptPath);

            //// Call a Python function from your script
            //output = python.ScanImage(imagePath);

            //// Display the output received from the Python script

            //return output;

            return $"{File.Exists(@"C:\Users\dustin\Documents\GitHub\blindspot\maui\BlindSpot\BlindSpot\AI\main.py")}";
        }
    }
}




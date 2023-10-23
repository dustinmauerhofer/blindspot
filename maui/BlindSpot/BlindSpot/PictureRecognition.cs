using System.Diagnostics;


namespace BlindSpot
{
    public class PictureRecognition
    {
        public static async Task ScanPicture()
        {
       
            string pythonScript = Path.Combine(Environment.CurrentDirectory, "ai_model", "main.py");
            string pictureParameter = Path.Combine(Environment.CurrentDirectory, "ai_model", "blueberry.jpg");

            string outputPath = Path.Combine(Environment.CurrentDirectory, "ai_model", "output.txt");

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = $"\"{pythonScript}\" \"{pictureParameter}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = Path.GetDirectoryName(pythonScript)
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                try
                {
                    process.Start();
                }
                catch (Exception ex)
                {
                    using(StreamWriter writer = new StreamWriter(outputPath))
                    {
                        writer.WriteLine(ex.ToString());
                    }
                    return;
                }

                using (StreamReader reader = process.StandardOutput)
                {
                    string output = reader.ReadToEnd();
                    process.WaitForExit();

                    Console.WriteLine("Output: " + output);

                    File.WriteAllText(outputPath, output);
                }
            }
        }
    }
}

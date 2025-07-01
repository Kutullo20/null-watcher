using System;
using System.Collections.Generic;
using System.IO;

namespace Helpers
{
    public static class FileLoader
    {
        // Loads all file paths from the Samples directory
        public static List<string> LoadAllFiles(string folderPath = "Samples")
        {
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Samples folder not found.");
                return new List<string>();
            }

            return new List<string>(Directory.GetFiles(folderPath));
        }

        // Detects language based on file extension
        public static string DetectLanguage(string filePath)
        {
            if (filePath.EndsWith(".cs")) return "CSharp";
            if (filePath.EndsWith(".java")) return "Java";
            if (filePath.EndsWith(".py")) return "Python";
            return "Unknown";
        }
    }
}

// Helpers/ReportGenerator.cs
using System;
using System.Collections.Generic;
using System.IO;
using Models;

namespace Helpers
{
    public static class ReportGenerator
    {
        public static void GenerateReport(List<CodeIssue> issues, string filePath)
        {
            // Checks if the Output directory exists
            // If it doesn’t, it creates it
            // Safe to call every time as it won’t crash if the folder already exists
            Directory.CreateDirectory("Output");

            // Define the output file path
            string outputPath = Path.Combine("Output", "report.txt");
            

            // Append the report to the file
            // If the file does not exist, it will be created
            using (StreamWriter writer = new StreamWriter(outputPath, append: true))
            {
                // Write the header for the report
                // This includes the file path and the current date/time
                writer.WriteLine($"Analysis Report for: {filePath}");
                writer.WriteLine($"Generated at: {DateTime.Now}");
                writer.WriteLine("==================================");

                // Write the issues found
                if (issues.Count == 0)
                {
                    writer.WriteLine("No issues found.");
                }
                else
                {
                    foreach (var issue in issues)
                    {
                        writer.WriteLine($"Line {issue.LineNumber}: {issue.Message}");
                    }
                }

                writer.WriteLine("\n"); // Add some space between reports
            }
        }
    }
}
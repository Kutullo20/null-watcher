using System;
using System.Collections.Generic;
using Helpers;
using Models;
using Rules;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting null safety analysis...");

        // Clear previous report
        ClearPreviousReport();

        // Load all sample files
        var files = FileLoader.LoadAllFiles();

        if (files.Count == 0)
        {
            Console.WriteLine("No files found to analyze.");
            return;
        }

        var engine = new RuleEngine();

        foreach (var file in files)
        {
            
            string language = FileLoader.DetectLanguage(file);
            Console.WriteLine($"Analyzing {file} as {language}...");

            var issues = engine.Analyze(file, language);

         
            // Using the ReportGenerator to append issues to the report file
            // This will create or update Output/report.txt with the results
    
            ReportGenerator.GenerateReport(issues, file);

            // Display results in console
            DisplayResults(file, issues);
        }

        Console.WriteLine("Analysis complete. Report saved to Output/report.txt");
        
    }


    // Clears the previous report file if it exists
    // This ensures that each run starts with a fresh report
    static void ClearPreviousReport()
    {
        string reportPath = Path.Combine("Output", "report.txt");
        if (File.Exists(reportPath))
        {
            File.Delete(reportPath);
        }
    }
    // Displays the results of the analysis in the console
    // It shows the file name and any issues found
    static void DisplayResults(string filePath, List<CodeIssue> issues)
    {
        
        Console.WriteLine($"Results for {Path.GetFileName(filePath)}:");
        
        if (issues.Count == 0)
        {
            Console.WriteLine("  No issues found.");
            return;
        }

        foreach (var issue in issues)
        {
            Console.WriteLine($"  Line {issue.LineNumber}: {issue.Message}");
        }
    }
}
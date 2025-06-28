using System;
using Helpers;
using Rules; // Make sure to include this if RuleEngine is in the Rules namespace

// Load all code files from the Samples folder using the helper class
var files = FileLoader.LoadAllFiles();
Console.WriteLine($"Found {files.Count} files to analyze");

// Create the main analysis engine
var engine = new RuleEngine();

// Loop through each file and send it for analysis
foreach (var file in files)
{
    var language = FileLoader.DetectLanguage(file);
    Console.WriteLine($"\nAnalyzing {file} (Language: {language})");

    var issues = engine.Analyze(file, language);

    if (issues.Count == 0)
        Console.WriteLine("✅ No null issues found");
    else
    {
        foreach (var issue in issues)
            Console.WriteLine($"❌ Line {issue.LineNumber}: {issue.Message}");
    }
}


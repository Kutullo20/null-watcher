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
    // Detect the programming language based on file extension
    var language = FileLoader.DetectLanguage(file);

    // Analyze the file using the engine, passing the file path and its detected language
    engine.Analyze(file, language);
}

// Get all files from the Samples folder
var files = Directory.GetFiles("Samples");

// Show how many files were found
Console.WriteLine($"Found {files.Length} files to analyze");

// Create the analysis engine
var engine = new RuleEngine();

// Loop through each file and analyze it
foreach (var file in files)
{
    engine.Analyze(file);
}
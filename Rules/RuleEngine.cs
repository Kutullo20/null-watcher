using System.Collections.Generic;
using System.IO;
using Models;
using Rules;

public class RuleEngine
{
    public List<CodeIssue> Analyze(string filePath, string language)
    {
        var issues = new List<CodeIssue>();
        var lines = File.ReadAllLines(filePath);

        // Apply the NullSafetyRule
        var nullIssues = NullSafetyRule.Check(lines, language);
        issues.AddRange(nullIssues);

        return issues;
    }
}
using System;
using System.Collections.Generic;
using Models;

namespace Rules
{
    public static class NullSafetyRule
    {
        // Check method to find risky null usage
        public static List<CodeIssue> Check(string[] lines, string language)
        {
            var issues = new List<CodeIssue>();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                // Simple pattern matching for null assignments and usage
                if (language == "CSharp" || language == "Java")
                {
                    if (line.Contains("null") && !line.Contains("==") && !line.Contains("!="))
                    {
                        issues.Add(new CodeIssue(i + 1, "Possible risky null assignment or usage"));
                    }
                }
                else if (language == "Python")
                {
                    if (line.Contains("None") && !line.Contains("!=") && !line.Contains("=="))
                    {
                        issues.Add(new CodeIssue(i + 1, "Possible risky use of None without checks"));
                    }
                }
            }

            return issues;
        }
    }
}

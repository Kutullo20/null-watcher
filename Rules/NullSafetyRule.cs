using System;
using System.Collections.Generic;
using Models;

namespace Rules
{
    public static class NullSafetyRule
    {
        public static List<CodeIssue> Check(string[] lines, string language)
        {
            var issues = new List<CodeIssue>();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                // Remove inline comments for Python
                if (language == "Python" && line.Contains("#"))
                    line = line.Split('#')[0];

                bool insideDoubleQuotes = false;
                bool insideSingleQuotes = false;
                bool foundNoneOutsideString = false;
                bool foundNullOutsideString = false;

                for (int j = 0; j < line.Length; j++)
                {
                    char c = line[j];

                    // Toggle string states (basic)
                    if (c == '"' && (j == 0 || line[j - 1] != '\\'))
                        insideDoubleQuotes = !insideDoubleQuotes;
                    else if (c == '\'' && (j == 0 || line[j - 1] != '\\'))
                        insideSingleQuotes = !insideSingleQuotes;

                    bool inString = insideDoubleQuotes || insideSingleQuotes;

                    // Check for "null" outside strings
                    if ((language == "Java" || language == "CSharp") && !inString &&
                        j + 3 < line.Length &&
                        line[j] == 'n' && line[j + 1] == 'u' &&
                        line[j + 2] == 'l' && line[j + 3] == 'l' &&
                        (j + 4 == line.Length || !char.IsLetterOrDigit(line[j + 4])))
                    {
                        foundNullOutsideString = true;
                        j += 3;
                    }

                    // Check for "None" outside strings
                    if (language == "Python" && !inString &&
                        j + 3 < line.Length &&
                        line[j] == 'N' && line[j + 1] == 'o' &&
                        line[j + 2] == 'n' && line[j + 3] == 'e' &&
                        (j + 4 == line.Length || !char.IsLetterOrDigit(line[j + 4])))
                    {
                        foundNoneOutsideString = true;
                        j += 3;
                    }
                }

                // Evaluate based on language
                if ((language == "Java" || language == "CSharp") &&
                    foundNullOutsideString &&
                    !line.Contains("==") && !line.Contains("!="))
                {
                    issues.Add(new CodeIssue(i + 1, "Possible risky null usage without check"));
                }

                if (language == "Python" &&
                    foundNoneOutsideString &&
                    !line.Contains("is None") && !line.Contains("is not None"))
                {
                    issues.Add(new CodeIssue(i + 1, "Possible risky None usage without check"));
                }
            }

            return issues;
        }
    }
}
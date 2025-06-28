namespace Models
{
    // Represents a single code issue found during analysis
    public class CodeIssue
    {
        // The line number where the issue was found
        public int LineNumber { get; }

        // A short message describing the issue
        public string Message { get; }

        // Constructor to initialize the issue details
        public CodeIssue(int lineNumber, string message)
        {
            LineNumber = lineNumber;
            Message = message;
        }
    }
}


using System;

namespace Samples
{
    class TestProgram
    {
        static void TestCases()
        {
            // Risky: Null assignment without check
            string? name = null; // Making null explicit - This variable can be null (nullable reference)

            
            // Safe: Null check before assignment with `==` and `!=`
            if (name == null)
            {
                Console.WriteLine("Name is null");
            }

            else if (name != null)
            {
                Console.WriteLine("Name is not null");
            }

        }
    }
}
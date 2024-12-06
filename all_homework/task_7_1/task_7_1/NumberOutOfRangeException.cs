using System;

namespace task_7_1
{
    public class NumberOutOfRangeException : Exception
    {
        public NumberOutOfRangeException(string message) : base(message) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NegativeInputException : Exception
{
    public NegativeInputException(string message) : base(message)
    {
        var s = $"Test {message}  {message}";
        string s2 = string.Format("hello {0} {1}", message, message);
    }
    public NegativeInputException(string message, Exception innerException) : base(message, innerException) { }
}

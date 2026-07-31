using System;

namespace Exceptions
{
    public class InvalidPinException : Exception
    {
        public InvalidPinException() 
            : base("Invalid PIN entered. Access denied.") { }

        public InvalidPinException(string message) 
            : base(message) { }
    }
}
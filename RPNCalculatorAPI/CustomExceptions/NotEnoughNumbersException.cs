using System;

namespace RPNCalculatorAPI.CustomExceptions
{
    public class NotEnoughNumbersException : Exception
    {
        public NotEnoughNumbersException(string message)
     : base(message)
        {
        }
    }
}

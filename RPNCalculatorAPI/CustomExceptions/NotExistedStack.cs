using System;

namespace RPNCalculatorAPI.CustomExceptions
{
    public class NotExistedStack : Exception
    {
        public NotExistedStack(string message)
  : base(message)
        {
        }
    }
}

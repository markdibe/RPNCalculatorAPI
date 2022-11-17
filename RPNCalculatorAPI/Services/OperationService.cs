using RPNCalculatorAPI.IServices;

namespace RPNCalculatorAPI.Services
{
    public class OperationService : IOperation
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Divide(int x, int y)
        {
            return x / y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public int Substract(int x, int y)
        {
            return x - y;
        }
    }
}

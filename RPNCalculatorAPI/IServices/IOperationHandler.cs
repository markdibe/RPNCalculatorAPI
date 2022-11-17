using System.Collections.Concurrent;

namespace RPNCalculatorAPI.IServices
{
    public interface IOperationHandler
    {
        public ConcurrentStack<int> Compute(string input);
    }
}
